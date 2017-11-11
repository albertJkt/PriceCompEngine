using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logic;
using System.Diagnostics;

namespace PriceCompEngineAPI.Controllers
{
    public class TextManagerController : ApiController
    {
        // GET: api/TextManager/
        public List<ShopItem> Post([FromBody] JsonString text)
        {
            TextManager manager = new TextManager();
            List<ShopItem> items = manager.GetListOfProducts(text.Text);

            return items;
        }
    }

    public class JsonString
    {
        public string Text { get; set; }
    }
}
