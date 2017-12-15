using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataBase;

namespace PriceCompEngineAPI.Controllers
{
    public class ItemsController : ApiController
    {
        [HttpPost]
        public string SaveItems([FromBody] List<Item> items)
        {
            DBController controller = new DBController();
            controller.UpdateItems(items);

            return "";
        }

        [HttpGet]
        public Dictionary<string, double> GetSearchResults([FromUri] string keyword)
        {
            DBController controller = new DBController();
            List<string> searchResults = controller.PerformSearch(keyword);
            List<double> prices = controller.GetAverageItemPrices(searchResults);

            Dictionary<string, double> results = new Dictionary<string, double>();
            for (int i = 0; i < searchResults.Count; i++)
            {
                results.Add(searchResults[i], prices[i]);
            }

            return results;
        }

        [HttpGet]
        public List<Item> GetItems()
        {
            DBController controller = new DBController();

            return controller.GetAllItems();
        }
    }
}
