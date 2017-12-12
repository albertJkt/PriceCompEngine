
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
    [Activity(Label = "CSE", Icon = "@drawable/logo", MainLauncher = true, Theme = "@android:style/Theme.Holo.NoActionBar")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.login);

            var regBtn = FindViewById<ImageButton>(Resource.Id.register);

            regBtn.Click += delegate {
                var intent = new Intent(this,typeof(RegisterActivity));
                StartActivity(intent);
            };
        }
    }
}
