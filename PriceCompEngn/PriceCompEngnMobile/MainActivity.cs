using Android.App;
using Android.Widget;
using Android.OS;
using ServiceClient;

namespace PriceCompEngnMobile
{
    [Activity(Label = "PriceCompEngnMobile", MainLauncher = true, Theme = "@android:style/Theme.DeviceDefault.Light")]
    public class MainActivity : Activity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.rest_test);

            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.ShopItems);
            RestRequestExecutor executor = new RestRequestExecutor();

            TextView view = FindViewById<TextView>(Resource.Id.test_text_view);
            view.Text = await executor.ExecuteRestGetRequest(builder);
        }
    }
}

