using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logic;
using DataBase;

namespace PriceCompEngineAPI.Controllers
{
    public class TopItemsController : ApiController
    {
        private IDBController _controller;

        public TopItemsController(IDBController controller)
        {
            _controller = controller;
        }

        public Dictionary<string, int> Get(int rows, int days)
        {
            TopItems topItems = new TopItems(_controller);
            Dictionary<string, int> items = topItems.GetTopShopItemsList(rows, days);

            return items;
        }

        public Dictionary<string, int> Get(int rows)
        {
            TopItems topItems = new TopItems(_controller);
            Dictionary<string, int> items = topItems.GetTopShopItemsList(rows);

            return items;
        }
    }
}
