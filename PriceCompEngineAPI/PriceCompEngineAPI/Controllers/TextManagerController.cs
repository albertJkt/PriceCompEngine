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
    public class TextManagerController : ApiController
    {
        public List<ShopItem> Get([FromUri] string imageText)
        {
            if (string.IsNullOrEmpty(imageText))
            {
                throw new ArgumentException("Argument imageText is null or empty");
            }

            TextManager manager = new TextManager();

            List<ShopItem> items = manager.GetListOfProducts(imageText);
            return items;
        }
    }
}
