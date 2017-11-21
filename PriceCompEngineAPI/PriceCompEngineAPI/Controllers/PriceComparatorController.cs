using DataBase;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PriceCompEngineAPI.Controllers
{
    public class PriceComparatorController : ApiController
    {
        private IDBController _controller;

        public PriceComparatorController(IDBController controller)
        {
            _controller = controller;
        }

        public ShopItem Get(string itemName, [FromUri] string[] shops)
        {
            PriceComparator comparator = new PriceComparator(_controller);
            ShopItem item = comparator.GetCheapestItem(itemName, shops);

            return item;
        }

        public List<ShopItem> Get(string itemName, [FromUri] string[] shops, int topPlaces, ComparisonType type)
        {
            PriceComparator comparator = new PriceComparator(_controller);
            List<ShopItem> items = comparator.GetOrderedItemsList(itemName, shops, topPlaces, type);

            return items;
        }
    }
}
