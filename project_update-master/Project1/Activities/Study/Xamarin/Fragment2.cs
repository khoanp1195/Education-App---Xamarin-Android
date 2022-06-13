using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Resource;
using Android.Support.V7.Widget;
using Project1.Study;
using Project1.Model;
using Project1.EventListeners;
using Project1.Adapter;

namespace Project1
{
    public class Fragment2 : Android.Support.V4.App.Fragment
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
            View view = inflater.Inflate(Resource.Layout.interview, container, false);




            myRecyclerView = (RecyclerView)view.FindViewById(Resource.Id.recyclerView1);
            linearLayout = (LinearLayout)view.FindViewById(Resource.Id.linearLayout1);



            RetriveData();




            return view;
        }

        public void RetriveData()
        {
            xamarinListeners = new XamarinListeners();
            xamarinListeners.Create2();
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
            detailxamarin editAluminiFragment = new detailxamarin(thisXamarin);
            var trans = Activity.SupportFragmentManager.BeginTransaction();

            editAluminiFragment.Show(trans, "edit");
        }



    }
}