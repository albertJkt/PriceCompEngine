using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriceCompEngineAPI.Controllers
{
    public class UserController : ApiController
    {
        private IDBController _controller;

        public CheapestItemsController(IDBController controller)
        {
            _controller = controller;
        }


    }
}