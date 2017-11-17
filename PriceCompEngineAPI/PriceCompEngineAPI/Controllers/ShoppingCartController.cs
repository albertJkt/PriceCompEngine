using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logic;

namespace PriceCompEngineAPI.Controllers
{
    public class ShoppingCartController : ApiController
    {
        // GET: api/ShoppingCart
        public ShoppingCart Get([FromUri] string[] items, [FromUri] string[] shops)
        {
            List<string> itemNames = new List<string>(items);
            ShoppingCart shoppingCart = new ShoppingCart(itemNames, shops);

            return shoppingCart;
        }
    }
}
