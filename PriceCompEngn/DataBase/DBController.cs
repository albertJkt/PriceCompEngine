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
        public List<ShopItem> GetProductsLinq(string type, string[] shops, int days)
        {
            List<ShopItem> items;
            using(var context = new PriceCompEngineEntities())
            {
                IQueryable<ShopItem> query = from item in context.ShopItems
                            where item.Type == type
                            select item;
                items = query.ToList<ShopItem>();
            }
            return items;
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
