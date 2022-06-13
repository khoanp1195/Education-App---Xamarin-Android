using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Project1.Adapter;
using Project1.EventListener;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Fragment
{

    [Activity]

    public class IQ_ranking : Android.Support.V4.App.Fragment
    {

        RecyclerView myRecyclerView;
        List<UserRanking> userrankingList;
        UserRankingAdapter adapter;
        UserRankingListeners userrankingListeners;


        TextView xamarin, flag;



        //Floating Button
        private static bool isFabOpen;
        private FloatingActionButton fabAirballoon;
        private FloatingActionButton fabCake;
        private FloatingActionButton fabMain;
        private FloatingActionButton fabNote;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.rankingIQ, container, false);


            myRecyclerView = (RecyclerView)view.FindViewById(Resource.Id.recyclerView1);
            RetriveData();

            xamarin = (TextView)view.FindViewById(Resource.Id.xamarin);
            xamarin.Click += Xamarin_Click;


            flag = (TextView)view.FindViewById(Resource.Id.Flag);
            flag.Click += Flag_Click;



     
            return view;


        }

        private void Flag_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(Flag_ranking));
            StartActivity(intent);
            (Activity).OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void Xamarin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(Xamarin_ranking));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        public void RetriveData()
        {
            userrankingListeners = new UserRankingListeners();
            userrankingListeners.Create();
            userrankingListeners.UserRankingRetrived += UserrankingListeners_UserRankingRetrived;
        }

        private void UserrankingListeners_UserRankingRetrived(object sender, UserRankingListeners.UserRankingDataEventArgs e)
        {
            userrankingList = e.UserRanking;
            SetupRecyClerView();
        }
        private void SetupRecyClerView()
        {
            myRecyclerView.SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(myRecyclerView.Context));
            adapter = new UserRankingAdapter(userrankingList);
            //    adapter.DeleteItemClick += Adapter_DeleteItemClick;

            //  adapter.ItemLongClick += Adapter_ItemLongClick; ;
            //   adapter.ItemLongClick += Adapter_ItemLongClick;
            myRecyclerView.SetAdapter(adapter);
        }



    }
}