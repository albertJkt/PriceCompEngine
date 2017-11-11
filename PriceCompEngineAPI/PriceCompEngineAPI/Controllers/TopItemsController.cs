using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logic;

namespace PriceCompEngineAPI.Controllers
{
    public class TopItemsController : ApiController
    {
        // GET: api/TopItems
        public Dictionary<string, int> Get(int rows, int days)
        {
            TopItems topItems = new TopItems();
            Dictionary<string, int> items = topItems.GetTopShopItemsList(rows, days);

            return items;
        }

        public Dictionary<string, int> Get(int rows)
        {
            TopItems topItems = new TopItems();
            Dictionary<string, int> items = topItems.GetTopShopItemsList(rows);

            return items;
        }
    }
}
