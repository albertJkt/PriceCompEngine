using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBase;
using Logic;
using System.Collections.Generic;

namespace LogicTests
{
    [TestClass]
    public class ShoppingCartTest
    {
        [TestMethod]
        public void ShoppingCartValuesTest()
        {
            List<ShopItem> items = new List<ShopItem>();

            string[] shopNames =
            {
                "maxima",
                "rimi",
                "iki",
                "norfa"
            };

            List<string> itemNames = new List<string>();
            itemNames.Add("Mineralinis vanduo Vytautas");
            itemNames.Add("monster");
            //itemNames.Add("Red Bull");   
            //itemNames.Add("dvaro");


            ShoppingCart cart = new ShoppingCart(itemNames, shopNames);

            Console.Write(cart.BestShop + "\n" + cart.LowestPrice + "\n" + cart.AveragePrice);
        }
    }
}
