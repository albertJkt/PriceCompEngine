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
        public List<ShopItem> Post([FromBody] StringObject imageText)
        {
            if (string.IsNullOrEmpty(imageText.Text))
            {
                throw new ArgumentException("Argument imageText is null or empty");
            }

            ShopCheckAnalyzerCreator creator = new ShopCheckAnalyzerCreator();
            ShopCheckAnalyzer analyzer = creator.Create(imageText.Text);

            List<ShopItem> items = new List<ShopItem>();
            for (int i = 0; i < analyzer.ItemNames.Count; i++)
            {
                ShopItem item = new ShopItem()
                {
                    ItemName = analyzer.ItemNames[i],
                    Price = float.Parse(analyzer.Prices[i]),
                    ShopName = analyzer.ShopName,
                    PurchaseTime = analyzer.PurchaseTime,
                    Type = "generic"
                };
                items.Add(item);
            }

            return items;
        }

        public class StringObject
        {
            public string Text { get; set; }
        }
    }
}
