using Android.App;
using Android.Widget;
using Android.OS;

namespace PriceCompEngnMobile
{
    [Activity(Label = "PriceCompEngnMobile", MainLauncher = true, Theme = "@android:style/Theme.DeviceDefault.Light")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_shopcart);
        }
    }
}

