using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace LogicTests
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
