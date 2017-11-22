
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ServiceClient;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Media;
using Newtonsoft.Json;
using Models;

namespace PriceCompEngnMobile{
    [Activity(Label = "UploadActivity")]
    public class UploadActivity : Activity
    {
        public static readonly int PickImageId = 1000;
        string response = String.Empty;
        ImageView _imageView;

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
        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data) {  
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null)) {  
                Android.Net.Uri uri = data.Data; 

                _imageView.SetImageURI(uri);

                PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.OCR);
                RestRequestExecutor executor = new RestRequestExecutor();

                BitmapDrawable bd = (BitmapDrawable)_imageView.Drawable;
                Bitmap bitmap = bd.Bitmap;

                byte[] bitmapData;
                using (var stream = new MemoryStream())
                {
                    bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                    bitmapData = stream.ToArray();
                }
                response = await executor.ExecuteRestPostRequest(builder, bitmapData);

                PCEUriBuilder build = new PCEUriBuilder(ServiceClient.Resources.TextManager);
                builder.AppendStringArgs(new Dictionary<string, string>()
                {
                    { "imageText", response }  // raktas butinai toks turi but
                });
                RestRequestExecutor exc = new RestRequestExecutor();
                string json = await exc.ExecuteRestGetRequest(builder);

                List<ShopItem> items = JsonConvert.DeserializeObject<List<ShopItem>>(json);
            }  
        }

       
    }
}
