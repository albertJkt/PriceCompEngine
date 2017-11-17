using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceClient;
using System.Collections.Generic;
using System.Configuration;

namespace ServiceClientTest
{
    [TestClass]
    public class URIBuilderTest
    {
        [TestMethod]
        public void URIBuilderFindsCorrectConfigurationSettings()
        {
            URIBuilder[] builders = new URIBuilder[5]
            {
                new URIBuilder(Resources.CheapestItems),
                new URIBuilder(Resources.PriceComparator),
                new URIBuilder(Resources.ShoppingCart),
                new URIBuilder(Resources.TextManager),
                new URIBuilder(Resources.TopItems)
            };

            string[] expectedUris = new string[5]
            {
                "/api/CheapestItems?",
                "/api/PriceComparator?",
                "/api/ShoppingCart?",
                "/api/TextManager",
                "/api/TopItems?"
            };

            for(int i = 0; i < 5; i++)
            {
                Assert.AreEqual(builders[i].Uri, expectedUris[i]);
            }

        }

        [TestMethod]
        public void URIBuilderAppendsArrays()
        {
            URIBuilder builder = new URIBuilder(Resources.ShoppingCart);

            string[] items =
            {
                "monster",
                "red bull",
                "Mineralinis vanduo Vytautas"
            };

            string[] shops =
            {
                "iki",
                "rimi",
                "maxima",
                "norfa",
                "lidl"
            };

            builder.AppendArrayArgs("items", items);
            builder.AppendArrayArgs("shops", shops);

            string expectedUri = "/api/ShoppingCart?items=monster&items=red bull&items=Mineralinis vanduo Vytautas&shops=iki&shops=rimi&shops=maxima&shops=norfa&shops=lidl&";
            string actualUri = builder.Uri;

            Assert.AreEqual(expectedUri, actualUri);
            Console.WriteLine(builder.ServerAddress);
        }

        [TestMethod]
        public void URIBuilderAppendsNumericArguments()
        {
            URIBuilder builder = new URIBuilder(Resources.CheapestItems);

            int rows = 5;
            int days = 7;

            Dictionary<string, int> arguments = new Dictionary<string, int>()
            {
                { "rows", rows },
                { "days", days }
            };

            builder.AppendNumericArgs(arguments);

            string expectedUri = "/api/CheapestItems?rows=5&days=7&";
            string actualUri = builder.Uri;

            Assert.AreEqual(expectedUri, actualUri);
        }
    }
}
