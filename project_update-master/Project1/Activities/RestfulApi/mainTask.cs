using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities.RestfulApi
{
    [Activity(Label = "mainTask")]
    public class mainTask : Activity
    {
        ImageView backButton;
        CardView cardView2, cardView1, cardView4;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.mainTasks);

            // Create your application here


            backButton = (ImageView)FindViewById(Resource.Id.backButton);
            cardView1 = (CardView)FindViewById(Resource.Id.cardView1);
            cardView1.Click += CardView1_Click;
            cardView2 = (CardView)FindViewById(Resource.Id.cardView2);

            cardView2.Click += CardView2_Click;
            cardView4 = (CardView)FindViewById(Resource.Id.cardView4);
            cardView4.Click += CardView4_Click;

            backButton.Click += delegate
            {
                StartActivity(new Intent(this, typeof(MainActivity2)));
            };


        }

        private void CardView4_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(DeleteTasks)));
        }

        private void CardView1_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(UpdateTasks)));
        }

        private void CardView2_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(AddTasks)));
        }
    }
}