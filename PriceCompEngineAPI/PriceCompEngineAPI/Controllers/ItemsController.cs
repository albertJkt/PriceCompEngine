﻿using System;
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
        public List<Item> GetItems()
        {
            DBController controller = new DBController();

            return controller.GetAllItems();
        }
    }
}