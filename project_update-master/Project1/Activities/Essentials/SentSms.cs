using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities.Essentials
{
    [Activity(Label = "SentSms")]
    public class SentSms : Activity
    {

        TextView phone;
        EditText message;
        ImageView back;
        Button sent;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.sentSMS);
            // Create your application here

            message = FindViewById<EditText>(Resource.Id.editText1);
            sent = FindViewById<Button>(Resource.Id.sent);
            sent.Click += Sent_Click;

            phone = FindViewById<TextView>(Resource.Id.number);
            back = (ImageView)FindViewById<ImageView>(Resource.Id.back);

            back.Click += delegate
            {
                Intent intent = new Intent(this,typeof(MainActivity2));
                StartActivity(intent);
                Finish();
            };
        }

        [Obsolete]
        private void Sent_Click(object sender, EventArgs e)
        {
            string phonenumber = phone.Text;
            string contentmessage = message.Text;
            SmsManager.Default.SendTextMessage(phonenumber, null, contentmessage, null, null);
        }
    }
}