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
            for (int  i = 0; i < collection.Count(); i++)
            {
                string objectSpecificKey = key + i;
                bundle.PutString(objectSpecificKey, JsonConvert.SerializeObject(collection[i]));
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
            while (bundle.ContainsKey(objectSpecificKey))
            {
                string jsonString = bundle.GetString(objectSpecificKey);
                list.Add(JsonConvert.DeserializeObject<T>(jsonString));
                objectSpecificKey = key + ++index;
            } 

            return list;
        }
    }
}