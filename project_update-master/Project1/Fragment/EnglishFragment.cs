
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Project1.Activities.Intro;
using Project1.Activities.Study.EnglishDictionary;
using Project1.Adapter;
using Project1.EventListeners;
using Project1.Model;
using Project1.Study;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Fragment
{
    public class EnglishFragment : Android.Support.V4.App.Fragment
    {


        CardView cardView4, cardview1, cardView7, cardView5, cardView8, cardView6;
        ImageView imagePlay;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.English_Category, container, false);



            imagePlay = (ImageView)view.FindViewById(Resource.Id.imagePlay);
            imagePlay.Click += ImagePlay_Click;

            cardview1 = (CardView)view.FindViewById(Resource.Id.cardView1);
            cardview1.Click += Cardview1_Click;

            cardView4 = (CardView)view.FindViewById(Resource.Id.cardView4);
            cardView8 = (CardView)view.FindViewById(Resource.Id.cardView8);
            cardView6 = (CardView)view.FindViewById(Resource.Id.cardView6);


            cardView6.Click += CardView6_Click;

            cardView8.Click += CardView8_Click;

            cardView5 = (CardView)view.FindViewById(Resource.Id.cardView5);

            cardView4.Click += CardView4_Click;

            cardView5.Click += CardView5_Click;


            cardView7 = (CardView)view.FindViewById(Resource.Id.cardView7);
            cardView7.Click += CardView7_Click;


            return view;
        }

        private void ImagePlay_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(IntroEnglish));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView6_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(FavoriteWordActivity));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView8_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(UserContribute));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView5_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(Advanced));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView7_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(addcontent));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void Cardview1_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(SelectWord));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView4_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(Normal));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }




    }
}