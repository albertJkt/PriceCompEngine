using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using OCREngine;
using DataBase;

namespace LogicTests
{
    /// <summary>
    /// Summary description for TextManagerTest
    /// </summary>
    [TestClass]
    public class TextManagerTest
    {
   
        [TestMethod]
        public void TestGetListOfProducts()
        {
            TextManager tm = new TextManager();
            string ImagePath = @"C:\Users\Albert\Desktop\ab.png";
            string ResultText = OCREngineAPI.GetImageText(ImagePath, "lt", ResultFormat.TEXT);
            string Expected = "pienas";
            List<ShopItem> Actual;
            string act;

            Actual = tm.GetListOfProducts(ResultText);
            act = Actual[0].Type;

            Assert.AreEqual(Expected, act);
        }
    }
}
