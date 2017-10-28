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
        public Dictionary<string, int> GetTopShopItemsList(int rows)
        {
            DBController controller = new DBController();
            List<ShopItem> shopItems = controller.GetShopItemsList();

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
            DBController controller = new DBController();
            List<ShopItem> shopItems = controller.GetShopItemsList(days);

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
            DBController controller = new DBController();
            List<ShopItem> shopItems = controller.GetShopItemsList();
            var items = (shopItems.OrderBy(x => x.Price)).Take(rows)
                .ToList<ShopItem>();

            return items;

        }

        public List<ShopItem> GetCheapestShopItemsList(int rows, int date)
        {
            DBController controller = new DBController();
            List<ShopItem> shopItems = controller.GetShopItemsList(date);
            var items = (shopItems.OrderBy(x => x.Price)).Take(rows)
                .ToList<ShopItem>();

            return items;

        }
    }
}
