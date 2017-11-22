
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
    [Activity(Label = "ShopingActivity")]
    public class ShopingActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Shoping);

            var CartBtn = FindViewById<ImageButton>(Resource.Id.cartBtn);
            CartBtn.Click += delegate {
                var intent = new Intent(this, typeof(ShopingActivity));
            };

            //TODO: add navigation to GPS layout

            //TODO: add navigation to Top5 lists layout
        }
    }
}
