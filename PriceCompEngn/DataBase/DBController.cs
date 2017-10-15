using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class DBController
    {
        public List<ShopItem> GetShopItemsList(string type, string[] shops, int days)
        {
            List<ShopItem> items;
            using(var context = new PriceCompEngineEntities())
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

        public ShopItem GetLatestEntry(string itemName, string shop)
        {
            using(var context = new PriceCompEngineEntities())
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
            using(var context = new PriceCompEngineEntities())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
