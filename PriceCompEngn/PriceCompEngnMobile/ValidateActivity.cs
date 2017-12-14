
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Models;
using Newtonsoft.Json;
using ServiceClient;

namespace PriceCompEngnMobile
{
    [Activity(Label = "ValidateActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    public class ValidateActivity : Activity
    {
        private Analyzer _analyzer;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.validate);

            var validate = FindViewById<ImageButton>(Resource.Id.validateBtn);
            ListView list = FindViewById<ListView>(Resource.Id.analyzer_listview);

            try
            {
                string analyzerJson = Intent.GetStringExtra("response");
                _analyzer = JsonConvert.DeserializeObject<Analyzer>(analyzerJson);
                list.Adapter = new AnalyzerListAdapter(this, Resource.Id.analyzer_listview, _analyzer.ToList());
            }
            catch (JsonSerializationException)
            {
                Toast.MakeText(this, "error has occured", ToastLength.Short).Show();
            }

            validate.Click+=delegate {

                Intent resultIntent = new Intent();
                resultIntent.PutExtra("validation", JsonConvert.SerializeObject(_analyzer));
                SetResult(Result.Ok, resultIntent);
                Finish();             
            };
        }
    }
}
