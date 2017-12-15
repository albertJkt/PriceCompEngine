using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ShoppingCart
    {
        public string BestShop { get; private set; }
        public double AveragePrice { get; private set; }
        public double LowestPrice { get; private set; }

        private List<string> _itemNames;
        private string[] _shops;
        private IDBController _controller;

        public ShoppingCart(List<string> itemNames, string[] shops, IDBController controller)
        {
            _controller = controller;
            _itemNames = itemNames;
            _shops = shops;
            AnalyzeShoppingCart();
        }

        public void AnalyzeShoppingCart()
        {
            PriceComparator comparator = new PriceComparator(_controller);
            List<Item> allItems = new List<Item>();
            for (int i = 0; i < _itemNames.Count(); i++)
            {
                List<Item> specificItem = comparator.GetOrderedItemsList(_itemNames[i], _shops, _shops.Count());
                allItems.AddRange(specificItem);
            }

            Dictionary<string, double> shopPrices = new Dictionary<string, double>();
            for (int i = 0; i < _shops.Count(); i++)
            {
                var shopPrice = allItems.Where(item => item.ShopName == _shops[i])
                                        .Sum(item => item.Price);

                shopPrices.Add(_shops[i], shopPrice);
            }

            KeyValuePair<string, double> bestShop = shopPrices.OrderBy(pair => pair.Value)
                                                              .First();
            BestShop = bestShop.Key;
            LowestPrice = bestShop.Value;
            AveragePrice = Math.Round(shopPrices.Average(pair => pair.Value), 2);
        }
    }
}
