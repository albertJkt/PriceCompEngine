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
using Newtonsoft.Json;

namespace PriceCompEngnMobile
{
    public static class BundleExtensions
    {
        public static void PutGenericList<T>(this Bundle bundle, string key, List<T> collection)
        {
            IEnumerator<T> enumerator = collection.GetEnumerator();

            for (int  i = 0; i < collection.Count(); i++)
            {
                string objectSpecificKey = key + i;
                bundle.PutString(objectSpecificKey, JsonConvert.SerializeObject(enumerator.Current));
                enumerator.MoveNext();
            }
        }

        public static List<T> GetGenericList<T>(this Bundle bundle, string key)
        {
            if (!bundle.ContainsKey(key + 0))
            {
                throw new ArgumentException("Provided argument key doesn't exist");
            }

            List<T> list = new List<T>();

            int index = 0;
            string objectSpecificKey = key + index;
            do
            {
                string jsonString = bundle.GetString(objectSpecificKey);
                list.Add(JsonConvert.DeserializeObject<T>(jsonString));
                objectSpecificKey = key + ++index;
            } while (!bundle.ContainsKey(objectSpecificKey));

            return list;
        }
    }
}