
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ServiceClient;
using Models;

namespace PriceCompEngnMobile
{
    [Activity(Label = "RegisterActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    public class RegisterActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.register);

            var username = FindViewById<ImageButton>(Resource.Id.regBtn);

            username.Click += ButtonOnClick;

        }

        async void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            string Username = FindViewById<EditText>(Resource.Id.usernameTxt).Text;
            string Password1 = FindViewById<EditText>(Resource.Id.pw1Txt).Text;
            string Password2 = FindViewById<EditText>(Resource.Id.pw2Txt).Text;
            string Email = FindViewById<EditText>(Resource.Id.emailTxt).Text;

            PCEUriBuilder builder = new PCEUriBuilder(ServiceClient.Resources.User);
            builder.AppendStringArgs(new Dictionary<string, string>()
                {
                    { "UserName", Username},
                    { "Password", null},
                    { "Email",Email}
                });
            
            RestRequestExecutor executor = new RestRequestExecutor();
            string result = await executor.ExecuteRestGetRequest(builder);

            User user = JsonConvert.DeserializeObject<User>(result);

            if (user!= null)
            {
                if (Password1.Length>=6)
                {
                    if (Password1.Equals(Password2))
                    {
                        if (IsValidEmail(Email))
                        {
                            User useris = new User();
                            useris.Email = Email;
                            useris.Password = Password1;
                            useris.UserName = Username;

                            PCEUriBuilder bldr = new PCEUriBuilder(ServiceClient.Resources.User);
                            RestRequestExecutor ex = new RestRequestExecutor();
                            ex.ExecuteRestPostRequest(bldr,useris);
                            Finish();
                        }
                        else
                        {
                            Toast.MakeText(this, "Please, enter valid email address!", ToastLength.Short).Show();
                        }
                    }
                    else
                    {
                        Toast.MakeText(this, "Passwords don't match!", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "Your password must contain at least 6 symbols!", ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "User with selected username and email already exists!", ToastLength.Long).Show();
            }

        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
