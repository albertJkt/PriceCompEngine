using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Data.SqlClient;

namespace LogicTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void Top5GoodsTest()
        {
            //arrange
            ShopGoods c = new ShopGoods();

            //act
            c.Top5Goods();
            //assert
            Assert.Fail();
        }
    }
}
