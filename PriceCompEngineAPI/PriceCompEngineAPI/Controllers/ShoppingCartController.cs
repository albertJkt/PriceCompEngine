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
    public class ShoppingCartController : ApiController
    {
        private IDBController _controller;

        public ShoppingCartController(IDBController controller)
        {
            _controller = controller;
        }

        public ShoppingCart Get([FromUri] string[] items, [FromUri] string[] shops)
        {
            List<string> itemNames = new List<string>(items);
            ShoppingCart shoppingCart = new ShoppingCart(itemNames, shops, _controller);

            return shoppingCart;
        }
    }
}
