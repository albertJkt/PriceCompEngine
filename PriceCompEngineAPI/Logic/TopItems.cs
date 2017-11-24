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

        public Dictionary<string, int> GetTopShopItemsList(int rows)
        {
            List<ShopItem> shopItems = _controller.GetShopItemsList();

            var items = (shopItems.GroupBy(x => x.ItemName)
                .Select(group => new
                {
                    Name = group.Key,
                    Count = group.Count()
                })).Take(rows)
                .OrderByDescending(x => x.Count)
                .ToDictionary(g => g.Name, g=> g.Count) ;

            return items;
        }

        public Dictionary<string, int> GetTopShopItemsList(int rows, int days)
        {
            List<ShopItem> shopItems = _controller.GetShopItemsList(days);

            var items = (shopItems.GroupBy(x => x.ItemName)
                .Select(group => new
                {
                    Name = group.Key,
                    Count = group.Count()
                })).Take(rows)
                .OrderByDescending(x => x.Count)
                .ToDictionary(g => g.Name, g => g.Count);

            return items;
        }

        public List<ShopItem> GetCheapestShopItemsList(int rows)
        {
            List<ShopItem> shopItems = _controller.GetShopItemsList();
            var items = (shopItems.OrderBy(x => x.Price)).Take(rows)
                .ToList<ShopItem>();

            return items;

        }

        public List<ShopItem> GetCheapestShopItemsList(int rows, int date)
        {
            List<ShopItem> shopItems = _controller.GetShopItemsList(date);
            var items = (shopItems.OrderBy(x => x.Price)).Take(rows)
                .ToList<ShopItem>();

            return items;

        }
    }
}
