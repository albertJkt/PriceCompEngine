using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace Logic
{
    public class TopItems
    {
        private IDBController _controller;

        public TopItems(IDBController controller)
        {
            _controller = controller;
        }


        /*^naujas*/
        public Dictionary<string, int> GetTopShopItemsList(int rows)
        {
            List<Purchase> shopItems = _controller.GetShopItemsList();

            var items = (shopItems.GroupBy(x => x.ItemName)
                .Select(group => new
                {
                    ItemName = group.Key,
                    Count = group.Count()
                })).Take(rows)
                .OrderByDescending(x => x.Count)
                .ToDictionary(g => g.ItemName, g => g.Count);

            return items;
        }

        /*^naujas*/
        public Dictionary<string, int> GetTopShopItemsList(int rows, int days)
        {
            List<Purchase> shopItems = _controller.GetShopItemsList(days);

            var items = (shopItems.GroupBy(x => x.ItemName)
                .Select(group => new
                {
                    ItemName = group.Key,
                    Count = group.Count()
                })).Take(rows)
                .OrderByDescending(x => x.Count)
                .ToDictionary(g => g.ItemName, g => g.Count);

            return items;
        }

        /*^naujas*/
        public List<Purchase> GetCheapestShopItemsList(int rows)
        {
            List<Purchase> shopItems = _controller.GetShopItemsList();
            var items = (shopItems.OrderBy(x => x.Price)).Take(rows)
                .ToList();

            return items;
        }

        /*^naujas*/
        public List<Purchase> GetCheapestShopItemsList(int rows, int date)
        {
            List<Purchase> shopItems = _controller.GetShopItemsList(date);
            var items = (shopItems.OrderBy(x => x.Price)).Take(rows)
                .ToList();

            return items;
        }

    }
}
