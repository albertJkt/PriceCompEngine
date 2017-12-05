using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceClient;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace ServiceClientTest
{
    [TestClass]
    public class RestRequestExecutorTest
    {
        [TestMethod]
        public async Task PostRequestWorks()
        {
            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.TextManager);

            byte[] image = File.ReadAllBytes(Application.StartupPath + "\\template_5.png");

            RestRequestExecutor executor = new RestRequestExecutor();

            string response = await executor.ExecuteRestPostRequest(builder, image);

            var typeList = new[]
            {
                new
                {
                    ItemName = "",
                    ShopName = "",
                    Type = "",
                    Price = (float)0.00,
                    PurchaseTime = new DateTime(),
                    Id = 1
                }
            }.ToList();

            var result = JsonConvert.DeserializeAnonymousType(response, typeList);

            string[] expectedItemNames =
            {
                "sprite",
                "sokoladinis tortas"
            };
            string[] actualItemNames = new string[2];

            int i = 0;
            foreach(var item in result)
            {
                actualItemNames[i] = item.ItemName;
                i++;
            }

            Assert.AreEqual(expectedItemNames[0], actualItemNames[0]);
            Assert.AreEqual(expectedItemNames[1], actualItemNames[1]);
        }

        [TestMethod]
        public async Task GetMethodWorks()
        {
            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.TopItems);

            Dictionary<string, int> arguments = new Dictionary<string, int>()
            {
                { "rows", 5 },
                { "days", 30 }
            };
            builder.AppendNumericArgs(arguments);

            RestRequestExecutor executor = new RestRequestExecutor();

            string response = await executor.ExecuteRestGetRequest(builder);

            Assert.IsNotNull(response);
            Console.WriteLine(response);
        }
    }
}
