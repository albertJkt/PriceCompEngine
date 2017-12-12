using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public DateTime DateTime { get; set; }
        public string UserName { get; set; }
        public string ItemName { get; set; }
        public string ShopName { get; set; }
        public double Price { get; set; }
    }
}
