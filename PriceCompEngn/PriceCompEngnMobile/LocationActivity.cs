using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using ServiceClient;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Models;
using System.Linq;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

using AndroidLogic;
using System.Text.RegularExpressions;

namespace PriceCompEngnMobile
{
    [Activity(Label = "LocationActivity", Theme = "@android:style/Theme.DeviceDefault.Light")]
    public class LocationActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap _map;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Bundle state = new Bundle();
            OnSaveInstanceState(state);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.map);
            EditText radiusText = FindViewById<EditText>(Resource.Id.radiusText);
            EditText shopText = FindViewById<EditText>(Resource.Id.shopText);
            ImageButton around_me = FindViewById<ImageButton>(Resource.Id.around_me);
            SetUpMapAsync();
          

            around_me.Click += delegate
            {
                if(!string.IsNullOrEmpty(shopText.Text) &&
                Regex.Match(shopText.Text, @"^([rimi]|[norfa]|[iki]|[maxima]|[lidl])", RegexOptions.IgnoreCase).Success &&
                Regex.Match(radiusText.Text, @"^(([1-4][0-9]{0,3})|([1-9][0-9]{0,2})|(5000))$").Success)
                {
                    new MapController(_map).FindShops(Convert.ToInt32(radiusText.Text), shopText.Text);
                    return;
                }
                if (string.IsNullOrEmpty(shopText.Text) && Regex.Match(radiusText.Text, @"^(([1-4][0-9]{0,3})|([1-9][0-9]{0,2})|(5000))$").Success)
                {
                    new MapController(_map).FindShops(Convert.ToInt32(radiusText.Text));
                    return;
                }              
                Toast.MakeText(this, "Please put in the desired radius and shop name (optional) correctly", ToastLength.Long).Show();                 
            };
        }

        private async void SetUpMapAsync()
        {
            if (_map == null)
            {

                if (UserLocation.Instance.Lat == 0 && UserLocation.Instance.Longt == 0)
                {
                    await UserLocation.Instance.FindUserLocation();
                }
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;
            _map.SetMaxZoomPreference(20);

            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(new LatLng(UserLocation.Instance.Lat,
                UserLocation.Instance.Longt), 15);
            _map.MoveCamera(camera);

            LatLng latlng = new LatLng(UserLocation.Instance.Lat, UserLocation.Instance.Longt);

            MarkerOptions options = new MarkerOptions()
                .SetPosition(latlng)
                .SetTitle("Me")
                .SetSnippet("This Is Where You Are");
            _map.AddMarker(options);
                        
            _map.MarkerClick += _map_MarkerClick;
        }

        private void _map_MarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
        {
            _map.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(e.Marker.Position, 15));
            e.Marker.ShowInfoWindow();           
        }
    }
}
