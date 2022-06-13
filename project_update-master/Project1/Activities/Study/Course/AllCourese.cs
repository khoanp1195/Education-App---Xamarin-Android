using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Project1.Acitivties.Study;
using Project1.Activities.Study.EnglishDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities.Study.Course
{
    [Activity(Label = "AllCourese")]
    public class AllCourese : Activity
    {

        CardView relativeLayout1, relativeLayout2, relativeLayout3, relativeLayout4;
        ImageView backButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.acitivity_study);


            // Create your application here
            //  relativeLayout1 = (RelativeLayout)view.FindViewById(Resource.Id.relativeLayout1);



            relativeLayout2 = (CardView)FindViewById(Resource.Id.relativeLayout2);

            relativeLayout2.Click += RelativeLayout2_Click;



            backButton = (ImageView)FindViewById(Resource.Id.backButton);
            backButton.Click += BackButton_Click;


            relativeLayout3 = (CardView)FindViewById(Resource.Id.relativeLayout3);
            relativeLayout3.Click += RelativeLayout3_Click;


            relativeLayout4 = (CardView)FindViewById(Resource.Id.relativeLayout4);
            relativeLayout4.Click += RelativeLayout4_Click;

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
        }

        private void RelativeLayout4_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(addcontent));
            StartActivity(intent);
        }

        private void RelativeLayout3_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Study1));
            StartActivity(intent);
        }

        private void RelativeLayout2_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Study1));
            StartActivity(intent);
        }

    }
}