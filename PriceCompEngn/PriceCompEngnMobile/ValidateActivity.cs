﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PriceCompEngnMobile
{
    [Activity(Label = "ValidateActivity")]
    public class ValidateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.validate);

            string previous=String.Empty;
            string result;
            var text = FindViewById<EditText>(Resource.Id.textVw);
            var validate = FindViewById<ImageButton>(Resource.Id.validateBtn);

            // get string before validation
            if(UploadActivity.items!=null){
                foreach (var item in UploadActivity.items)
                {
                    string temp = item.Type + " " + '"' + item.ItemName + '"' + " " + item.Price + " eu\n";
                    previous = String.Concat(previous, temp);
                    temp = String.Empty;
                }
                previous = TextManager.DeleteLines(previous, 1, true);
            }
                        
            DisplayItems(text);

            validate.Click+=delegate {

                result = TextManager.RemoveEndlines(text.Text);

                string pattern = " ?\" ?| *eu *";

                string[] substrings = Regex.Split(result, pattern);

                for (int i = 0; i < (substrings.Length / 3); i++)
                {
                    UploadActivity.items[i].Type = substrings[i * 3];
                    UploadActivity.items[i].ItemName = substrings[i * 3 +1];
                    UploadActivity.items[i].Price = float.Parse(substrings[i * 3 + 2]);
                }

                Thread.Sleep(500);

                var intent = new Intent(this, typeof(UploadActivity));
                StartActivity(intent);

            };



        }

        void DisplayItems(EditText x)
        {
            if (UploadActivity.items != null)
            {
                foreach (var item in UploadActivity.items)
                {
                    x.Append(item.Type + " " +'"' +item.ItemName +'"' + " " + item.Price + " eu\n");
                }

                x.Text = TextManager.DeleteLines(x.Text, 1, true);
            }
        }
    }
}