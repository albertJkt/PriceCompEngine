using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceClient;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Models;

namespace PriceCompEngnMobile
{
    [Activity(Label = "CSE", Icon = "@drawable/logo", MainLauncher = true, Theme = "@android:style/Theme.Holo.NoActionBar")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.login);

            var logBtn = FindViewById<ImageButton>(Resource.Id.login);
            var regBtn = FindViewById<ImageButton>(Resource.Id.register);

            regBtn.Click += delegate {
                var intent = new Intent(this,typeof(RegisterActivity));
                StartActivity(intent);
            };

            logBtn.Click += ButtonOnClick;
        }

        async void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            string Username = FindViewById<EditText>(Resource.Id.userTxt).Text;
            string Password = FindViewById<EditText>(Resource.Id.passwordTxt).Text;

            RestRequestExecutor executor = new RestRequestExecutor();
            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.User);
            builder.AppendStringArgs(new Dictionary<string, string>()
                {
                    { "UserName", Username},
                    { "Password", Password},
                    { "Email",null}
                });

            string result = await executor.ExecuteRestGetRequest(builder);

            User user = JsonConvert.DeserializeObject<User>(result);

            if (user != null)
            {
                var intent = new Intent(this, typeof(MainMenuActivity));

                intent.PutExtra("user", result);
                StartActivity(intent);
                Finish();
            }
            else
            {
                Toast.MakeText(this, "Incorrect login credentials!", ToastLength.Long).Show();
            }
        }
    }
}
