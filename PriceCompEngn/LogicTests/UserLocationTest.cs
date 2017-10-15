using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Device.Location;

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
           // UserLocation.Instance.watcher.StatusChanged += watcher_StatusChanged;
            UserLocation.Instance.watcher.TryStart(true, TimeSpan.FromMilliseconds(1000));

            /* private void watcher_StatusChanged(Object sender, GeoPositionStatusChangedEventArgs e)
             {
                 if (e.Status == GeoPositionStatus.Ready)
                 {
                     if (UserLocation.Instance.watcher.Position.Location.IsUnknown)
                     {

                     }
                     else
                     {
                         UserLocation.Instance.coordinate = UserLocation.Instance.watcher.Position.Location;
                     }
                 }
             }*/


            UserLocation.Instance.coordinate = UserLocation.Instance.watcher.Position.Location;
            var city = address.ReverseGeocode();
        }
    }
}
