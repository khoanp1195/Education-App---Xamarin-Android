using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;
using System.Collections.Generic;
using Java.Lang;

namespace Project1.Activities.AddQuestionQuizz
{
    [Activity(Label = "AddQuestionQuizz", MainLauncher = false)]
    public class OOPInterview : AppCompatActivity
    {
       
        ImageView addButton;
        ImageView searchButton, backButton;

        EditText edtSearch;
        ImageView imgSearch;
  


        RelativeLayout relativeLayout1;

        //Floating Button
        private static bool isFabOpen;
        private FloatingActionButton fabAirballoon;
        private FloatingActionButton fabCake;
        private FloatingActionButton fabMain;
        private FloatingActionButton fabNote;


        AddQuestionQuizzDialogFragment addQuestionQuizzDialogFragment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TipInterview);


            relativeLayout1 = (RelativeLayout)FindViewById(Resource.Id.relativeLayout1);
            edtSearch = (EditText)FindViewById(Resource.Id.edtSearch);
            imgSearch = (ImageView)FindViewById(Resource.Id.imgSearch);

        

  
            backButton = (ImageView)FindViewById(Resource.Id.backButton);

            // Create your application here


            TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);

            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);

            SetUpViewPager(viewPager);

            tabs.SetupWithViewPager(viewPager);

            backButton.Click += BackButton_Click;
        
        }

        private void SetUpViewPager(ViewPager viewPager)
        {
            TabAdapter adapter = new TabAdapter(SupportFragmentManager);

            adapter.AddFragment(new XamarinInterviewFragment(), "Norlmal");
            adapter.AddFragment(new XamarinInterviewFragment(), "Advanced");
        



            viewPager.Adapter = adapter;
        }



        public class TabAdapter : FragmentPagerAdapter
        {
            public List<SupportFragment> Fragments { get; set; }
            public List<string> FragmentNames { get; set; }

            public TabAdapter(SupportFragmentManager sfm) : base(sfm)
            {
                Fragments = new List<SupportFragment>();
                FragmentNames = new List<string>();
            }

            public void AddFragment(SupportFragment fragment, string name)
            {
                Fragments.Add(fragment);
                FragmentNames.Add(name);
            }

            public override int Count
            {
                get
                {
                    return Fragments.Count;
                }
            }

            public override SupportFragment GetItem(int position)
            {
                return Fragments[position];
            }

            public override ICharSequence GetPageTitleFormatted(int position)
            {
                return new Java.Lang.String(FragmentNames[position]);
            }
        }



        private void BackButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.EnterFromLeft, Resource.Animation.abc_popup_enter);
        }

    }
}