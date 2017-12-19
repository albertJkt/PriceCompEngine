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
        List<Purchase> GetShopItemsList(int days);
        List<Purchase> GetShopItemsList();

        List<Item> GetSpecificItem(string itemName, string[] shops);

        Purchase GetLatestEntry(string itemName, string shop);
        void InsertEntry(Purchase item);
        void PushToDatabase(List<Purchase> items);
    }

    public class DBController : IDBController
    {

        public List<Purchase>  GetShopItemsList(int days)
        {
            List<Purchase> items;
            using (var context = new PriceCompEngineEntities())
            {
                DateTime oldestValidTime = DateTime.UtcNow.Subtract(new TimeSpan(days, 0, 0, 0));

                IQueryable<Purchase> query = from item in context.Purchases
                                         where item.DateTime >= oldestValidTime
                                         orderby item.DateTime descending
                                         select item;
                items = query.ToList();
            }
            return items;
        }

        public List<Purchase> GetShopItemsList()
        {
            List<Purchase> items;
            using (var context = new PriceCompEngineEntities())
            {
                IQueryable<Purchase> query = from item in context.Purchases
                                             orderby item.DateTime descending
                                             select item;
                items = query.ToList();       
            }
            return items;
        }

        public List<string> PerformSearch(string keyword)
        {
            using (var context = new PriceCompEngineEntities())
            {
                var results = context.Items.Where(item => item.Name.ToLower().Contains(keyword))
                                           .Select(item => item.Name)
                                           .Distinct()
                                           .ToList();

                return results;
            }
        }

        public Purchase GetLatestEntry(string itemName, string shop)
        {
            using (var context = new PriceCompEngineEntities())
            {
                IQueryable<Purchase> query = from item in context.Purchases
                                          where item.ItemName == itemName
                                          where item.ShopName == shop
                                          orderby item.DateTime descending
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

        public void InsertEntry(Purchase item)
        {
            using (var context = new PriceCompEngineEntities())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }
        
        public void PushToDatabase (List<Purchase> items)
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

        public User GetUser(string username, string password)
        {
            using (var context = new PriceCompEngineEntities())
            {
                IQueryable<User> query = from user in context.Users
                                         where user.UserName == username
                                         where user.Password == password
                                         select user;
                User usr;
                try
                {
                    usr = query.Single();
                    return usr;
                }
                catch (InvalidOperationException ex)
                {
                    return null;
                }
            }
        }

        public List<double> GetAverageItemPrices(List<string> items)
        {
            using (var context = new PriceCompEngineEntities())
            {
                List<double> prices = new List<double>();
                foreach (string item in items)
                {
                    double price = context.Items.Where(i => i.Name == item)
                                                .Average(i => i.Price);
                    price = Math.Round(price, 2);
                    prices.Add(price);
                }
                return prices;
            }
        }

        public bool CheckUsername (string username)
        {
            using (var context = new PriceCompEngineEntities())
            {
                IQueryable<User> query = from user in context.Users
                                         where user.UserName == username
                                         select user;

                if (query.Any())
                {
                    return true;
                }
                else return false;
            }
        }
        public bool CheckEmail(string email)
        {
            using (var context = new PriceCompEngineEntities())
            {
                IQueryable<User> query = from user in context.Users
                                         where user.Email == email
                                         select user;

                if (query.Any())
                {
                    return true;
                }
                else return false;
            }
        }
       
        public void UpdateItems(List<Item> items)
        {
            using (var context = new PriceCompEngineEntities())
            {
                foreach(var i in items)
                {
                    var query = context.Items.Where(item => item.Name == i.Name && item.ShopName == i.ShopName);

                    if (query.Any())
                    {
                        var toChange = query.Single();
                        toChange.Price = i.Price;
                    }
                    else
                    {
                        var newItem = new Item()
                        {
                            Name = i.Name,
                            ShopName = i.ShopName,
                            Price = i.Price
                        };
                        context.Items.Add(newItem);
                    }
                }
                context.SaveChanges();
            }
        }

        public List<Item> GetAllItems()
        {
            using (var context = new PriceCompEngineEntities())
            {
                var items = context.Items.Select(item => item).ToList();

                return items;
            }
        }

        public List<Item> GetSpecificItem(string itemName, string[] shops)
        {
            using (var context = new PriceCompEngineEntities())
            {
                var items = context.Items.Where(item => item.Name == itemName && shops.Contains(item.ShopName))
                                         .Select(item => item)
                                         .ToList();

                return items;
            }
        }

        public void UploadPurchases(List<Purchase> purchases)
        {
            using (var context = new PriceCompEngineEntities())
            {
                foreach(var purchase in purchases)
                {
                    context.Purchases.Add(purchase);
                }
                context.SaveChanges();
            }
        }

        public List<Purchase> GetAllPurchases()
        {
            using (var context = new PriceCompEngineEntities())
            {
                var purchases = context.Purchases.Select(p => p).ToList();

                return purchases;
            }
        }

        public List<Purchase> GetUserPurchases(string user, int days)
        {
            using (var context = new PriceCompEngineEntities())
            {
                DateTime oldestValidTime = DateTime.UtcNow.Subtract(new TimeSpan(days, 0, 0, 0));
                var purchases = context.Purchases
                            .Where(purchase => purchase.UserName == user &&
                                              purchase.DateTime >= oldestValidTime)
                            .Select(purchase => purchase)
                            .ToList();

                return purchases;
            }
        }
    }
}
