using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public struct Product
    {
        public string ShopName { get; }
        public string ProductName { get; }
        public string Type { get; }
        public float Price { get; }

        public Product(string shop, string name, string type, float price)
        {
            ShopName = shop;
            ProductName = name;
            Type = type;
            Price = price;
        }
    }
}
