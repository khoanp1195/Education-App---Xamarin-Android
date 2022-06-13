using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    [Activity(Label = "MyIntro")]
    public class MyIntro : AppIntro.AppIntro
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AddSlide(AppIntro.AppIntroFragment.NewInstance("English Quiz", "Improve Your English", Resource.Drawable.bg_quizz1, Resource.Color.followersBg));

            AddSlide(AppIntro.AppIntroFragment.NewInstance("English Dictionary", "Improve Your English", Resource.Drawable.bg_quizz1, Resource.Color.followersBg));
            AddSlide(AppIntro.AppIntroFragment.NewInstance("Test IQ", "Help you know about Your IQ", Resource.Drawable.bg_quizz1, Resource.Color.gradEnd));
            AddSlide(AppIntro.AppIntroFragment.NewInstance("Technology", "Help you know about Technology", Resource.Drawable.bg_quizz1, Resource.Color.followersBg));
            AddSlide(AppIntro.AppIntroFragment.NewInstance("Share Knowledge", "Help you to share knowledge with each other", Resource.Drawable.bg_quizz1, Resource.Color.followersBg));
            AddSlide(AppIntro.AppIntroFragment.NewInstance("Useful features to support learning", "Some features help you in learning such as Scan Text, Courses, video tutorials...", Resource.Drawable.bg_quizz1, Resource.Color.followersBg));
           


            ShowStatusBar(false);
            SetBarColor(Resource.Color.white);

            SetSeparatorColor(Resource.Color.white);

        }
        public override void OnDonePressed()
        {
            StartActivity(new Intent(this, typeof(WelcomeActivity)));
            Finish();
            OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        public override void OnSkipPressed()
        {
            Toast.MakeText(this, "skIPPPP", ToastLength.Short).Show();
            StartActivity(new Intent(this, typeof(WelcomeActivity)));
            OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);

        }
        public override void OnSlideChanged()
        {
            Toast.MakeText(this, "Skip clicked", ToastLength.Short).Show();
        }
    }
}