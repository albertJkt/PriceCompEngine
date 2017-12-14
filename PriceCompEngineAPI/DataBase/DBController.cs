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
