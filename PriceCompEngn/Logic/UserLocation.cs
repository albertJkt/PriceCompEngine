using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleDirections;
using System.Device.Location;

namespace Logic
{
    public sealed class UserLocation
    {
        private Geocoder geocoder = new Geocoder(Logic.Properties.Settings.Default.userAPI);
        public GeoCoordinateWatcher watcher { set; get; }
        public GeoCoordinate coordinate { set; get; }


        private static UserLocation instance = null;
        private static readonly object padlock = new object();

        private UserLocation()
        {

        }

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

        public Dictionary<string, string> ReverseGeocode()
        {
            return geocoder.ReverseGeocodeComponents(new LatLng(coordinate.Latitude, coordinate.Longitude));
        }
    }
}

