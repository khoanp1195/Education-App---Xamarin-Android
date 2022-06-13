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
using Android.Content;

namespace Project1.Activities.Study.Question
{
    [Activity(Label = "UserReply")]
    public class UserReply : AppCompatActivity
    {


        RecyclerView myRecyclerView;
        List<UserQuestion> xamarinList;
        QuestionAdapter adapter;
        QuestionListeners xamarinListeners;

        ImageView btnadd, btnBack;
        AddUserReplyFragment addUserReplyFragment;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Answer);

            btnadd = (ImageView)FindViewById(Resource.Id.addButton);
           btnBack = (ImageView)FindViewById(Resource.Id.backButton);


     btnBack.Click += BtnBack_Click;

            btnadd.Click += Btnadd_Click1;

            myRecyclerView = (RecyclerView)FindViewById(Resource.Id.recyclerView1);



            RetriveData();

            // Create your application here
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.EnterFromLeft, Resource.Animation.abc_popup_enter);
        }

        private void Btnadd_Click1(object sender, EventArgs e)
        {
            addUserReplyFragment = new AddUserReplyFragment();
            var trans = SupportFragmentManager.BeginTransaction();
            addUserReplyFragment.Show(trans, "new alumini");
        }

      
        public void RetriveData()
        {
            xamarinListeners = new QuestionListeners();
            xamarinListeners.Create4();
            xamarinListeners.AluminRetrived += XamarinListeners_AluminRetrived1;
        }

        private void XamarinListeners_AluminRetrived1(object sender, QuestionListeners.AluminDataEventArgs e)
        {
            xamarinList = e.UserQuestions;
            SetupRecyClerView();
        }


        private void SetupRecyClerView()
        {
            myRecyclerView.SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(myRecyclerView.Context));
            adapter = new QuestionAdapter(xamarinList);
            //    adapter.DeleteItemClick += Adapter_DeleteItemClick;

            adapter.ItemLongClick += Adapter_ItemLongClick1;
            //   adapter.ItemLongClick += Adapter_ItemLongClick;
            myRecyclerView.SetAdapter(adapter);
        }

        private void Adapter_ItemLongClick1(object sender, QuestionAdapter.AluminiAdapterClickEventArgs e)
        {

                UserQuestion thisXamarin = xamarinList[e.Position];

                //Intent intent = new Intent(Context, typeof(detailxamarin));
                //detailxamarin detailxamarin = new detailxamarin(thisXamarin);
                //  intent.PutExtra("edit", (Java.IO.ISerializable)thisXamarin);
                //StartActivity(intent);
                detailQuestion editAluminiFragment = new detailQuestion(thisXamarin);
                var trans = SupportFragmentManager.BeginTransaction();

                editAluminiFragment.Show(trans, "edit");
        }


    }
}