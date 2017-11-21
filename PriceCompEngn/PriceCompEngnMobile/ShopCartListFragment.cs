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
        }
    }

    public class ShopCartListAdapter : ArrayAdapter
    {
        private List<ShopItem> _objects;

        public ShopCartListAdapter(Context context, int resource, List<ShopItem> objects)
            : base(context, resource, objects)
        {
            _objects = objects;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ShopItem item = _objects[position];

            if (convertView == null)
            {
                convertView = LayoutInflater.From(Context).Inflate(Resource.Layout.shop_cart_list_row, parent, false);
            }

            TextView name = convertView.FindViewById<TextView>(Resource.Id.text_name);
            TextView price = convertView.FindViewById<TextView>(Resource.Id.text_price);
            TextView type = convertView.FindViewById<TextView>(Resource.Id.text_type);

            name.Text = item.ItemName;
            price.Text = item.Price.ToString();
            type.Text = item.Type;

            return convertView;
        }
    }
}