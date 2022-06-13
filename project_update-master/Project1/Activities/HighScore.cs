using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Project1.Common;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities
{
    [Activity(Label = "HighScore")]
    public class HighScore : Activity
    {
        ListView lstView;
        ImageView imgback;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.score);
            lstView = FindViewById<ListView>(Resource.Id.lstView);

            imgback = (ImageView)FindViewById(Resource.Id.imgback);
            imgback.Click += Imgback_Click;


            DbHelper.DbHelper db = new DbHelper.DbHelper(this);
            List<Ranking> lstRanking = db.GetRanking();
            if (lstRanking.Count > 0)
            {
                CustomAdapter adapter = new CustomAdapter(this, lstRanking);
                lstView.Adapter = adapter;
            }
            // Create your application here
        }

        private void Imgback_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.EnterFromLeft, Resource.Animation.abc_popup_enter);
        }
    }
}