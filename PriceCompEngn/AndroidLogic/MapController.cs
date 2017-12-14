using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;
using System.Net;
using System.IO;
using JSONResponse;
using Newtonsoft.Json;
using Android.Gms.Maps.Model;

namespace AndroidLogic
{
    public class MapController
    {
        private GoogleMap _map;

        public MapController(GoogleMap map)
        {
            _map = map;
        }

        private RootObject GetShop(int radius, string shop) {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location="
             + UserLocation.Instance.Lat + "," + UserLocation.Instance.Longt +
              "&radius=" + radius + "&type=grocery_or_supermarket|food|store&keyword=" + shop + "&key=" +
              "AIzaSyDUoIXA_z6ule8zQl5y6t_i917fs7X189A");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            var json = reader.ReadToEnd();
            RootObject result = JsonConvert.DeserializeObject<RootObject>(json);

            return result;
        }

        public void FindShops(int radius)
        {
            var rimi = GetShop(radius, "rimi");
            var norfa = GetShop(radius, "norfa");
            var iki = GetShop(radius, "iki");
            var lidl = GetShop(radius, "lidl");
            var maxima = GetShop(radius, "maxima");

            _map.Clear();
            _map.AddMarker(new MarkerOptions()
                .SetPosition(new LatLng(UserLocation.Instance.Lat, UserLocation.Instance.Longt))
                .SetTitle("Me")
                .SetSnippet("This Is Where You Are"))
                .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed));

            foreach (var place in rimi.results)
            {
                _map.AddMarker(new MarkerOptions()
                    .SetPosition(new LatLng(place.geometry.location.lat, place.geometry.location.lng))
                    .SetTitle(place.name)
                    .SetSnippet(place.vicinity)
                    .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueBlue)));
            }

            foreach (var place in norfa.results)
            {
                _map.AddMarker(new MarkerOptions()
                    .SetPosition(new LatLng(place.geometry.location.lat, place.geometry.location.lng))
                    .SetTitle(place.name)
                    .SetSnippet(place.vicinity)
                    .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueBlue)));
            }

            foreach (var place in iki.results)
            {
                _map.AddMarker(new MarkerOptions()
                    .SetPosition(new LatLng(place.geometry.location.lat, place.geometry.location.lng))
                    .SetTitle(place.name)
                    .SetSnippet(place.vicinity)
                    .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueBlue)));
            }

            foreach (var place in lidl.results)
            {
                _map.AddMarker(new MarkerOptions()
                    .SetPosition(new LatLng(place.geometry.location.lat, place.geometry.location.lng))
                    .SetTitle(place.name)
                    .SetSnippet(place.vicinity)
                    .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueBlue)));
            }

            foreach (var place in maxima.results)
            {
                _map.AddMarker(new MarkerOptions()
                    .SetPosition(new LatLng(place.geometry.location.lat, place.geometry.location.lng))
                    .SetTitle(place.name)
                    .SetSnippet(place.vicinity)
                    .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueBlue)));
            }

        }

        public void FindShops(int radius, string shopName)
        {
            var result = GetShop(radius, shopName);

            _map.Clear();
            _map.AddMarker(new MarkerOptions()
                .SetPosition(new LatLng(UserLocation.Instance.Lat, UserLocation.Instance.Longt))
                .SetTitle("Me")
                .SetSnippet("This Is Where You Are"))
                .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed));

            foreach(var place in result.results)
            {
                if (place.name.ToLower().Contains(shopName.ToLower()))
                {
                    _map.AddMarker(new MarkerOptions()
                        .SetPosition(new LatLng(place.geometry.location.lat, place.geometry.location.lng))
                        .SetTitle(place.name)
                        .SetSnippet(place.vicinity)
                        .SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueBlue)));
                }
            }
        }
    }
}