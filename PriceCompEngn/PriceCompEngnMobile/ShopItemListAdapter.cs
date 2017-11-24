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

namespace PriceCompEngnMobile
{
    public class ShopItemListAdapter : ArrayAdapter
    {
        public List<ShopItem> Items { get; set; }

        public ShopItemListAdapter(Context context, int resource, List<ShopItem> objects)
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