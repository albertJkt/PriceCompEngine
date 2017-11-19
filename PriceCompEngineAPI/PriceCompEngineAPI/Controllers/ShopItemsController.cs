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
        public List<ShopItem> Get()
        {
            DBController controller = new DBController();
            List<ShopItem> items = controller.GetShopItemsList();

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
