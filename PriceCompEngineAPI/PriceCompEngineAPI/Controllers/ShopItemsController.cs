using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataBase;
using Newtonsoft.Json;

namespace PriceCompEngineAPI.Controllers
{
    public class ShopItemsController : ApiController
    {
        private IDBController _controller;

        public ShopItemsController(IDBController controller)
        {
            _controller = controller;
        }

        public List<ShopItem> Get()
        {
            List<ShopItem> items = _controller.GetShopItemsList();

            return items;
        }

        public List<ShopItem> Get([FromUri] string itemName, [FromUri] string[] shops)
        {
            List<ShopItem> items = new List<ShopItem>();
            foreach (string shop in shops)
            {
                ShopItem item = _controller.GetLatestEntry(itemName, shop);
                if (item != null)
                {
                    items.Add(item);
                }
            }
            return items;
        }
     

        public void Post([FromUri] string itemListJson)
        {
            List<ShopItem> items = JsonConvert.DeserializeObject<List<ShopItem>>(itemListJson);

            DBController controller = new DBController();
            controller.PushToDatabase(items);
        }
    }
}
