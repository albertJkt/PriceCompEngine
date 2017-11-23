
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

namespace PriceCompEngnMobile
{
    [Activity(Label = "CSE", Icon = "@drawable/logo", MainLauncher = true, Theme = "@android:style/Theme.Holo.NoActionBar.Fullscreen")]
    public class MainMenuActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Main);

            var ScanBtn = FindViewById<ImageButton>(Resource.Id.scan);

            ScanBtn.Click += delegate {
                var intent = new Intent(this, typeof(UploadActivity));
                StartActivity(intent);
            };

            var ShopBtn = FindViewById<ImageButton>(Resource.Id.shop);

            ShopBtn.Click += delegate {
                var intent = new Intent(this, typeof(ShoppingCartActivity));
                StartActivity(intent);
            };
        }


    }
}
