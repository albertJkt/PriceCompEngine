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
    [Activity(Label = "PriceCompEngnMobile", MainLauncher = false, Theme = "@android:style/Theme.DeviceDefault.Light")]
    public class ShoppingCartActivity : Activity
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
                    ShopItemListAdapter adapter = searchResults.Adapter as ShopItemListAdapter;
                    ShopItem item = adapter.GetItemByIndex(0);
                    _args.Add(item);


                    Bundle args = new Bundle();
                    args.PutGenericList("shopCartItems", _args);

                    Fragment fragment = new ShopItemsListFragment
                    {
                        Arguments = args
                    };

                    FragmentTransaction transaction = FragmentManager.BeginTransaction();
                    transaction.Replace(Resource.Id.shop_cart_fragment_container, fragment);

                    transaction.Commit();
                    dialog.Dismiss();
                };
            };

            ImageButton compare_prices = FindViewById<ImageButton>(Resource.Id.compare_button);
            compare_prices.Click += delegate
            {
                string[] selectedShops = GetMarkedShops();
                string[] selectedItems = GetItemNames();

                PCEUriBuilder uriBuilder = new PCEUriBuilder(ServiceClient.Resources.ShoppingCart);
                uriBuilder.AppendArrayArgs("shops", selectedShops);
                uriBuilder.AppendArrayArgs("items", selectedItems);

                TextView firstRow = FindViewById<TextView>(Resource.Id.result_text_row1);
                TextView secondRow = FindViewById<TextView>(Resource.Id.result_text_row2);
                TextView thirdRow = FindViewById<TextView>(Resource.Id.result_text_row3);

                ExecuteComparisonAsync(uriBuilder, firstRow, secondRow, thirdRow);
            };
        }

        private async void ExecuteComparisonAsync(PCEUriBuilder builder, TextView row1, TextView row2, TextView row3)
        {
            RestRequestExecutor executor = new RestRequestExecutor();

            string jsonResponse = await executor.ExecuteRestGetRequest(builder);

            ShoppingCart cart = JsonConvert.DeserializeObject<ShoppingCart>(jsonResponse);

            row1.Text = "Pigiausia: " + cart.BestShop + " parduotuveje";
            row2.Text = "Kaina parduotuveje " + cart.BestShop + ": " + cart.LowestPrice.ToString("0.00 €");
            row3.Text = "Vidutine kaina kitur: " + cart.AveragePrice.ToString("0.00 €");
        }

        private string[] GetItemNames()
        {
            List<string> itemNames = new List<string>();
            foreach (ShopItem item in _args)
            {
                itemNames.Add(item.ItemName);
            }
            string[] itemNamesArray = itemNames.ToArray();
            return itemNamesArray;
        }

        private string[] GetMarkedShops()
        {
            CheckBox[] checkBoxes = new CheckBox[]
            {
                FindViewById<CheckBox>(Resource.Id.checkbox_rimi),
                FindViewById<CheckBox>(Resource.Id.checkbox_maxima),
                FindViewById<CheckBox>(Resource.Id.checkbox_norfa),
                FindViewById<CheckBox>(Resource.Id.checkbox_lidl),
                FindViewById<CheckBox>(Resource.Id.checkbox_iki)
            };

            List<string> shopNames = new List<string>();
            foreach (CheckBox box in checkBoxes)
            {
                if (box.Checked)
                {
                    shopNames.Add(box.Text.ToLower());
                }
            }
            string[] result = shopNames.ToArray();
            return result;
        }

        private async void ExecuteSearchAsync(ListView searchResults, PCEUriBuilder uriBuilder)
        {
            RestRequestExecutor executor = new RestRequestExecutor();

            string jsonString = await executor.ExecuteRestGetRequest(uriBuilder);

            List<ShopItem> items = JsonConvert.DeserializeObject<List<ShopItem>>(jsonString);

            if (items != null && items.Count > 0)
            {
                ShopItem averagePriceItem = items.First();
                averagePriceItem.Price = items.Average(item => item.Price);
                List<ShopItem> toDisplay = new List<ShopItem>()
                {
                    averagePriceItem
                };

                ShopItemListAdapter adapter = new ShopItemListAdapter(this, Resource.Id.search_items_list, toDisplay);

                searchResults.Adapter = adapter;
            }
            else Toast.MakeText(this, "The item you're searching for can't be found", ToastLength.Long).Show();
        }


        public void RecreateShopCartFragment(List<ShopItem> listItems, Fragment fragment)
        {
            _args = new List<ShopItem>(listItems);
            Bundle arguments = new Bundle();
            arguments.PutGenericList("shopCartItems", _args);

            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Remove(fragment);
            Fragment newFragment = new ShopItemsListFragment
            {
                Arguments = arguments
            };

            transaction.Replace(Resource.Id.shop_cart_fragment_container, newFragment);
            transaction.Commit();
        }
    }
}

