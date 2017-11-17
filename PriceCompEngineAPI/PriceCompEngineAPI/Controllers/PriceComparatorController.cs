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
        public ShopItem Get(string itemName, [FromUri] string[] shops)
        {
            PriceComparator comparator = new PriceComparator();
            ShopItem item = comparator.GetCheapestItem(itemName, shops);

            return item;
        }

        public List<ShopItem> Get(string itemName, [FromUri] string[] shops, int topPlaces, ComparisonType type)
        {
            PriceComparator comparator = new PriceComparator();
            List<ShopItem> items = comparator.GetOrderedItemsList(itemName, shops, topPlaces, type);

            return items;
        }
    }
}
