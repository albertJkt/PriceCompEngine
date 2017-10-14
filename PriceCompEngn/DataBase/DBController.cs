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
        public List<Product> Products { get; private set; }
        private const string SQL_TABLE_NAME = "dbo.Prekes";

        public List<Product> GetProducts(string type, string[] shops, int days)
        {
            string sql_query = "SELECT * FROM " + SQL_TABLE_NAME + " WHERE Tipas = \'" + type + "\'";
            //sql statement is not finished, needs filter for 1 entry per shop, entries have to be the most recent ones

            List<Product> products = null;
            
            using(SqlConnection connection = new SqlConnection(new Connection().GetConnectionString()))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = sql_query;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (products == null)
                        products = new List<Product>();
                    string shopName = reader.GetString(0);
                    string productName = reader.GetString(1);
                    string productType = reader.GetString(2);
                    float price = reader.GetFloat(3);

                    products.Add(new Product(shopName, productName, productType, price));
                }
            }

            Products = products;
            return products;
        }

        public List<ShopItem> GetProductsLinq(string type, string[] shops, int days)
        {
            List<ShopItem> products;
            using(var context = new PriceCompEngineEntities())
            {
                IQueryable<ShopItem> query = from item in context.ShopItems
                            where item.Type == type
                            select item;
                products = query.ToList<ShopItem>();
            }
            return products;
        }

        public List<Product> GetTopProducts(string number)
        {
            string sql_query = "SELECT TOP " + number + " *, COUNT(*) Kiekis FROM" + SQL_TABLE_NAME;

            List<Product> products = null;
            
            using(SqlConnection connection = new SqlConnection(new Connection().GetConnectionString()))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = sql_query;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (products == null)
                        products = new List<Product>();
                    string shopName = reader.GetString(0);
                    string productName = reader.GetString(1);
                    string productType = reader.GetString(2);
                    float price = reader.GetFloat(3);

                    products.Add(new Product(shopName, productName, productType, price));
                }
            }

            Products = products;
            return products;
        }
        
        public List<ShopItem> GetTopProductsLinq(int number)
        {
            List<ShopItem> products;
            using (var context = new PriceCompEngineEntities())
            {
                //need to learn how to write this query correctly
                IQueryable<ShopItem> query = (from item in context.ShopItems
                                              group item by item.ItemName into g
                                              select g);
                products = query.ToList<ShopItem>();
            }
            return products;
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
