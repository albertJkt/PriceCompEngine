using System;
using System.Collections;
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

namespace PriceCompEngnMobile
{
    public class ShopItemsListFragment : ListFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_shop_cart_list, container, false);
            return view;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            try
            {
                List<KeyValuePair<string, double>> items = Arguments.GetGenericList<KeyValuePair<string, double>>("shopCartItems");
                ListAdapter = new ShopItemListAdapter(Context, Resource.Layout.fragment_shop_cart_list, items);
            }
            catch (ArgumentException)
            {
                List<KeyValuePair<string, double>> items = new List<KeyValuePair<string, double>>();
                ListAdapter = new ShopItemListAdapter(Context, Resource.Layout.fragment_shop_cart_list, items);
            }
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            ShopItemListAdapter adapter = ListAdapter as ShopItemListAdapter;
            KeyValuePair<string, double> item = adapter.Items[position];
            adapter.Items.Remove(item);

            ShoppingCartActivity activity = Activity as ShoppingCartActivity;
            activity.RecreateShopCartFragment(adapter.Items, this);
        }
    }
}