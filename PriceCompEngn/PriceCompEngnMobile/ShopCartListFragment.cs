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

namespace PriceCompEngnMobile
{
    public class ShopCartListFragment : ListFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_shop_cart_list, container, false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
        }
    }

    public class ShopCartListAdapter : ArrayAdapter
    {
        private List<Dictionary<string, string>> _objects;

        public ShopCartListAdapter(Context context, int resource, List<Dictionary<string, string>> objects)
            : base(context, resource, objects)
        {
            _objects = objects;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Dictionary<string, string> item = _objects[position];

            if (convertView == null)
            {
                convertView = LayoutInflater.From(Context).Inflate(Resource.Layout.shop_cart_list_row, parent, false);
            }

            TextView name = convertView.FindViewById<TextView>(Resource.Id.text_name);
            TextView price = convertView.FindViewById<TextView>(Resource.Id.text_price);
            TextView type = convertView.FindViewById<TextView>(Resource.Id.text_type);

            if (item.ContainsKey("ItemName") && item.ContainsKey("Price") && item.ContainsKey("Type"))
            {
                name.Text = item["ItemName"];
                price.Text = item["Price"];
                type.Text = item["Type"];
            }

            return convertView;
        }
    }
}