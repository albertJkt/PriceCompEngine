
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
using System.Threading.Tasks;
using System.Threading;
using Java.Nio;
using Android.Provider;

namespace PriceCompEngnMobile{

    delegate void OnClick(object sender, EventArgs args);

    [Activity(Label = "UploadActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    public class UploadActivity : Activity
    {
        public static readonly int PickImageId = 1000;
        string response = String.Empty;
        public static List<ShopItem> items;
        ImageView _imageView;
        private byte[] bytes;
        private string _result;

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

            validateBtn.Click += delegate 
            {
                if (!string.IsNullOrEmpty(_result))
                {
                    var intent = new Intent(this, typeof(ValidateActivity));
                    intent.PutExtra("response", _result);
                    StartActivity(intent);
                }
                else
                {
                    Toast.MakeText(this, "Items were not parsed yet", ToastLength.Short).Show();
                }
            };

            uplBtn.Click +=delegate
            {
                if (!string.IsNullOrEmpty(_result))
                {
                    Analyzer analyzer = JsonConvert.DeserializeObject<Analyzer>(_result);
                    List<Item> items = new List<Item>();
                    List<Purchase> purchases = new List<Purchase>();
                    for (int i = 0; i < analyzer.ItemNames.Count; i++)
                    {
                        Item newItem = new Item()
                        {
                            Name = analyzer.ItemNames[i],
                            Price = double.Parse(analyzer.Prices[i]),
                            ShopName = analyzer.ShopName
                        };
                        items.Add(newItem);
                        Purchase newPurchase = new Purchase()
                        {
                            ItemName = analyzer.ItemNames[i],
                            ShopName = analyzer.ShopName,
                            Price = double.Parse(analyzer.PayedPrices[i]),
                            DateTime = analyzer.PurchaseTime,
                            UserName = MainMenuActivity.User.UserName
                        };
                        purchases.Add(newPurchase);
                    }
                    SavePurchases(items, purchases);
                }
                else
                {
                    Toast.MakeText(this, "No items to upload", ToastLength.Short).Show();
                }
            };
        }

        private void SavePurchases(List<Item> items, List<Purchase> purchases)
        {
            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.Items);
            RestRequestExecutor exc = new RestRequestExecutor();

            exc.ExecuteRestPostRequestTask(builder, items).Wait();

            PCEUriBuilder newBuilder = new PCEUriBuilder(ServiceClient.Resources.Purchases);

            exc.ExecuteRestPostRequest(newBuilder, purchases);
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

                Bitmap bitmap = MediaStore.Images.Media.GetBitmap(this.ContentResolver, data.Data);
                int count = bitmap.ByteCount;
                using (MemoryStream stream = new MemoryStream())
                {
                    bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                    byte[] array = stream.ToArray();
                    bytes = array;
                }

                await GetOcrText();
            }
            else if (requestCode == 1 && resultCode == Result.Ok && data != null)
            {
                _result = data.GetStringExtra("validation");
            }  
        } 

        private async Task GetOcrText()
        {
            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.OCR);
            RestRequestExecutor executor = new RestRequestExecutor();

            response = await executor.ExecuteRestPostRequest(builder, bytes);
            response = response.Replace("\\n", "\n");
            if (!string.IsNullOrEmpty(response))
            {
                var intent = new Intent(this, typeof(ValidateActivity));
                intent.PutExtra("response", response);
                StartActivityForResult(intent, 1);
            }
            else
                Toast.MakeText(this, "provided image cannot be properly processed", ToastLength.Long).Show();
        }
    }
}
