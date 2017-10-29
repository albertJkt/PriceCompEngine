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
        public float AveragePrice { get; private set; }
        public float LowestPrice { get; private set; }

        private List<string> _itemNames;
        private string[] _shops;
        private List<ShopItem> _bestPricedItems;
        private Dictionary<string, float> _shopPrices;

        public ShoppingCart(List<string> itemNames, string[] shops)
        {
            _itemNames = itemNames;
            _shops = shops;
            _bestPricedItems = new List<ShopItem>();
            _shopPrices = new Dictionary<string, float>();
            AnalyzeShoppingCart();
        }

        private void AnalyzeShoppingCart()
        {
            PriceComparator comparator = new PriceComparator();

            foreach(string itemName in _itemNames)
            {
                _bestPricedItems.AddRange(comparator.GetCheapestItemList(itemName, _shops, _shops.Length));
            }


            foreach (string shop in _shops)
            {
                _shopPrices.Add(shop, GetPriceInShop(shop));
            }

            LowestPrice = _shopPrices.Values.Min();
            AveragePrice = _shopPrices.Values.Average();
            BestShop = _shopPrices.Where(shop => shop.Value == LowestPrice).Select(shop => shop.Key).First();
        }

        private float GetPriceInShop(string shopName)
        {
            var itemPrices = _bestPricedItems.Where(item => item.ShopName == shopName).Select(item => item.Price);

            float sum = itemPrices.Sum();

            return sum;
        }
    }
}
