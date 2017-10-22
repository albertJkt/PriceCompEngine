using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBase;
using System.Collections.Generic;
using System.Linq;
using Logic;
using OCREngine;

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
        public void GetLatestEntryTest()
        {
            DBController controller = new DBController();
            float expectedPrice = (float) 0.69;

            ShopItem item =  controller.GetLatestEntry("Mineralinis vanduo Vytautas", "Maxima");

            float actualPrice = item.Price;

            Assert.AreEqual(expectedPrice, actualPrice);

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
