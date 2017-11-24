using System;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System.Threading.Tasks;

namespace AndroidLogic
{
    public class UserLocation
    {

        public double Lat { set; get; }
        public double Longt { set; get; }
        public IGeolocator locator;
        public Position location;

        private static UserLocation instance = null;
        private static readonly object padlock = new object();

        private UserLocation() { }

        public static UserLocation Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {

                        instance = new UserLocation();

                    }
                    return instance;
                }
            }
        }

        public async Task FindUserLocation()
        {
                locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;
                if (locator.IsGeolocationEnabled && locator.IsGeolocationAvailable)
                {

                    location = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                    Lat = location.Latitude;
                    Longt = location.Longitude;                   
                }            
        }
    }
}