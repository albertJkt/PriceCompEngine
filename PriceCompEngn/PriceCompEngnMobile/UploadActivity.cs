
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

namespace PriceCompEngnMobile{
    [Activity(Label = "UploadActivity")]
    public class UploadActivity : Activity
    {
        public delegate void MyDelegate(object sender, EventArgs ea);
        public static readonly int PickImageId = 1000;
        ImageView _imageView;
        EventArgs argg = new EventArgs();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Upload);

            var addBtn = FindViewById<ImageButton>(Resource.Id.addBtn);
            var validateBtn = FindViewById<ImageButton>(Resource.Id.validBtn);
            var uplBtn = FindViewById<ImageButton>(Resource.Id.uploadBtn);
            _imageView = FindViewById<ImageView>(Resource.Id.imgView);

            addBtn.Click += ButtonOnClick;
        }

        void ButtonOnClick(object sender, EventArgs eventArgs)
        {  
            var intent = new Intent();  
            intent.SetType("image/*");  
            intent.SetAction(Intent.ActionGetContent);  
            StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), PickImageId);  
        } 
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) {  
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null)) {  
                Android.Net.Uri uri = data.Data;  
                _imageView.SetImageURI(uri);  

            }  
        }  
    }
}
