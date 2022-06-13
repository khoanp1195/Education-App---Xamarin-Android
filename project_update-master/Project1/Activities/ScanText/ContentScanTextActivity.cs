using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Project1.Common;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities.ScanText
{
    [Activity(Label = "ContentScanText")]
    public class ContentScanTextActivity : AppCompatActivity
    {
        ListView lstView;
        ImageView searchButton, backButton;

        List<ContentScanText> listItsms = null;

        RelativeLayout relativeLayout1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ContentScanText);
            relativeLayout1 = (RelativeLayout)FindViewById(Resource.Id.relativeLayout1);
            backButton = (ImageView)FindViewById(Resource.Id.backButton);
            backButton.Click += delegate
            {
                StartActivity(new Intent(this, typeof(MainActivity2)));
            };


            lstView = FindViewById<ListView>(Resource.Id.lstView);

            DbHelper.DbHelper db = new DbHelper.DbHelper(this);
            List<ContentScanText> lstQuestion = db.GetContentScanText();
            if (lstQuestion.Count > 0)
            {
                ContentScanTextAdapter adapter = new ContentScanTextAdapter(this, lstQuestion);
                lstView.Adapter = adapter;
            }
            LoadQuestionList();
        }
        private void LoadQuestionList()
        {
            DbHelper.DbHelper dbVals = new DbHelper.DbHelper(this);
           
                listItsms = dbVals.GetContentScanText();
            
          

            lstView.Adapter = new ContentScanTextAdapter(this, listItsms);
        }
    }
}