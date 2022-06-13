using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Project1.Adapter;
using Project1.EventListeners;
using Project1.Fragment;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Support.V7.Widget.RecyclerView;

namespace Project1
{
    [Activity(Label = "detailxamarin")]
    public class detailQuestion : Android.Support.V4.App.DialogFragment
    {
        TextView course, userText, content1Text, content2Text, timer;
        LinearLayout linearLayout;
        Button repply;
    //    AddUserReplyFragment addAluminFragment;
        UserQuestion thisCourse;
        RecyclerView myRecyclerView;
        List<UserQuestion> xamarinList;
        QuestionAdapter adapter;

        QuestionListeners xamarinListeners;
        //public detailQuestion()
        //{
        //}

        public detailQuestion(UserQuestion xamarin)
        {
            thisCourse = xamarin;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.detailQuestion, container, false);

            repply = view.FindViewById<Button>(Resource.Id.repply);

          
        
         //   repply.Click += Repply_Click;

            course = view.FindViewById<TextView>(Resource.Id.course);
            userText = view.FindViewById<TextView>(Resource.Id.userText);
            content1Text = view.FindViewById<TextView>(Resource.Id.content1Text);
            content2Text = view.FindViewById<TextView>(Resource.Id.content2Text);
            timer = view.FindViewById<TextView>(Resource.Id.timer);
            myRecyclerView = (RecyclerView)view.FindViewById(Resource.Id.recyclerView1);

            linearLayout = (LinearLayout)view.FindViewById(Resource.Id.linearLayout1);


            course.Text = thisCourse.Title;
            userText.Text = thisCourse.Contribute;
            timer.Text = thisCourse.Timer;
          

            content1Text.Text = thisCourse.Category;
            content2Text.Text = thisCourse.Content;

            RetriveData();
            return view;
        }

        //private void Repply_Click(object sender, EventArgs e)
        //{
          
        //    addAluminFragment = new AddUserReplyFragment();
        //    var trans = FragmentManager.BeginTransaction();
        //    addAluminFragment.Show(trans, "new alumini");
        //}
        public void RetriveData()
        {
 
     
            xamarinListeners = new QuestionListeners();
            xamarinListeners.Create();
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

           // adapter.ItemLongClick += Adapter_ItemLongClick1;
            //   adapter.ItemLongClick += Adapter_ItemLongClick;
            myRecyclerView.SetAdapter(adapter);
        }
    }
}