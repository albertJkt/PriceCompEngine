using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using ServiceClient;
using Newtonsoft.Json;

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

            Button add_item = FindViewById<Button>(Resource.Id.add_item);

            add_item.Click += delegate
            {
                LayoutInflater inflater = LayoutInflater.From(this);
                View promtView = inflater.Inflate(Resource.Layout.add_item_prompt, null);

                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetView(promtView);
                builder.SetCancelable(true);

                ListView searchResults = promtView.FindViewById<ListView>(Resource.Id.search_items_list);
                Button searchButton = promtView.FindViewById<Button>(Resource.Id.search_button);
                EditText searchText = promtView.FindViewById<EditText>(Resource.Id.search_items_text);

                searchButton.Click += delegate
                {
                    
                };

                AlertDialog dialog = builder.Create();
                dialog.Show();
            };
        }
    }
}

