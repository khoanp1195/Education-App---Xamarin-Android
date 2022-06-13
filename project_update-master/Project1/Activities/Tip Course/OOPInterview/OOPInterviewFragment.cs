using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;

using System.Collections.Generic;

using System.Linq;
using Project1.Fragment;
using Project1.Model;
using Project1.EventListeners;
using Project1.Adapter;
using Xamarin.Essentials;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Graphics;
using Android.Support.V4.Widget;
using Android.Content;
using AndroidX.Core.Content;
using Android.Preferences;
using Project1.Common;

namespace Project1
{
    public class OOPInterviewFragment : Android.Support.V4.App.Fragment
    {


        ListView lstView;

        List<XamarinInterview> listItsms = null;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here    
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.xamarininterview, container, false);

            lstView = view.FindViewById<ListView>(Resource.Id.lstView);

            DbHelper.DbHelper db = new DbHelper.DbHelper(Context);
            List<XamarinInterview> lstQuestion = db.GetXamarinInterviewQuestions();
            if (lstQuestion.Count > 0)
            {
                TipCourseCustomAdapter adapter = new TipCourseCustomAdapter(Context, lstQuestion);
                lstView.Adapter = adapter;
            }

            return view;
        }

        private void LoadQuestionList()
        {
            DbHelper.DbHelper dbVals = new DbHelper.DbHelper(Context);
            
            
                listItsms = dbVals.GetXamarinInterviewQuestions();
        
           

            lstView.Adapter = new TipCourseCustomAdapter(Context, listItsms);
        }
    }
}