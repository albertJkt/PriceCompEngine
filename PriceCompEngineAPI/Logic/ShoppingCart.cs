﻿using DataBase;
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
        private List<Item> _bestPricedItems;
        private Dictionary<string, float> _shopPrices;
        private IDBController _controller;

        public ShoppingCart(List<string> itemNames, string[] shops, IDBController controller)
        {
            _controller = controller;
            _itemNames = itemNames;
            _shops = shops;
            _bestPricedItems = new List<Item>();
            _shopPrices = new Dictionary<string, float>();
            AnalyzeShoppingCart();
        }

        private void AnalyzeShoppingCart()
        {
            PriceComparator comparator = new PriceComparator(_controller);

            foreach(string itemName in _itemNames)
            {
                List<Item> items = comparator.GetOrderedItemsList(itemName, _shops, _shops.Length, ComparisonType.ItemName);
                _bestPricedItems.AddRange(items);
                foreach(string shopName in _shops)
                {
                    if (!items.Where(item => item.ShopName == shopName).Select(item => item).Any())
                    {
                        _bestPricedItems.Add(new Item()
                        {
                            Name = itemName,
                            ShopName = shopName,
                            Type = items.First().Type,
                            Price = (float)Math.Round((decimal)items.Select(item => item.Price).Average(), 2),
                            PurchaseTime = items.First().PurchaseTime
                        });
                    }
                }
            }


            foreach (string shop in _shops)
            {
                _shopPrices.Add(shop, GetPriceInShop(shop));
            }

            LowestPrice = _shopPrices.Values.Min();
            AveragePrice = (float)Math.Round((decimal)_shopPrices.Values.Average(),2);
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
