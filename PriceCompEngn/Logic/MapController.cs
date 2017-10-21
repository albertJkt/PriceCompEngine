using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Net;
using System.IO;
using JSONResponse;
using Newtonsoft.Json;

namespace Logic
{
    public class MapController
    {
        private Map _map;


        public MapController(Map map)
        {
            _map = map;
        }

        public void AddMarker(double lat, double lnt, GMarkerGoogleType type)
        {

            _map.GetMarkerOverlay().Markers.Add(new GMarkerGoogle(new PointLatLng(lat, lnt), type));
        }

        public void DisplayMap()
        {

            _map.GetGMapControl().ShowCenter = false;
            _map.GetGMapControl().MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            _map.GetGMapControl().Position = new PointLatLng(UserLocation.Instance.GetCoordinate()[0], UserLocation.Instance.GetCoordinate()[1]);

            _map.GetGMapControl().Overlays.Add(_map.GetMarkerOverlay());
            AddMarker(UserLocation.Instance.GetCoordinate()[0], UserLocation.Instance.GetCoordinate()[1], GMarkerGoogleType.red_dot);


        }

        public void ShowShops(int radius, string shop)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location="
                + UserLocation.Instance.GetCoordinate()[0] + "," + UserLocation.Instance.GetCoordinate()[1] +
                  "&radius=" + radius + "&type=grocery_or_supermarket|food|store&keyword=" + shop + "&key=" + Logic.Properties.Settings.Default.userAPI);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            var json = reader.ReadToEnd();
            RootObject result = JsonConvert.DeserializeObject<RootObject>(json);

            _map.GetMarkerOverlay().Markers.Clear();
            _map.GetGMapControl().Overlays.Clear();

            _map.GetGMapControl().Position = new PointLatLng(UserLocation.Instance.GetCoordinate()[0], UserLocation.Instance.GetCoordinate()[1]);
            _map.GetGMapControl().Overlays.Add(_map.GetMarkerOverlay());

            for (var i = 0; i < result.results.Count(); i++)
            {
                if (result.results[i].name.ToLower().Contains(shop))
                {

                    AddMarker(result.results[i].geometry.location.lat, result.results[i].geometry.location.lng, GMarkerGoogleType.blue_dot);
                }
            }

            AddMarker(UserLocation.Instance.GetCoordinate()[0], UserLocation.Instance.GetCoordinate()[1], GMarkerGoogleType.red_dot);
        }

        public void ShowShops(int radius)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location="
                + UserLocation.Instance.GetCoordinate()[0] + "," + UserLocation.Instance.GetCoordinate()[1] +
                  "&radius=" + radius + "&type=grocery_or_supermarket|food|store&keyword=rimi|norfa|iki|maxima&key=" + Logic.Properties.Settings.Default.userAPI);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            var json = reader.ReadToEnd();
            RootObject result = JsonConvert.DeserializeObject<RootObject>(json);


            _map.GetMarkerOverlay().Markers.Clear();
            _map.GetGMapControl().Overlays.Clear();

            _map.GetGMapControl().Overlays.Add(_map.GetMarkerOverlay());
            _map.GetGMapControl().Position = new PointLatLng(UserLocation.Instance.GetCoordinate()[0], UserLocation.Instance.GetCoordinate()[1]);

            for (var i = 0; i < result.results.Count(); i++)
            {
                if (result.results[i].name.ToLower().Contains("rimi") ||
                   result.results[i].name.ToLower().Contains("norfa") ||
                   result.results[i].name.ToLower().Contains("iki") ||
                   result.results[i].name.ToLower().Contains("maxima"))
                {
                    AddMarker(result.results[i].geometry.location.lat, result.results[i].geometry.location.lng, GMarkerGoogleType.blue_dot);
                }
            }
            AddMarker(UserLocation.Instance.GetCoordinate()[0], UserLocation.Instance.GetCoordinate()[1], GMarkerGoogleType.red_dot);

        }

    }
}
