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
    public class ShopCartListFragment : ListFragment
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
                List<ShopItem> items = Arguments.GetGenericList<ShopItem>("shopCartItems");
                ListAdapter = new ShopCartListAdapter(Context, Resource.Layout.fragment_shop_cart_list, items);
            } 
            catch (ArgumentException)
            {
                List<ShopItem> items = new List<ShopItem>();
                ListAdapter = new ShopCartListAdapter(Context, Resource.Layout.fragment_shop_cart_list, items);
            }
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);

            ShopCartListAdapter adapter = ListAdapter as ShopCartListAdapter;
            ShopItem item = adapter.Items[position];
            adapter.Items.Remove(item);

            MainActivity activity = Activity as MainActivity;
            activity.RecreateShopCartFragment(adapter.Items, this);
        }
    }

    public class ShopCartListAdapter : ArrayAdapter
    {
        public List<ShopItem> Items { get; set; }

        public ShopCartListAdapter(Context context, int resource, List<ShopItem> objects)
            : base(context, resource, objects)
        {
            Items = objects;
        }

        public ShopItem GetItemByIndex(int index)
        {
            return Items[index];
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ShopItem item = Items[position];

            if (convertView == null)
            {
                convertView = LayoutInflater.From(Context).Inflate(Resource.Layout.shop_cart_list_row, parent, false);
            }

            TextView name = convertView.FindViewById<TextView>(Resource.Id.text_name);
            TextView price = convertView.FindViewById<TextView>(Resource.Id.text_price);
            TextView type = convertView.FindViewById<TextView>(Resource.Id.text_type);

            name.Text = item.ItemName;
            price.Text = item.Price.ToString("0.00 €");
            type.Text = item.Type;

            return convertView;
        }
    }
}