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
            PCEUriBuilder[] builders = new PCEUriBuilder[5]
            {
                new PCEUriBuilder(Resources.CheapestItems),
                new PCEUriBuilder(Resources.PriceComparator),
                new PCEUriBuilder(Resources.ShoppingCart),
                new PCEUriBuilder(Resources.TextManager),
                new PCEUriBuilder(Resources.TopItems)
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
            PCEUriBuilder builder = new PCEUriBuilder(Resources.ShoppingCart);

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
            PCEUriBuilder builder = new PCEUriBuilder(Resources.CheapestItems);

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
