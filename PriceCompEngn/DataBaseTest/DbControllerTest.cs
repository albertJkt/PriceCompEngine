using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBase;
using System.Collections.Generic;
using System.Linq;
using Logic;
using OCREngine;
using DataBase;

namespace DataBaseTest
{
    [TestClass]
    public class DBControllerTest
    {
        [TestMethod]
        public void GetShopItemsListTest()
        {
            DBController controller = new DBController();
            string type = "vanduo";
            string[] shops =
            {
                "Maxima",
                "Iki",
                "Rimi",
                "Norfa"
            };
            int days = 14;

            List<ShopItem> retrievedItems = controller.GetShopItemsList(type, shops, days);

            int expectedId = 1;
            string expectedShopName = "Maxima";
            string expectedItemnName = "Mineralinis vanduo Vytautas";
            string expectedType = "Vanduo";
            float expectedPrice = (float)0.69;

            ShopItem item = retrievedItems.Last<ShopItem>();

            int actualId = item.Id;
            string actualShopName = item.ShopName;
            string actualitemName = item.ItemName;
            string actualType = item.Type;
            float actualPrice = item.Price;

            foreach (ShopItem shopItem in retrievedItems)
            {
                Console.WriteLine(shopItem.PurchaseTime.ToString());
            }

            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedItemnName, actualitemName);
            Assert.AreEqual(expectedShopName, actualShopName);
            Assert.AreEqual(expectedType, actualType);
            Assert.AreEqual(expectedPrice, actualPrice);
            Assert.IsNotNull(retrievedItems);
        }

        [TestMethod]
        public void GetShopTopItemList()
        {
            DBController controller = new DBController();
            string type = "vanduo";
            string type2 = "energetinis gerimas";
            string[] shops =
            {
                "Maxima",
                "Iki",
                "Rimi",
                "Norfa"
            };
            int days = 300;
            int number = 2;
            List<ShopItem> retrievedItems = controller.GetShopItemsList(type, shops, days);
            List<ShopItem> test1 = controller.GetShopItemsList(type2, shops, days);

            retrievedItems.Add(test1.Last<ShopItem>());


            ShopItem item = retrievedItems.Last<ShopItem>();
            var test = controller.GetTopShopItemsList(retrievedItems, number);
            string[] expectedNames = { "Mineralinis vanduo Vytautas", "Energetinis gerima Red Bull" };
            int[] expectedNumbers = { 4, 1 };

            Assert.AreEqual(expectedNames[0], test.Keys.First());
            Assert.AreEqual(expectedNames[1], test.Keys.Last());
            Assert.AreEqual(expectedNumbers[0], test["Mineralinis vanduo Vytautas"]);
            Assert.AreEqual(expectedNumbers[1], test["Energetinis gerima Red Bull"]);

        }

        [TestMethod]
        public void PushToDatabaseTest()
        {
            TextManager tm = new TextManager();
            string ImagePath = @"C:\Users\Albert\Desktop\ab.png";
            string ResultText = OCREngineAPI.GetImageText(ImagePath, "lt", ResultFormat.TEXT);
            List<ShopItem> Actual;

            Actual = tm.GetListOfProducts(ResultText);
            DBController con = new DBController();
            // We don't really want to push to DB everytime we run this test
           // con.PushToDatabase(Actual);

            

        }

    }
}
