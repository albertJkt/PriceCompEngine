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
    class TopFiveListAdapter : ArrayAdapter
    {
        private Dictionary<string, int> _content;

        public TopFiveListAdapter(Context context, int resource, Dictionary<string, int> content) 
            : base(context, resource)
        {
            _content = content;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = LayoutInflater.From(Context).Inflate(Resource.Layout.top_5_list_row, parent, false);
            }

            TextView name = convertView.FindViewById<TextView>(Resource.Id.item_name);
            TextView number = convertView.FindViewById<TextView>(Resource.Id.item_purchase_times);

            name.Text = _content.Keys.ElementAt(position);
            number.Text = _content.Values.ElementAt(position).ToString() + " pirkimu";

            return convertView;
        }
    }
}