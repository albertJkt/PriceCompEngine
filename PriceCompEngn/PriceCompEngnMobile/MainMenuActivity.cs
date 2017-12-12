
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
using AndroidLogic;

namespace PriceCompEngnMobile
{
    [Activity(Label = "CSE", MainLauncher = false, Theme = "@android:style/Theme.Holo.NoActionBar")]
    public class MainMenuActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Main);
            StartMonitoringLocation();
            var ScanBtn = FindViewById<ImageButton>(Resource.Id.scan);

            ScanBtn.Click += delegate 
            {
                var intent = new Intent(this, typeof(UploadActivity));
                StartActivity(intent);
            };

            var ShopBtn = FindViewById<ImageButton>(Resource.Id.shop);

            ShopBtn.Click += delegate 
            {

                var intent = new Intent(this, typeof(ShoppingActivity));
                StartActivity(intent);
            };
        }

        private async void StartMonitoringLocation()
        {
            if (UserLocation.Instance.Lat == 0 && UserLocation.Instance.Longt == 0)
            {
                await UserLocation.Instance.FindUserLocation();
            }
        }
    }

}
