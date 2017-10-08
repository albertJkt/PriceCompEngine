using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBase;
using System.Collections.Generic;

namespace DataBaseTest
{
    [TestClass]
    public class DBControllerTest
    {
        [TestMethod]
        public void GetProductsTest()
        {
            //arrange
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
            //act
            List<Product> retrvievedProducts = controller.GetProducts(type, shops, days);
            //assert
            Assert.IsNotNull(retrvievedProducts);
        }
    }
}
