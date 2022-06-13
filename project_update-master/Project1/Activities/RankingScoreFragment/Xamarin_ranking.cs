using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
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
    public class Xamarin_ranking : AppCompatActivity
    {

        RecyclerView myRecyclerView;
        List<UserRanking> userrankingList;
        UserRankingAdapter adapter;
        UserRankingListeners userrankingListeners;

        ImageView back;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.xamarinranking);
            // Create your fragment here


            back = (ImageView)FindViewById(Resource.Id.backButton);
            back.Click += Back_Click;
            myRecyclerView = (RecyclerView)FindViewById(Resource.Id.recyclerView1);
            RetriveData();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.EnterFromLeft, Resource.Animation.abc_popup_enter);
        }

        public void RetriveData()
        {
            userrankingListeners = new UserRankingListeners();
            userrankingListeners.Create1();
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