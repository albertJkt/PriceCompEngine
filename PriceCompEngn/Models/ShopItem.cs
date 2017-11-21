using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ShopItem
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string ItemName { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }
        public System.DateTime PurchaseTime { get; set; }
    }
}
