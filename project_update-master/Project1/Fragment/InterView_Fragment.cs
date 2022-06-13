using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V4.App;
using Java.Lang;
using Project1.Activities;
using Android.Support.V7.App;

namespace Project1.Fragment
{
    [Activity(Label = "Video")]
    public class InterView_Fragment : AppCompatActivity
    {
        ImageView play, play1, play2, play3, backButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_tip);
            play = FindViewById<ImageView>(Resource.Id.play);
            play.Click += Play_Click;
            play1 = FindViewById<ImageView>(Resource.Id.play1);
            play1.Click += Play1_Click;
            play2 = FindViewById<ImageView>(Resource.Id.play2);
            play2.Click += Play2_Click;
            play3 = FindViewById<ImageView>(Resource.Id.play3);
            backButton = FindViewById<ImageView>(Resource.Id.backButton);
            backButton.Click += BackButton_Click;
            play3.Click += Play3_Click;
            // Create your fragment here
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
        }

        private void Play3_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Csharptutorial));
            StartActivity(intent);
        }

        private void Play2_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AndroidTutorial));
            StartActivity(intent);
        }

        private void Play1_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MAUI));
            StartActivity(intent);
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(OxfordComunication));
            StartActivity(intent);
        }
    }
    }
