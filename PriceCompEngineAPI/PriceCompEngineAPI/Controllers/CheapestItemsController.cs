﻿using System;
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
        private IDBController _controller;

        public CheapestItemsController(IDBController controller)
        {
            _controller = controller;
        }
        
        public List<Purchase> Get(int rows)
        {
            TopItems topItems = new TopItems(_controller);
            List<Purchase> items = topItems.GetCheapestShopItemsList(rows);

            return items;
        }

        public List<Purchase> Get(int rows, int days)
        {
            TopItems topItems = new TopItems(_controller);
            List<Purchase> items = topItems.GetCheapestShopItemsList(rows, days);

            return items;
        }
    }
}
