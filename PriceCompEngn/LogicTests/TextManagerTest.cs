using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using OCREngine;

namespace LogicTests
{
    /// <summary>
    /// Summary description for TextManagerTest
    /// </summary>
    [TestClass]
    public class TextManagerTest
    {
        

        [TestMethod]
        public void TestDetectShopName()
        {
            TextManager tm = new TextManager();
            string ImagePath = @"C:\Users\Albert\Desktop\a.png";
            string ResultText = OCREngineAPI.GetImageText(ImagePath, "lt", ResultFormat.TEXT);
            string Expected = "iki";
            string Actual = String.Empty;
            ResultText = ResultText.ToLower();

            Actual = tm.DetectShopName(ResultText);

            Assert.AreEqual(Expected, Actual);
            

        }
        [TestMethod]
        public void TestGetProducts()
        {
            TextManager tm = new TextManager();
            string ImagePath = @"C:\Users\Albert\Desktop\a.png";
            string ResultText = OCREngineAPI.GetImageText(ImagePath, "lt", ResultFormat.TEXT);
            string Expected = "vanduo \"neptūnas\" 1,69 eu ";
            string Actual = String.Empty;
            ResultText = ResultText.ToLower();

            Actual = tm.GetProducts(ResultText);

            Assert.AreEqual(Expected, Actual);
        }
        [TestMethod]
        public void TestGetDate()
        {
            TextManager tm = new TextManager();
            string ImagePath = @"C:\Users\Albert\Desktop\a.png";
            string ResultText = OCREngineAPI.GetImageText(ImagePath, "lt", ResultFormat.TEXT);
            string Expected = "2017-09-15";
            string Actual = String.Empty;
            ResultText = ResultText.ToLower();

            Actual = tm.GetDate(ResultText);

            Assert.AreEqual(Expected, Actual);
        }
    }
}
