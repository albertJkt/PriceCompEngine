
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Shoping);

            ImageButton CartBtn = FindViewById<ImageButton>(Resource.Id.cartBtn);
            CartBtn.Click += delegate 
            {
                Intent intent = new Intent(this, typeof(ShoppingCartActivity));
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
            //FillThirdList();
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
        }
        /*
        private async void FillThirdList()
        {
            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.CheapestItems);
            builder.AppendNumericArgs(new Dictionary<string, int>()
            {
                { "rows", 5 },
                { "days", 7 }
            });

            string result = await _exc.ExecuteRestGetRequest(builder);
            List<ShopItem> items = JsonConvert.DeserializeObject<List<ShopItem>>(result);

            ListView list = FindViewById<ListView>(Resource.Id.list_cheapest);
            list.Adapter = new ShopItemListAdapter(this, Resource.Id.list_cheapest, items);
        }*/
    }
}
