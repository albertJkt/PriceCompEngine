using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class ShopCheckAnalyzer
    {
        public List<string> Prices { get; protected set; }
        public List<string> PayedPrices { get; protected set; }
        public List<string> ItemNames { get; protected set; }
        public string ShopName { get; protected set; }
        public DateTime PurchaseTime { get; protected set; }

        public abstract void AnalyzeText(string text);
    }
}
