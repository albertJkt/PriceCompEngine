
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
using Models;
using ServiceClient;
using Newtonsoft.Json;
using PriceCompEngnMobile.PriceCompEngnMobile;

namespace PriceCompEngnMobile
{
    [Activity(Label = "ShopingActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    public class ShoppingActivity : Activity
    {
        private RestRequestExecutor _exc = new RestRequestExecutor();
        private List<string> shopCartItems = new List<string>(); 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Shoping);

            ImageButton CartBtn = FindViewById<ImageButton>(Resource.Id.cartBtn);
            CartBtn.Click += delegate 
            {
                Intent intent = new Intent(this, typeof(ShoppingCartActivity));
                intent.PutExtra("selectedTopItems", shopCartItems.ToArray());
                shopCartItems = new List<string>();
                StartActivity(intent);
            };

            ImageButton LocationBtn = FindViewById<ImageButton>(Resource.Id.locationBtn);
            LocationBtn.Click +=  delegate
            {
                Intent intent = new Intent(this, typeof(LocationActivity));
                StartActivity(intent);
            };

            FillFirstList();
            FillSecondList();
            FillThirdList();
        }

        private async void FillFirstList()
        {
            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.TopItems);
            builder.AppendNumericArgs(new Dictionary<string, int>()
            {
                { "rows", 5 },
                { "days", 7 }
            });

            string result = await _exc.ExecuteRestGetRequest(builder);
            Dictionary<string, int> topItems = JsonConvert.DeserializeObject<Dictionary<string, int>>(result);
            List<KeyValuePair<string, int>> entryList = topItems.ToList();

            ListView list = FindViewById<ListView>(Resource.Id.list_pop_week);
            list.Adapter = new TopFiveListAdapter(this, Resource.Id.list_pop_week, entryList);

            OnNonShopListItemClick(list);
        }

        private async void FillSecondList()
        {
            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.TopItems);
            builder.AppendNumericArgs(new Dictionary<string, int>()
            {
                { "rows", 5 }
            });

            string result = await _exc.ExecuteRestGetRequest(builder);
            Dictionary<string, int> topItems = JsonConvert.DeserializeObject<Dictionary<string, int>>(result);
            List<KeyValuePair<string, int>> entryList = topItems.ToList();

            ListView list = FindViewById<ListView>(Resource.Id.list_pop_alltime);
            list.Adapter = new TopFiveListAdapter(this, Resource.Id.list_pop_week, entryList);

            OnNonShopListItemClick(list);
        }
        
        private async void FillThirdList()
        {
            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.TopShops);
            builder.AppendNumericArgs(new Dictionary<string, int>()
            {
                { "days", 7 }
            });

            string result = await _exc.ExecuteRestGetRequest(builder);
            Dictionary<string, int> topShops = JsonConvert.DeserializeObject<Dictionary<string, int>>(result);
            List<KeyValuePair<string, int>> entryList = topShops.ToList();

            ListView list = FindViewById<ListView>(Resource.Id.list_shops);
            list.Adapter = new TopFiveListAdapter(this, Resource.Id.list_shops, entryList);
        }

        private void OnNonShopListItemClick(ListView list)
        {
            list.ItemClick += (o, e) =>
            {
                View promptView = LayoutInflater.From(this).Inflate(Resource.Layout.top_item_add_prompt, null);
                AlertDialog.Builder scItemAddBuilder = new AlertDialog.Builder(this);
                scItemAddBuilder.SetView(promptView);
                scItemAddBuilder.SetCancelable(false);

                AlertDialog dialog = scItemAddBuilder.Create();
                dialog.Show();

                Button ok = promptView.FindViewById<Button>(Resource.Id.promt_confirm_add_item);
                Button cancel = promptView.FindViewById<Button>(Resource.Id.promt_cancel_adding);

                ok.Click += delegate
                {
                    TopFiveListAdapter adapter = list.Adapter as TopFiveListAdapter;
                    string selection = adapter.GetEntry(e.Position).Key;
                    shopCartItems.Add(selection);

                    Toast.MakeText(this, "Item added to cart", ToastLength.Short).Show();
                    dialog.Dismiss();
                };

                cancel.Click += delegate
                {
                    dialog.Dismiss();
                };
            };
        }
    }
}
