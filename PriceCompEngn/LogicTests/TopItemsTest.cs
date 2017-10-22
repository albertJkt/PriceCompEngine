using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Linq;

namespace LogicTests
{
    [TestClass]
    public class TopItemsTest
    {
        [TestMethod]
        public void GetShopTopItemListTest()
        {
            TopItems topItems = new TopItems();
            int rows = 2;
            var test = topItems.GetTopShopItemsList(rows);
            string[] expectedNames = { "Mineralinis vanduo Vytautas", "Energetinis gerima Red Bull" };
            int[] expectedNumbers = { 4, 1 };

            Assert.AreEqual(expectedNames[0], test.Keys.First());
            Assert.AreEqual(expectedNames[1], test.Keys.Last());
            Assert.AreEqual(expectedNumbers[0], test["Mineralinis vanduo Vytautas"]);
            Assert.AreEqual(expectedNumbers[1], test["Energetinis gerima Red Bull"]);

        }

        [TestMethod]
        public void GetShopTopItemList2Test()
        {
            TopItems topItems = new TopItems();
            int rows = 4;
            int days = 14;
            int expected = 4;

            var test = topItems.GetTopShopItemsList(rows, days);
            Assert.AreEqual(expected, test.Count());
        }

        [TestMethod]
        public void GetCheapestShopItemListTest()
        {
            TopItems topItems = new TopItems();
            int rows = 5;

            var test = topItems.GetCheapestShopItemsList(rows);
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void GetCheapestShopItemListTest2()
        {
            TopItems topItems = new TopItems();
            int rows = 5;
            int date = 3;

            var test = topItems.GetCheapestShopItemsList(rows, date);
            Assert.IsNotNull(test);
        }
    }
}
