
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

        protected override void OnCreate(Bundle savedInstanceState)
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
            }
            catch (JsonSerializationException)
            {
                Toast.MakeText(this, "error has occured", ToastLength.Short).Show();
            }

            list.Adapter = new AnalyzerListAdapter(this, Resource.Id.analyzer_listview, _analyzer.ToList());
            list.ItemClick += (o, e) =>
            {
                AnalyzerListAdapter adapter = list.Adapter as AnalyzerListAdapter;
                AnalyzerEntry entry = adapter.GetItem(e.Position);

                View promptView = LayoutInflater.From(this).Inflate(Resource.Layout.validation_prompt, null);

                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetView(promptView);
                builder.SetCancelable(true);

                EditText name = promptView.FindViewById<EditText>(Resource.Id.edit_item_name);
                EditText price = promptView.FindViewById<EditText>(Resource.Id.edit_item_price);
                EditText payedPrice = promptView.FindViewById<EditText>(Resource.Id.edit_item_payedprice);

                name.Text = entry.ItemName;
                price.Text = entry.Price;
                payedPrice.Text = entry.PayedPrice;

                AlertDialog dialog = builder.Create();
                dialog.Show();

                Button confirm = promptView.FindViewById<Button>(Resource.Id.edit_confirm);
                confirm.Click += delegate
                {
                    AnalyzerEntry newEntry = new AnalyzerEntry()
                    {
                        ItemName = name.Text,
                        Price = price.Text,
                        PayedPrice = payedPrice.Text,
                    };
                    List<AnalyzerEntry> newEntries = new List<AnalyzerEntry>(adapter.GetItems())
                    {
                        [e.Position] = newEntry
                    };
                    list.Adapter = new AnalyzerListAdapter(this, Resource.Id.analyzer_listview, newEntries);

                    dialog.Dismiss();
                };
            };

            validate.Click += delegate 
            {
                AnalyzerListAdapter adapter = list.Adapter as AnalyzerListAdapter;
                Analyzer analyzer = new Analyzer(adapter.GetItems())
                {
                    ShopName = _analyzer.ShopName,
                    PurchaseTime = _analyzer.PurchaseTime
                };
                _analyzer = analyzer;
                Intent resultIntent = new Intent();
                resultIntent.PutExtra("validation", JsonConvert.SerializeObject(_analyzer));
                SetResult(Result.Ok, resultIntent);
                Finish();             
            };
        }
    }
}
