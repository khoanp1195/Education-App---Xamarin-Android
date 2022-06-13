using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Widget;
using System;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Resource;
using Android.Support.V7.Widget;
using Project1.Study;
using Project1.Acitivties.Study;
using Project1.Activities;
using Project1.Activities.Webview;
using Project1.Activities.Study;
using Project1.Activities.Study.XamarinCourse;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Java.Lang;
using Project1.Resources.Fragment;

namespace Project1.Fragments
{
    public class SettingFragment : Android.Support.V4.App.Fragment
    {
        CardView report, position;
        LinearLayout sigout;
        Switch mSoundCheckBox, mMusicCheckBox;
        Android.Support.V7.Widget.Toolbar toolbar;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
         View view = inflater.Inflate(Resource.Layout.include_list_viewpager, container, false);

            TabLayout tabs = view.FindViewById<TabLayout>(Resource.Id.tabs);

            ViewPager viewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);

            SetUpViewPager(viewPager);

            toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolBar);
          //  toolbar.Visibility = Android.Views.ViewStates.Visible;

            tabs.SetupWithViewPager(viewPager);


            //mSoundCheckBox = (Switch)view.FindViewById(Resource.Id.sound_checkbox);

            //mSoundCheckBox.CheckedChange += delegate (object sender, CompoundButton.CheckedChangeEventArgs e)
            //{
            //    var toast = Toast.MakeText(Context, "Your answer is " + (e.IsChecked ? "correct" : "incorrect"), ToastLength.Short);

            //    toast.Show();
            //};

            //mMusicCheckBox = (Switch)view.FindViewById(Resource.Id.music_checkbox);

            //mMusicCheckBox.CheckedChange += delegate (object sender, CompoundButton.CheckedChangeEventArgs e)
            //{

            //    var toast = Toast.MakeText(Context, "Your answer is " + (e.IsChecked ? "correct" : "incorrect"), ToastLength.Short);

            //    toast.Show();
            //};


            //position = (CardView)view.FindViewById(Resource.Id.cardView5);

            //position.Click += delegate
            //{
            //    Intent intent = new Intent(Context, typeof(FirebaseActivity));
            //    StartActivity(intent);
            //};




            return view;
        }
        private void SetUpViewPager(ViewPager viewPager)
        {
            TabAdapter adapter = new TabAdapter(Activity.SupportFragmentManager);

            adapter.AddFragment(new Fragment1(), "Index");
            adapter.AddFragment(new Fragment2(), "InterView");


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

    }
}