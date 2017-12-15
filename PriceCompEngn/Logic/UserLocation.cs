using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleDirections;
using System.Device.Location;

namespace Logic
{
    public sealed class UserLocation
    {
        private Geocoder Geocoder = new Geocoder(Logic.Properties.Settings.Default.userAPI);
        private GeoCoordinateWatcher Watcher { set; get; }
        private GeoCoordinate Coordinate { set; get; }
        private Dictionary<string, string> Address { set; get; }


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

        public Dictionary<string, string> GetAddress()
        {
            return Address;
        }

        public double[] GetCoordinate()
        {
            double[] latLng = { Coordinate.Latitude, Coordinate.Longitude };
            return latLng;
        }

        public void FindUserLocation()
        {

            UserLocation.Instance.Watcher = new GeoCoordinateWatcher();
            UserLocation.Instance.Coordinate = new GeoCoordinate();
            UserLocation.Instance.Watcher.StatusChanged += Watcher_StatusChanged;
            UserLocation.Instance.Watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

        }

        private void Watcher_StatusChanged(Object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                if (!UserLocation.Instance.Watcher.Position.Location.IsUnknown)
                {
                    UserLocation.Instance.Coordinate = UserLocation.Instance.Watcher.Position.Location;

                }
            }
        }

        public void FindAddress()
        {
            Address = Geocoder.ReverseGeocodeComponents(new LatLng(Coordinate.Latitude, Coordinate.Longitude));
        }
    }
}

