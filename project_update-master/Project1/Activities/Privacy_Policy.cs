using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities
{
    [Activity(Label = "Privacy_Policy")]
    public class Privacy_Policy : Activity
    {
        ImageView backButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_privacy_policy);

            backButton = FindViewById<ImageView>(Resource.Id.backButton);

            backButton.Click += BackButton_Click;



            // Create your application here
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
        }
    }
}