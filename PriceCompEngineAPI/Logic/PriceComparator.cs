using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public enum ComparisonType
    {
        ItemName,
        ItemType
    };

    public class PriceComparator
    {
        private IDBController _controller;

        public PriceComparator(IDBController controller)
        {
            _controller = controller;
        }

        public Purchase GetCheapestItem(string itemName, string[] shops)
        {
            List<Purchase> items = new List<Purchase>();

            foreach(string shop in shops)
            {
                Purchase newItem = _controller.GetLatestEntry(itemName, shop);
                if (newItem != null)
                    items.Add(newItem);
            }

            var queryableList = items.AsQueryable();

            List<Purchase> sortedList = items.OrderBy(item => item.Price).ToList();

            if (sortedList.Count > 0)
            {
                Purchase cheapestItem = sortedList.First();
                return cheapestItem;
            }

            else return null;
        }

        public List<Purchase> GetOrderedItemsList(string itemName, string[] shops, int topPlaces, ComparisonType type)
        {
            if (type == ComparisonType.ItemName)
            {
                List<Purchase> items = GetCheapestItemList(itemName, shops, topPlaces);
                return items;
            }
            else if (type == ComparisonType.ItemType)
            {
                List<Purchase> items = GetCheapestItemTypeList(itemName, shops, topPlaces);
                return items;
            }
            else return new List<Purchase>();
        }

        private List<Purchase> GetCheapestItemList(string itemName, string[] shops, int topPlaces)
        {
            List<Purchase> items = new List<Purchase>();

            foreach (string shop in shops)
            {
                Purchase newItem = _controller.GetLatestEntry(itemName, shop);
                if (newItem != null)
                    items.Add(newItem);
            }

            items = items.OrderBy(item => item.Price).ToList();

            if (items.Count > topPlaces)
            {
                items.RemoveRange(topPlaces - 1, items.Count - 1);
            }

            if (items.Count > 0)
            {
                return items;
            }
            else return null;
                
        }

        private List<Purchase> GetCheapestItemTypeList(string itemType, string[] shops, int topPlaces)
        {
            List<Purchase> items = _controller.GetShopItemsList(itemType, shops);


            var filteredItems = items.GroupBy(item => item.ShopName).Select(group => group.First()).ToList();

            return filteredItems;
        }
    }
}
