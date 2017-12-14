using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Analyzer
    {
        public List<string> Prices { get; set; }
        public List<string> PayedPrices { get; set; }
        public List<string> ItemNames { get; set; }
        public string ShopName { get; set; }
        public DateTime PurchaseTime { get; set; }

        public List<AnalyzerEntry> ToList()
        {
            List<AnalyzerEntry> entries = new List<AnalyzerEntry>();
            for (int i = 0; i < ItemNames.Count; i++)
            {
                AnalyzerEntry entry = new AnalyzerEntry()
                {
                    ItemName = ItemNames[i],
                    Price = Prices[i],
                    PayedPrice = PayedPrices[i]
                };
                entries.Add(entry);
            }
            return entries;
        }
    }
}
