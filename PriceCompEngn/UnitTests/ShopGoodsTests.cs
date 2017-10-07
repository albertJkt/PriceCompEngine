using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBase;
using Logic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
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
