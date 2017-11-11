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


        /*
        // GET: api/ShoppingCart/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ShoppingCart
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShoppingCart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShoppingCart/5
        public void Delete(int id)
        {
        }*/
    }
}
