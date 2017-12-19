using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataBase;

namespace PriceCompEngineAPI.Controllers
{
    public class PurchasesController : ApiController
    {
        [HttpPost]
        public string SavePurchases([FromBody] List<Purchase> purchases)
        {
            DBController controller = new DBController();
            controller.UploadPurchases(purchases);

            return "";
        }

        [HttpGet]
        public List<Purchase> GetPurchases()
        {
            DBController controller = new DBController();

            return controller.GetAllPurchases();
        }

        [HttpGet]
        public Dictionary<string, int> GetUserTopPurchases([FromUri] string userName, [FromUri] int days)
        {
            DBController controller = new DBController();

            List<Purchase> purchases = controller.GetUserPurchases(userName, days);

            var userPurchases = (purchases.GroupBy(x => x.ItemName)
                .Select(group => new
                {
                    ItemName = group.Key,
                    Sum = (int)group.Sum(x => x.Price)
                })).Take(5)
                .OrderByDescending(x => x.Sum)
                .ToDictionary(g => g.ItemName, g => g.Sum);

            return userPurchases;
        }
    }
}
