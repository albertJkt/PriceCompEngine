using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using DataBase;
using System.Collections.Generic;

namespace LogicTests
{
    [TestClass]
    public class PriceComparatorTest
    {
        [TestMethod]
        public void GetCheapestItemTest()
        {
            PriceComparator comparator = new PriceComparator();
            string[] shops =
            {
                "Maxima",
                "Rimi",
                "Iki",
                "Norfa"
            };
            string itemName = "Mineralinis vanduo Vytautas";

            float expectedPrice = (float) 0.65;
            string expectedShop = "Iki";
            string expectedItemName = "Mineralinis vanduo Vytautas";

            ShopItem item = comparator.GetCheapestItem(itemName, shops);

            float actualPrice = item.Price;
            string actualShop = item.ShopName;
            string actualItemname = item.ItemName;

            Assert.AreEqual(expectedPrice, actualPrice);
            Assert.AreEqual(expectedShop, actualShop);
            Assert.AreEqual(expectedItemName, actualItemname);
        }

        [TestMethod]
        public void GetCheapestItemsListTest()
        {
            PriceComparator comparator = new PriceComparator();
            string[] shops =
            {
                "Maxima",
                "Rimi",
                "Iki",
                "Norfa"
            };
            string itemName = "Mineralinis vanduo Vytautas";

            float[] expectedPrices =
            {
               (float) 0.65,
               (float) 0.69,
               (float) 0.71
            };

            string[] expectedShops =
            {
                "Iki",
                "Maxima",
                "Rimi"
            };

            string expectedItemName = "Mineralinis vanduo Vytautas";

            List<ShopItem> items = comparator.GetCheapestItemList(itemName, shops, 3);
            int i = 0;
            foreach(ShopItem item in items)
            {
                float actualPrice = item.Price;
                string actualShop = item.ShopName;
                string actualItemname = item.ItemName;

                Assert.AreEqual(expectedPrices[i], actualPrice);
                Assert.AreEqual(expectedShops[i], actualShop);
                Assert.AreEqual(expectedItemName, actualItemname);

                i++;
            }
        }
    }
}
