using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Device.Location;
using System.Collections.Generic;

namespace LogicTests
{
    [TestClass]
    public class UserLocationTest
    {
        [TestMethod]
        public void ReverseGeocodeTest()
        {

            UserLocation address = UserLocation.Instance;
            UserLocation.Instance.watcher = new GeoCoordinateWatcher();
            UserLocation.Instance.coordinate = new GeoCoordinate();

            UserLocation.Instance.watcher.StatusChanged += watcher_StatusChanged;
            UserLocation.Instance.watcher.TryStart(false, TimeSpan.FromSeconds(5));



            while (UserLocation.Instance.watcher.Status != GeoPositionStatus.Ready)
            {

            }


            var city = address.ReverseGeocode();
            Assert.IsNotNull(city);


        }

        private void watcher_StatusChanged(Object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Initializing:
                    Console.WriteLine("Working on location fix");

                    break;

                case GeoPositionStatus.Ready:
                    UserLocation.Instance.coordinate = UserLocation.Instance.watcher.Position.Location;
                    break;

                case GeoPositionStatus.NoData:
                    Console.WriteLine("No data");
                    break;

                case GeoPositionStatus.Disabled:
                    Console.WriteLine("Disabled");
                    break;
            }
        }
    }
}
