using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBase;
using System.Collections.Generic;
using System.Linq;

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

            foreach(ShopItem shopItem in retrievedItems)
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
    }
}
