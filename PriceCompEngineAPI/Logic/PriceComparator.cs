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
            List<Item> items = _controller.GetSpecificItem(itemName, shops);

            var bestPricedItem = items.OrderBy(item => item.Price)
                                      .Select(item => item)
                                      .First();

            return bestPricedItem;
        }

        public List<Item> GetOrderedItemsList(string itemName, string[] shops, int topPlaces)
        {
            List<Item> items = _controller.GetSpecificItem(itemName, shops);

            var sortedItems = items.OrderBy(item => item.Price)
                                   .Select(item => item)
                                   .Take(shops.Count())
                                   .ToList();

            return sortedItems;
        }
    }
}
