﻿using System;
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
        public void SavePurchases([FromBody] List<Purchase> purchases)
        {
            DBController controller = new DBController();
            controller.UploadPurchases(purchases);
        }

        [HttpGet]
        public List<Purchase> GetPurchases()
        {
            DBController controller = new DBController();

            return controller.GetAllPurchases();
        }
    }
}
