using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Project1.Acitivties;
using Project1.Acitivties.ActivitiesPlaying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Widget.SeekBar;

namespace Project1.Activities.Intro
{
    [Activity(Label = "IntroIQ")]
    public class IntroIQ : Activity, IOnSeekBarChangeListener
    {
        SeekBar seekBar;
        TextView txtMode;
        Button btnPlay, btnScore;
        ImageView back;
        DbHelper.DbHelper db;
        SQLiteDatabase sqliteDB;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.introlayout);

            db = new DbHelper.DbHelper(this);
            sqliteDB = db.WritableDatabase;

            seekBar = FindViewById<SeekBar>(Resource.Id.seekBar);
            txtMode = FindViewById<TextView>(Resource.Id.txtMode);
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            btnScore = FindViewById<Button>(Resource.Id.btnScore);
            back = FindViewById<ImageView>(Resource.Id.back);

            back.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity2));
                StartActivity(intent);
                Finish();
            //    OverridePendingTransition(Resource.Animation.EnterFromLeft, Resource.Animation.abc_popup_enter);
            };

            seekBar.SetOnSeekBarChangeListener(this);
            btnPlay.Click += delegate {
                Intent intent = new Intent(this, typeof(IQ));
                intent.PutExtra("MODE", getPlayMode());
                StartActivity(intent);
                Finish();
                OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
            };
            btnScore.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Score));
                StartActivity(intent);
                Finish();
                OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
            };
        }


        private String getPlayMode()
        {
            if (seekBar.Progress == 0)
                return Common.Common.MODE.EASY.ToString();
            else if (seekBar.Progress == 1)
                return Common.Common.MODE.MEDIUM.ToString();
            else if (seekBar.Progress == 2)
                return Common.Common.MODE.HARD.ToString();
            else
                return Common.Common.MODE.HARDEST.ToString();
        }

        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {

            txtMode.Text = getPlayMode().ToUpper();
        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {

        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {

        }
    }
}