using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class PriceComparator
    {
        public ShopItem GetCheapestItem(string itemName, string[] shops)
        {
            List<ShopItem> items = new List<ShopItem>();
            DBController db = new DBController();

            foreach(string shop in shops)
            {
                items.Add(db.GetLatestEntry(itemName, shop));
            }

            return (from item in items
                    orderby item.Price ascending
                    select item).First<ShopItem>();
        }

        public List<ShopItem> GetCheapestItemList(string itemName, string[] shops, int topPlaces)
        {
            List<ShopItem> items = new List<ShopItem>();
            DBController db = new DBController();

            foreach (string shop in shops)
            {
                items.Add(db.GetLatestEntry(itemName, shop));
            }

            var sort = from item in items
                       orderby item.Price ascending
                       select item;
            return sort.ToList<ShopItem>();
        }

        public List<ShopItem> GetCheapestItemTypeList(string itemType, string[] shops, int topPlaces)
        {
            List<ShopItem> allItems = (new DBController()).GetShopItemsList(itemType, shops, 14);

            var filteredItems = allItems.GroupBy(item => item.ShopName).Select(group => group.First()).ToList<ShopItem>();

            return filteredItems;
        }
    }
}
