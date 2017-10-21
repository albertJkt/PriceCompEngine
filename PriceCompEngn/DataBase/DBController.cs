using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Objects;

namespace DataBase
{
    public class DBController
    {
        public List<ShopItem> GetShopItemsList(string type, string[] shops, int days)
        {
            List<ShopItem> items;
            using (var context = new PriceCompEngineEntities())
            {
                DateTime oldestValidTime = DateTime.UtcNow.Subtract(new TimeSpan(days, 0, 0, 0));

                IQueryable<ShopItem> query = from item in context.ShopItems
                                             where item.Type == type
                                             where shops.Contains<string>(item.ShopName)
                                             where item.PurchaseTime >= oldestValidTime
                                             orderby item.PurchaseTime descending
                                             select item;

                items = query.ToList<ShopItem>();
            }
            return items;
        }


        public List<ShopItem> GetShopItemsList(int days)
        {
            List<ShopItem> items;
            using (var context = new PriceCompEngineEntities())
            {
                DateTime oldestValidTime = DateTime.UtcNow.Subtract(new TimeSpan(days, 0, 0, 0));

                IQueryable<ShopItem> query = from item in context.ShopItems
                                             where item.PurchaseTime >= oldestValidTime
                                             orderby item.PurchaseTime descending
                                             select item;
                items = query.ToList<ShopItem>();
            }
            return items;
        }

        public List<ShopItem> GetShopItemsList()
        {
            List<ShopItem> items;
            using (var context = new PriceCompEngineEntities())
            {
                IQueryable<ShopItem> query = from item in context.ShopItems
                                             orderby item.PurchaseTime descending
                                             select item;
                items = query.ToList<ShopItem>();
            }
            return items;
        }

        public Dictionary<string, int> GetTopShopItemsList(int rows)
        {
            List<ShopItem> shopItems = GetShopItemsList();
            var items = (shopItems.GroupBy(x => x.ItemName).Take(rows)
                 .ToDictionary(g => g.Key, g => g.Count()));

            return items;
        }

        public Dictionary<string, int> GetTopShopItemsList(int rows, int days)
        {
            List<ShopItem> shopItems = GetShopItemsList(days);
            var items = (shopItems.GroupBy(x => x.ItemName).Take(rows)
                .ToDictionary(g => g.Key, g => g.Count()));

            return items;
        }

        public List<ShopItem> GetCheapestShopItemsList(int rows)
        {
            List<ShopItem> shopItems = GetShopItemsList();
            var items = (shopItems.OrderBy(x => x.Price)).Take(rows)
                .ToList<ShopItem>();

            return items;

        }

        public List<ShopItem> GetCheapestShopItemsList(int rows, int date)
        {
            List<ShopItem> shopItems = GetShopItemsList(date);
            var items = (shopItems.OrderBy(x => x.Price)).Take(rows)
                .ToList<ShopItem>();

            return items;

        }

        public ShopItem GetLatestEntry(string itemName, string shop)
        {
            using (var context = new PriceCompEngineEntities())
            {
                IQueryable<ShopItem> query = from item in context.ShopItems
                                             where item.ItemName == itemName
                                             where item.ShopName == shop
                                             orderby item.PurchaseTime descending
                                             select item;

                return query.FirstOrDefault<ShopItem>();
            }
        }

        public void InsertEntry(ShopItem item)
        {
            using (var context = new PriceCompEngineEntities())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        public void PushToDatabase(List<ShopItem> items)
        {
            foreach (var item in items)
            {
                InsertEntry(item);
            }
        }

    }
}
