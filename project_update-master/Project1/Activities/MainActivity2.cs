using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V4.View;
using Com.Ittianyu.Bottomnavigationviewex;
using System;
using Android.Graphics;
using Android;
using Android.Support.V4.App;
using Project1.Fragments;
using Project1.Adapter;
using Project1.Fragment;
using Project1.Resources.Fragment;
using Android.Media;
using Android.Support.V4.Widget;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Content;
using Android.Content.Res;
using Project1.Activities.Essentials;
using Firebase.Auth;
using Firebase;
using Project1.Activities;
using Project1.Acitivties.Sanh;
using Project1.Activities.Profile;

namespace Project1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity2 : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        private DrawerLayout mDrawerLayout;

        MediaPlayer endSong, click;

        public static Context GetContext;

        //TextView
        TextView txtName;

        //Views
        ViewPager viewpager;
        BottomNavigationViewEx bnve;

        //Fragments
        HomeFragment homeFragment = new HomeFragment();
        EnglishFragment englishFragment = new EnglishFragment();
        Forum_Activity highScoreFragment = new Forum_Activity();
        IQ_ranking studyFragment = new IQ_ranking();
        HelpCenterFragment earningsFragment = new HelpCenterFragment();
        


        ProgressDialogueFragment progressDialogue;

        //PermissionRequest
        const int RequestID = 0;
        readonly string[] permissionsGroup =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation,
        };

        [Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main2);

            ClossProgressDialogue();


            ////==============Hide System Bottom======================
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
            ////====================================







            ConnectViews();
            IntializeDatabase();

            CheckSpecialPermission();

            txtName = FindViewById<TextView>(Resource.Id.txtName);
           
            //GetContext = this;
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            //Configuration config = GetContext.Resources.Configuration;
            //var ThemeMode = config.UiMode == (UiMode.NightYes | UiMode.TypeNormal);
            //if (ThemeMode) GetContext.SetTheme(Resource.Style.DarkTheme);
            //else GetContext.SetTheme(Resource.Style.LightTheme);









            //endSong = MediaPlayer.Create(this, Resource.Raw.jingle);
            //endSong.Start();

            click = MediaPlayer.Create(this, Resource.Raw.bloop);




            SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(toolBar);

            SupportActionBar ab = SupportActionBar;
            ab.SetHomeAsUpIndicator(Resource.Drawable.menu1);
            ab.SetDisplayHomeAsUpEnabled(true);


      

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);
           //    txtName.Text = FirebaseAuth.Instance.CurrentUser.PhoneNumber;


            }

            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);

              //  Android.App.FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                //if (e.MenuItem.ItemId == Resource.Id.nav_feedback)
                //{
                //    //MGradeFragment mg = new MGradeFragment();
                //    //// The fragment will have the ID of Resource.Id.fragment_container.
                //    //ft.Replace(Resource.Id.ll, mg);
                //    Intent email = new Intent(Intent.ActionSend);
                //    email.PutExtra(Intent.ExtraEmail, new String[] { "zphuongkhoaz@gmail.com" });
                //    email.PutExtra(Intent.ExtraSubject, "Feedback for app");
                //    email.PutExtra(Intent.ExtraText, "");
                //    email.SetType("message/rfc822");
                //    StartActivity(Intent.CreateChooser(email, "Sent Email"));
                //}
                //else if (e.MenuItem.ItemId == Resource.Id.home)
                //{


                //}

                //else if(e.MenuItem.ItemId == Resource.Id.nav_sentSMS)
                //{
                //    Intent intent = new Intent(this, typeof(SentSms));
                //    StartActivity(intent);
                //}
                //else if (e.MenuItem.ItemId == Resource.Id.nav_RePort)
                //{
                //    Intent intent = new Intent(this, typeof(ReportFragment));
                //    StartActivity(intent);
                //}
                //else if (e.MenuItem.ItemId == Resource.Id.nav_aboutus)
                //{

                //    Intent intent = new Intent(this, typeof(About));
                //    StartActivity(intent);
                //}



                //...

                // Commit the transaction.
                _ = new Intent(this, typeof(MainActivity2)).SetFlags(ActivityFlags.ReorderToFront);
               Intent intent;
                switch (e.MenuItem.ItemId)
                {
                    case (Resource.Id.nav_feedback):
                        // mDrawerLayout.CloseDrawers();
                        Intent email = new Intent(Intent.ActionSend);
                        email.PutExtra(Intent.ExtraEmail, new String[] { "zphuongkhoaz@gmail.com" });
                        email.PutExtra(Intent.ExtraSubject, "Feedback for app");
                        email.PutExtra(Intent.ExtraText, "");
                        email.SetType("message/rfc822");
                        StartActivity(Intent.CreateChooser(email, "Sent Email"));
                        break;

                    case (Resource.Id.nav_sentSMS):
                        intent = new Intent(this, typeof(SentSms)).SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        break;



                    case (Resource.Id.nav_profile):
                        intent = new Intent(this, typeof(Profile_Activity)).SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        break;


                    case (Resource.Id.nav_aboutus):
                        intent = new Intent(this, typeof(About)).SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        break;
                    case (Resource.Id.nav_aboutapp):
                        intent = new Intent(this, typeof(AboutApp)).SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        break;


                    case (Resource.Id.nav_RePort):
                        intent = new Intent(this, typeof(report)).SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        break;
                    case (Resource.Id.privacy):
                        intent = new Intent(this, typeof(Privacy_Policy)).SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        break;

                    case (Resource.Id.nav_signout):
                        


                        intent = new Intent(this, typeof(SignOut)).SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        Finish();
                        break;
                }


              //  ft.Commit();
                e.MenuItem.SetCheckable(false);
                mDrawerLayout.CloseDrawers();
            
            };
      
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return true;
        }

        void ClossProgressDialogue()
        {
            if (progressDialogue != null)
            {
                progressDialogue.Dismiss();
                progressDialogue = null;
            }
        }


        private void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {
                e.MenuItem.SetChecked(true);
                mDrawerLayout.CloseDrawers();
            };
        }

            bool NavigationView.IOnNavigationItemSelectedListener.OnNavigationItemSelected(IMenuItem menuItem)
        {
            
            int id = menuItem.ItemId;

            if (id == Resource.Id.nav_home)
            {
                // Handle the camera action
            }
            else if (id == Resource.Id.nav_aboutus)
            {
                
            }
          
            else if (id == Resource.Id.nav_feedback)
            {
               
            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;

        }

      

      

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;

               

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        [Obsolete]
        void ConnectViews()
        {
            bnve = (BottomNavigationViewEx)FindViewById(Resource.Id.bnve);
            bnve.EnableItemShiftingMode(false);
            bnve.EnableShiftingMode(false);
            var img0 = bnve.GetIconAt(0);
            var txt0 = bnve.GetLargeLabelAt(0);
            img0.SetColorFilter(Color.Rgb(0, 0, 0));
            txt0.SetTextColor(Color.Rgb(24, 191, 242));

            bnve.NavigationItemSelected += Bnve_NavigationItemSelected;
            viewpager = (ViewPager)FindViewById(Resource.Id.viewpager);
            viewpager.OffscreenPageLimit = 3;
            viewpager.BeginFakeDrag();

            SetupViewPager();
        }

        private void Bnve_NavigationItemSelected(object sender, Android.Support.Design.Widget.BottomNavigationView.NavigationItemSelectedEventArgs e)
        {

            if (e.Item.ItemId == Resource.Id.action_home)
            {
                viewpager.SetCurrentItem(0, true);
                BnveToAccentColor(0);
                click.Start();
            }
            else if (e.Item.ItemId == Resource.Id.action_english)
            {
                viewpager.SetCurrentItem(1, true);
                BnveToAccentColor(1);
                click.Start();
            }
            else if (e.Item.ItemId == Resource.Id.action_ranking)
            {
                viewpager.SetCurrentItem(2, true);
                BnveToAccentColor(2);
                click.Start();
            }
            else if (e.Item.ItemId == Resource.Id.action_rating)
            {
                viewpager.SetCurrentItem(3, true);
                BnveToAccentColor(3);
                click.Start();

            }
           



            else if (e.Item.ItemId == Resource.Id.action_account)
            {
                viewpager.SetCurrentItem(4, true);
                BnveToAccentColor(4);
                click.Start();
            }



        }

        void BnveToAccentColor(int index)
        {
            //Set all to white
            var img = bnve.GetIconAt(1);
            var txt = bnve.GetLargeLabelAt(1);
            img.SetColorFilter(Color.Rgb(0, 0, 0));
            txt.SetTextColor(Color.Rgb(0, 0, 0));

            var img0 = bnve.GetIconAt(0);
            var txt0 = bnve.GetLargeLabelAt(0);
            img0.SetColorFilter(Color.Rgb(0, 0, 0));
            txt0.SetTextColor(Color.Rgb(0, 0, 0));

            var img2 = bnve.GetIconAt(2);
            var txt2 = bnve.GetLargeLabelAt(2);
            img2.SetColorFilter(Color.Rgb(0, 0, 0));
            txt2.SetTextColor(Color.Rgb(0, 0, 0));

            var img3 = bnve.GetIconAt(3);
            var txt3 = bnve.GetLargeLabelAt(3);
            img3.SetColorFilter(Color.Rgb(0, 0, 0));
            txt3.SetTextColor(Color.Rgb(0, 0, 0));

            //Sets Accent Color
            var imgindex = bnve.GetIconAt(index);
            var textindex = bnve.GetLargeLabelAt(index);
            imgindex.SetColorFilter(Color.Rgb(0, 0, 0));
            textindex.SetTextColor(Color.Rgb(24, 191, 242));

        }





        void IntializeDatabase()
        {
            var app = FirebaseApp.InitializeApp(this);

            if (app == null)
            {
                var options = new Firebase.FirebaseOptions.Builder()
                .SetApplicationId("project1-4e850")
                .SetApiKey("AIzaSyCou_P4H_wbYA3tWisjrOfq2b9nhYIzd7w")
                .SetDatabaseUrl("https://project1-4e850-default-rtdb.firebaseio.com")
                .SetStorageBucket("project1-4e850.appspot.com")
                .Build();

                app = FirebaseApp.InitializeApp(this, options);
              //  mDatabase = FirebaseDatabase.GetInstance(app);
            }
            else
            {
              ///  mDatabase = FirebaseDatabase.GetInstance(app);
            }
            //  DatabaseReference dbrf = mDatabase.GetReference("UserSupport");
            // dbrf.SetValue("Ticket");

            //Toast.MakeText(this, "Make Test", ToastLength.Short).Show();
        }

        private void SetupViewPager()
        {
            ViewPagerAdapter adapter = new ViewPagerAdapter(SupportFragmentManager);
            adapter.AddFragment(homeFragment, "Home");
            adapter.AddFragment(englishFragment, "English");
            adapter.AddFragment(highScoreFragment, "Forum");
            adapter.AddFragment(studyFragment, "Ranking");


            adapter.AddFragment(earningsFragment, "Earnings");

          
           
          
         
            viewpager.Adapter = adapter;
        }

        bool CheckSpecialPermission()
        {
            bool permissionGranted = false;
            if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Android.Content.PM.Permission.Granted &&
                ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) != Android.Content.PM.Permission.Granted)
            {
                RequestPermissions(permissionsGroup, RequestID);
            }
            else
            {
                permissionGranted = true;
            }

            return permissionGranted;
        }

    }
}