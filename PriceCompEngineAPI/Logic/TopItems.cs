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
            List<Item> shopItems = _controller.GetShopItemsList();

            var items = (shopItems.GroupBy(x => x.Name)
                .Select(group => new
                {
                    Name = group.Key,
                    Count = group.Count()
                })).Take(rows)
                .OrderByDescending(x => x.Count)
                .ToDictionary(g => g.Name, g => g.Count);

            return items;
        }

        /*^naujas*/
        public Dictionary<string, int> GetTopShopItemsList(int rows, int days)
        {
            List<Item> shopItems = _controller.GetShopItemsList(days);

            var items = (shopItems.GroupBy(x => x.Name)
                .Select(group => new
                {
                    Name = group.Key,
                    Count = group.Count()
                })).Take(rows)
                .OrderByDescending(x => x.Count)
                .ToDictionary(g => g.Name, g => g.Count);

            return items;
        }

        /*^naujas*/
        public List<Item> GetCheapestShopItemsList(int rows)
        {
            List<Item> shopItems = _controller.GetShopItemsList();
            var items = (shopItems.OrderBy(x => x.Price)).Take(rows)
                .ToList<Item>();

            return items;
        }

        /*^naujas*/
        public List<Item> GetCheapestShopItemsList(int rows, int date)
        {
            List<Item> shopItems = _controller.GetShopItemsList(date);
            var items = (shopItems.OrderBy(x => x.Price)).Take(rows)
                .ToList();

            return items;
        }

    }
}
