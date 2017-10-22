using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
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

            var queryableList = items.AsQueryable<ShopItem>();


            List<ShopItem> sortedList = items.OrderBy(item => item.Price).ToList<ShopItem>();

            ShopItem cheapestItem = sortedList.First<ShopItem>();

            return cheapestItem;

        }


        public List<ShopItem> GetCheapestItemList(string itemName, string[] shops, int topPlaces)
        {
            List<ShopItem> items = new List<ShopItem>();
            DBController db = new DBController();

            foreach (string shop in shops)
            {
                ShopItem newItem = db.GetLatestEntry(itemName, shop);
                if (newItem != null)
                    items.Add(newItem);
            }

            items = items.OrderBy(item => item.Price).ToList<ShopItem>();

            if (items.Count > topPlaces)
            {
                items.RemoveRange(topPlaces - 1, items.Count - 1);
            }
            

            return items;
        }

        /*
         This one will not be used for now, as it requires some additional testing and corrections
        
        public List<ShopItem> GetCheapestItemTypeList(string itemType, string[] shops, int topPlaces)
        {
            List<ShopItem> allItems = (new DBController()).GetShopItemsList(itemType, shops, 14);

            var filteredItems = allItems.GroupBy(item => item.ShopName).Select(group => group.First()).ToList<ShopItem>();

            return filteredItems;
        }*/
    }
}
