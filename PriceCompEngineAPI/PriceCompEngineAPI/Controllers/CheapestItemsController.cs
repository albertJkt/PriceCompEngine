using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataBase;
using Logic;

namespace PriceCompEngineAPI.Controllers
{
    public class CheapestItemsController : ApiController
    {
        // GET: api/CheapestItems
        public List<ShopItem> Get(int rows)
        {
            TopItems topItems = new TopItems();
            List<ShopItem> items = topItems.GetCheapestShopItemsList(rows);

            return items;
        }

        public List<ShopItem> Get(int rows, int days)
        {
            TopItems topItems = new TopItems();
            List<ShopItem> items = topItems.GetCheapestShopItemsList(rows, days);

            return items;
        }


    }
}
