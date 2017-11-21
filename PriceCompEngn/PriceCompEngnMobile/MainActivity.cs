using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using ServiceClient;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Models;
using System.Linq;

namespace PriceCompEngnMobile
{
    [Activity(Label = "PriceCompEngnMobile", MainLauncher = true, Theme = "@android:style/Theme.DeviceDefault.Light")]
    public class MainActivity : Activity
    {
        private List<ShopItem> _args = new List<ShopItem>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Bundle state = new Bundle();
            OnSaveInstanceState(state);

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
                    PCEUriBuilder uriBuilder = new PCEUriBuilder(ServiceClient.Resources.ShopItems);
                    uriBuilder.AppendStringArgs(new Dictionary<string, string>()
                    {
                        { "itemName", searchText.Text }
                    });
                    uriBuilder.AppendArrayArgs("shops", new string[]
                    {
                        "rimi",
                        "maxima",
                        "iki",
                        "norfa",
                        "lidl"
                    });
                    ExecuteSearchAsync(searchResults, uriBuilder);
                };

                AlertDialog dialog = builder.Create();
                dialog.Show();

                searchResults.ItemClick += delegate
                {
                    ShopCartListAdapter adapter = searchResults.Adapter as ShopCartListAdapter;
                    ShopItem item = adapter.GetItemByIndex(0);
                    _args.Add(item);


                    Bundle args = new Bundle();
                    args.PutGenericList("shopCartItems", _args);

                    Fragment fragment = new ShopCartListFragment
                    {
                        Arguments = args
                    };

                    FragmentTransaction transaction = FragmentManager.BeginTransaction();
                    transaction.Replace(Resource.Id.shop_cart_fragment_container, fragment);

                    transaction.Commit();
                    dialog.Dismiss();
                };

                ImageButton compare = FindViewById<ImageButton>(Resource.Id.compare_button);
                compare.Click += delegate
                {

                };
            };
        }

        private async void ExecuteSearchAsync(ListView searchResults, PCEUriBuilder uriBuilder)
        {
            RestRequestExecutor executor = new RestRequestExecutor();

            string jsonString = await executor.ExecuteRestGetRequest(uriBuilder);

            List<ShopItem> items = JsonConvert.DeserializeObject<List<ShopItem>>(jsonString);
 
            ShopItem averagePriceItem = items.First();
            averagePriceItem.Price = items.Average(item => item.Price);
            List<ShopItem> toDisplay = new List<ShopItem>()
            {
                averagePriceItem
            };

            ShopCartListAdapter adapter = new ShopCartListAdapter(this, Resource.Id.search_items_list, toDisplay);

            searchResults.Adapter = adapter;
        }
    }
}

