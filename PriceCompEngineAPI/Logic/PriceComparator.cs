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

        public Item GetCheapestItem(string itemName, string[] shops)
        {
            List<Item> items = new List<Item>();

            foreach(string shop in shops)
            {
                Item newItem = _controller.GetLatestEntry(itemName, shop);
                if (newItem != null)
                    items.Add(newItem);
            }

            var queryableList = items.AsQueryable();

            List<Item> sortedList = items.OrderBy(item => item.Price).ToList();

            if (sortedList.Count > 0)
            {
                Item cheapestItem = sortedList.First();
                return cheapestItem;
            }

            else return null;
        }

        public List<Item> GetOrderedItemsList(string itemName, string[] shops, int topPlaces, ComparisonType type)
        {
            if (type == ComparisonType.ItemName)
            {
                List<Item> items = GetCheapestItemList(itemName, shops, topPlaces);
                return items;
            }
            else if (type == ComparisonType.ItemType)
            {
                List<Item> items = GetCheapestItemTypeList(itemName, shops, topPlaces);
                return items;
            }
            else return new List<Item>();
        }

        private List<Item> GetCheapestItemList(string itemName, string[] shops, int topPlaces)
        {
            List<Item> items = new List<Item>();

            foreach (string shop in shops)
            {
                Item newItem = _controller.GetLatestEntry(itemName, shop);
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

        private List<Item> GetCheapestItemTypeList(string itemType, string[] shops, int topPlaces)
        {
            List<Item> items = _controller.GetShopItemsList(itemType, shops);


            var filteredItems = items.GroupBy(item => item.ShopName).Select(group => group.First()).ToList();

            return filteredItems;
        }
    }
}
