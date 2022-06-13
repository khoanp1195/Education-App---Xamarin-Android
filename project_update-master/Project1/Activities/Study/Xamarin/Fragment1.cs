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

namespace Project1
{
    public class Fragment1 : Android.Support.V4.App.Fragment
    {

      
     

        RecyclerView myRecyclerView;
        List<XamarinCourse> xamarinList;

        XamarinListeners xamarinListeners;


        LinearLayout linearLayout;

        XamarinAdapter adapter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here    
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Xamarin, container, false);


            myRecyclerView = (RecyclerView)view.FindViewById(Resource.Id.recyclerView1);
            linearLayout = (LinearLayout)view.FindViewById(Resource.Id.linearLayout1);



            RetriveData();


            return view;
        }

        public void RetriveData()
        {
            xamarinListeners = new XamarinListeners();
            xamarinListeners.Create();
            xamarinListeners.AluminRetrived += XamarinListeners_AluminRetrived;
        }

        private void XamarinListeners_AluminRetrived(object sender, XamarinListeners.AluminDataEventArgs e)
        {
            xamarinList = e.XamarinCourse;
            SetupRecyClerView();
        }
     
        private void SetupRecyClerView()
        {
            myRecyclerView.SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(myRecyclerView.Context));
            adapter = new XamarinAdapter(xamarinList);
            //    adapter.DeleteItemClick += Adapter_DeleteItemClick;


            adapter.ItemLongClick += Adapter_ItemLongClick;
            myRecyclerView.SetAdapter(adapter);
        }

        private void Adapter_ItemLongClick(object sender, XamarinAdapter.AluminiAdapterClickEventArgs e)
        {
            XamarinCourse thisXamarin = xamarinList[e.Position];

            //Intent intent = new Intent(Context, typeof(detailxamarin));
            //detailxamarin detailxamarin = new detailxamarin(thisXamarin);
            //  intent.PutExtra("edit", (Java.IO.ISerializable)thisXamarin);
            //StartActivity(intent);
            //detailxamarin editAluminiFragment = new detailxamarin(thisXamarin);
            //var trans = Activity.SupportFragmentManager.BeginTransaction();

            //editAluminiFragment.Show(trans, "edit");


          
       //    detailxamarin1 detailxamarin1 = new detailxamarin1(thisXamarin);

          
           detailxamarin1 editdetailfragment1 = new detailxamarin1(thisXamarin);
           // var trans = new Intent(Context, typeof(detailxamarin1));
            editdetailfragment1.StartActivity(typeof(detailxamarin1));
            //editdetailfragment.PutExtra( "Name",thisXamarin);
            //editdetailfragment.PutExtra( "Number",thisXamarin.Number.ToString());
            //editdetailfragment.PutExtra( "Content1",thisXamarin.Content1.ToString());
            //editdetailfragment.PutExtra( "Content2",thisXamarin.Content2.ToString());
            //editdetailfragment.PutExtra( "Content3",thisXamarin.Content3.ToString());
            //editdetailfragment.PutExtra( "Content4",thisXamarin.Content4.ToString());
            //editdetailfragment.PutExtra( "Content5",thisXamarin.Content5.ToString());
            //editdetailfragment.PutExtra( "Content6",thisXamarin.Content6.ToString());

            //editdetailfragment.PutExtra("Title1",thisXamarin.Title1.ToString());
            //editdetailfragment.PutExtra("Title2", thisXamarin.Title2.ToString());
            //editdetailfragment.PutExtra("Title3", thisXamarin.Title3.ToString());
            //editdetailfragment.PutExtra("Title4", thisXamarin.Title4.ToString());
            //editdetailfragment.PutExtra("Title5", thisXamarin.Title5.ToString());
            //editdetailfragment.PutExtra("Title6", thisXamarin.Title6.ToString());
            //editdetailfragment.PutExtra("Category", thisXamarin.Category.ToString());


        }
    }
}