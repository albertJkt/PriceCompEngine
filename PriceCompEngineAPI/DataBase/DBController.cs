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
    public interface IDBController
    {
        List<ShopItem> GetShopItemsList(string type, string[] shops, int days);
        List<ShopItem> GetShopItemsList(string type, string[] shops);
        List<ShopItem> GetShopItemsList(int days);
        List<ShopItem> GetShopItemsList();
        ShopItem GetLatestEntry(string itemName, string shop);
        void InsertEntry(ShopItem item);
        void PushToDatabase(List<ShopItem> items);
    }

    public class DBController : IDBController
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

        public List<ShopItem> GetShopItemsList(string type, string[] shops)
        {
            List<ShopItem> items;
            using (var context = new PriceCompEngineEntities())
            {
                IQueryable<ShopItem> query = from item in context.ShopItems
                                             where item.Type == type
                                             where shops.Contains<string>(item.ShopName)
                                             orderby item.PurchaseTime descending
                                             select item;

                items = query.ToList<ShopItem>();
            }
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

                if (query.Any())
                {
                    var item = query.FirstOrDefault();
                    return item;
                }
                else
                {
                    return null;
                }
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
        
        public void PushToDatabase (List<ShopItem> items)
        {
            foreach (var item in items)
            {
                InsertEntry(item);
            }
        }
        public void InsertUser (User user)
        {
            using (var context = new PriceCompEngineEntities())
            {
                context.Entry(user).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        // Check if user already exists
        // if this method contains at least 1 element -> user exists

        public bool CheckIfExists(string username, string email)
        {
            using (var context = new PriceCompEngineEntities())
            {
                IQueryable<User> query = from user in context.Users
                                         where user.UserName == username
                                         where user.Email == email
                                         select user;

                if (query.Any())
                {
                    return true;
                }
                else return false;
            }
        }
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (var context = new PriceCompEngineEntities())
            {
                var query = from user in context.Users
                            select user;
                           
                            

                users = query.ToList();
            }

            return users;
        }
       

    }
}
