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
        public ShopCheckAnalyzer Post([FromBody] StringObject imageText)
        {
            if (string.IsNullOrEmpty(imageText.Text))
            {
                throw new ArgumentException("Argument imageText is null or empty");
            }

            ShopCheckAnalyzerCreator creator = new ShopCheckAnalyzerCreator();
            ShopCheckAnalyzer analyzer = creator.Create(imageText.Text);

            return analyzer;
        }

        public class StringObject
        {
            public string Text { get; set; }
        }
    }
}
