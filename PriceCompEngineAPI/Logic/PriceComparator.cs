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
        public ShopItem GetCheapestItem(string itemName, string[] shops)
        {
            List<ShopItem> items = new List<ShopItem>();
            DBController db = new DBController();

            foreach(string shop in shops)
            {
                ShopItem newItem = db.GetLatestEntry(itemName, shop);
                if (newItem != null)
                    items.Add(newItem);
            }

            var queryableList = items.AsQueryable();

            List<ShopItem> sortedList = items.OrderBy(item => item.Price).ToList();

            if (sortedList.Count > 0)
            {
                ShopItem cheapestItem = sortedList.First();
                return cheapestItem;
            }

            else return null;
        }

        public List<ShopItem> GetOrderedItemsList(string itemName, string[] shops, int topPlaces, ComparisonType type)
        {
            if (type == ComparisonType.ItemName)
            {
                List<ShopItem> items = GetCheapestItemList(itemName, shops, topPlaces);
                return items;
            }
            else if (type == ComparisonType.ItemType)
            {
                List<ShopItem> items = GetCheapestItemTypeList(itemName, shops, topPlaces);
                return items;
            }
            else return new List<ShopItem>();
        }

        private List<ShopItem> GetCheapestItemList(string itemName, string[] shops, int topPlaces)
        {
            List<ShopItem> items = new List<ShopItem>();
            DBController db = new DBController();

            foreach (string shop in shops)
            {
                ShopItem newItem = db.GetLatestEntry(itemName, shop);
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

        private List<ShopItem> GetCheapestItemTypeList(string itemType, string[] shops, int topPlaces)
        {
            DBController controller = new DBController();
            List<ShopItem> items = controller.GetShopItemsList(itemType, shops);


            var filteredItems = items.GroupBy(item => item.ShopName).Select(group => group.First()).ToList();

            return filteredItems;
        }
    }
}
