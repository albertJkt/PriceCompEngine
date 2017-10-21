using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Device.Location;
using System.Threading;

namespace LogicTests
{
    [TestClass]
    public class UserLocationTest
    {
        [TestMethod]
        public void UserCoordinatesTest()
        {

            UserLocation ul = UserLocation.Instance;

            ThreadStart threaddelegate = new ThreadStart(ul.FindUserLocation);
            Thread ulThread = new Thread(threaddelegate);

            ulThread.Start();
            ulThread.Join();

            Thread test = new Thread(new ThreadStart(ul.FindAddress));
            test.Start();
            test.Join();

            //Assert.AreEqual("Vilnius",ul.GetAddress()["locality"]);

        }
    }
}