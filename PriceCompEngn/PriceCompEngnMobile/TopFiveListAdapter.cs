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

namespace PriceCompEngnMobile
{
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
    using Java.Lang;

    namespace PriceCompEngnMobile
    {
        class TopFiveListAdapter : ArrayAdapter
        {
            private List<KeyValuePair<string, int>> _content;

            public TopFiveListAdapter(Context context, int resource, List<KeyValuePair<string, int>> content)
                : base(context, resource, content)
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

                name.Text = _content.ElementAt(position).Key;
                number.Text = _content.ElementAt(position).Value + " pirkimu";

                return convertView;
            }
        }
    }
}