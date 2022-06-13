using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Firebase;
using Firebase.Database;
using Android.Views;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android;
using Android.Support.V4.App;
using Android.Content.PM;
using Android.Gms.Location;
using Android.Content;
using Android.Gms.Location.Places.UI;
using Android.Gms.Location.Places;
using Project1.Helper;
using Java.Lang;
using System;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V4.View;
using Project1.Adapter;

using Android.Animation;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using System.Collections.Generic;
using Project1.Resources.Fragment;
using Project1.Acitivties.Sanh;
using Project1.Activities;
using Project1.Activities.Essentials;

namespace Project1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity, IOnMapReadyCallback, NavigationView.IOnNavigationItemSelectedListener
    {
        Context context;

        //Floating Button
        private static bool isFabOpen;
        private FloatingActionButton fabAirballoon;
        private FloatingActionButton fabCake;
        private FloatingActionButton fabMain;
        private FloatingActionButton fabNote;

        //ViewPager
        ViewPager viewPager;

        //Firebase
        FirebaseDatabase database;
        UserProfileEventlistener userListener = new UserProfileEventlistener();

        //ImageView
        ImageView img_weather, img_calculate;

        //View
        Android.Support.V7.Widget.Toolbar mainToolbar;
        Android.Support.V4.Widget.DrawerLayout drawerLayout;

        //Radio Button
        RadioButton pickup, destination;

        //Button
        Button displayButton, signout;


        //TextViews
        TextView pickupLocationText;
        TextView destinationText;

        ////Layouts
        RelativeLayout layoutPickUp;
        RelativeLayout layoutDestination;
        LinearLayout linearLayout;



        //Google Map
        GoogleMap mainMap;

        readonly string[] permissionGroupLocation = { Manifest.Permission.AccessFineLocation, Manifest.Permission.AccessCoarseLocation };
        const int requestLocationId = 0;

        LocationRequest mLocationRequest;
        FusedLocationProviderClient locationClient;
        Android.Locations.Location mLastLocation;
        LocationCallbackHelper mLocationCallback;
      
        static int UPDATE_INTERVAL = 5; //5 SECONDS
        static int FASTEST_INTERVAL = 5;
        static int DISPLACEMENT = 3; //meters

        int count = 1;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Main);
            ConnectControl();

            IntializeDatabase();

            //DrawerLayout
            drawerLayout = (Android.Support.V4.Widget.DrawerLayout)FindViewById(Resource.Id.drawer_layout);

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);
            }
            //TabLayout tabs = FindViewById<TabLayout>(Resource.Id.tabs);

            //ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);

            //SetUpViewPager(viewPager);

            //tabs.SetupWithViewPager(viewPager);






            //ToolBar
            mainToolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.mainToolbar);
            SetSupportActionBar(mainToolbar);
            SupportActionBar.Title = "";
            Android.Support.V7.App.ActionBar actionBar = SupportActionBar;
            actionBar.SetHomeAsUpIndicator(Resource.Mipmap.ic_menu_action);
            actionBar.SetDisplayHomeAsUpEnabled(true);

            var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);

          

            LocationCallbackHelper mLocationCallback;
            CheckLocationPermission();
            CreateLocationRequest();
            GetMyLocation();

            StartLocationUpdate();
            StopLocation();

            //  userListener.Create();
         
    

        }
        //private void SetUpViewPager(ViewPager viewPager)
        //{
        //    TabAdapter adapter = new TabAdapter(SupportFragmentManager);

        //    adapter.AddFragment(new Fragment1(), "Fragment 1");

        //    viewPager.Adapter = adapter;
        //}

        //public class TabAdapter : FragmentPagerAdapter
        //{
        //    public List<SupportFragment> Fragments { get; set; }
        //    public List<string> FragmentNames { get; set; }

        //    public TabAdapter(SupportFragmentManager sfm) : base(sfm)
        //    {
        //        Fragments = new List<SupportFragment>();
        //        FragmentNames = new List<string>();
        //    }

        //    public void AddFragment(SupportFragment fragment, string name)
        //    {
        //        Fragments.Add(fragment);
        //        FragmentNames.Add(name);
        //    }

        //    public override int Count
        //    {
        //        get
        //        {
        //            return Fragments.Count;
        //        }
        //    }

        //    public override SupportFragment GetItem(int position)
        //    {
        //        return Fragments[position];
        //    }

        //    public override ICharSequence GetPageTitleFormatted(int position)
        //    {
        //        return new Java.Lang.String(FragmentNames[position]);
        //    }
        //}
        private void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {
                e.MenuItem.SetChecked(true);
                drawerLayout.CloseDrawers();
                // Commit the transaction.
                _ = new Intent(this, typeof(MainActivity2)).SetFlags(ActivityFlags.ReorderToFront);
                Intent intent;
                switch (e.MenuItem.ItemId)
                {
                    //case (Resource.Id.nav_feedback):
                    //    // mDrawerLayout.CloseDrawers();
                    //    Intent email = new Intent(Intent.ActionSend);
                    //    email.PutExtra(Intent.ExtraEmail, new String[] { "zphuongkhoaz@gmail.com" });
                    //    email.PutExtra(Intent.ExtraSubject, "Feedback for app");
                    //    email.PutExtra(Intent.ExtraText, "");
                    //    email.SetType("message/rfc822");
                    //    StartActivity(Intent.CreateChooser(email, "Sent Email"));
                    //    break;
                    case (Resource.Id.nav_home):
                        intent = new Intent(this, typeof(MainActivity2)).SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        break;
                    case (Resource.Id.nav_sentSMS):
                        intent = new Intent(this, typeof(SentSms)).SetFlags(ActivityFlags.ReorderToFront);
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
                drawerLayout.CloseDrawers();

            };
            
        }
        private void DisplayButton_Click1(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegisterActivity));
            StartActivity(intent);
        }

        void ConnectControl()
        {
         
            //Button
            //displayButton = (Button)FindViewById(Resource.Id.btn_search);
            //displayButton.Click += DisplayButton_Click;



      //      img_weather = (ImageView)FindViewById(Resource.Id.img_weather);
         
   
            //FloatingButton


            fabAirballoon = FindViewById<FloatingActionButton>(Resource.Id.fab_airballoon);
            fabCake = FindViewById<FloatingActionButton>(Resource.Id.fab_cake);
            fabNote = FindViewById<FloatingActionButton>(Resource.Id.fab_note);
            fabNote.Click += (o, e) =>
            {
                if (!isFabOpen)
                    ShowFabMenu();
                else
                    CloseFabMenu();
            };

            fabMain = FindViewById<FloatingActionButton>(Resource.Id.fab_main);
           

            fabMain.Click += (o, e) =>
            {
                if (!isFabOpen)
                    ShowFabMenu();
                else
                    CloseFabMenu();
            };

            fabCake.Click += (o, e) =>
            {
                CloseFabMenu();
                Toast.MakeText(this, "Cake!", ToastLength.Short).Show();
                StartActivity(new Intent(this, typeof(MainActivity2)));
            };

            fabAirballoon.Click += (o, e) =>
            {
                CloseFabMenu();
                Toast.MakeText(this, "Airballoon!", ToastLength.Short).Show();
               
            };



        }

        private void Signout_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(LoginActivity)));
            Finish();
        }

        private void ShowFabMenu()
        {
            isFabOpen = true;
            fabNote.Visibility = ViewStates.Visible;
            fabAirballoon.Visibility = ViewStates.Visible;
            fabCake.Visibility = ViewStates.Visible;


            fabMain.Animate().Rotation(135f);

            fabAirballoon.Animate()
                .TranslationY(-Resources.GetDimension(Resource.Dimension.standard_100))
                .Rotation(0f);
            fabCake.Animate()
                .TranslationY(-Resources.GetDimension(Resource.Dimension.standard_55))
                .Rotation(0f);
            fabNote.Animate()
       .TranslationY(-Resources.GetDimension(Resource.Dimension.standard_145))
       .Rotation(0f);
        }

        private void CloseFabMenu()
        {
            isFabOpen = false;

            fabNote.Animate().Rotation(0f)

              .TranslationY(0f)
              .Rotation(90f);
            fabMain.Animate().Rotation(0f)

                .TranslationY(0f)
                .Rotation(90f);
            fabCake.Animate()
                .TranslationY(0f)
                .Rotation(90f).SetListener(new FabAnimatorListener( fabCake, fabAirballoon));
        }

        private class FabAnimatorListener : Java.Lang.Object, Animator.IAnimatorListener
        {
            View[] viewsToHide;

            public FabAnimatorListener(params View[] viewsToHide)
            {
                this.viewsToHide = viewsToHide;
            }

            public void OnAnimationCancel(Animator animation)
            {
            }

            public void OnAnimationEnd(Animator animation)
            {
                if (!isFabOpen)
                    foreach (var view in viewsToHide)
                        view.Visibility = ViewStates.Gone;
            }

            public void OnAnimationRepeat(Animator animation)
            {
            }

            public void OnAnimationStart(Animator animation)
            {
            }
        }



     

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            //List<Place.Field> fields = new List<Place.Field>();

            //fields.Add(Place.Field.Id);
            //fields.Add(Place.Field.Name);
            //fields.Add(Place.Field.LatLng);
            //fields.Add(Place.Field.Address);

            //Intent intent = new Autocomplete.IntentBuilder(AutocompleteActivityMode.Overlay, fields)
            //    .SetCountry("US")
            //    .Build(this);

            //StartActivityForResult(intent, 0);
        }




        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;


                default:
                    return base.OnOptionsItemSelected(item);


            }
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
                database = FirebaseDatabase.GetInstance(app);


            }
            else
            {
                database = FirebaseDatabase.GetInstance(app);
            }
            DatabaseReference dbrf = database.GetReference("UserSupport");
            dbrf.SetValue("Ticket");

            Toast.MakeText(this, "Make Test", ToastLength.Short).Show();
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            // 
            mainMap = googleMap;
            MarkerOptions markerOpt1 = new MarkerOptions();
            markerOpt1.SetPosition(new LatLng(50.379444, 2.773611));
            markerOpt1.SetTitle("Vimy Ridge");

            googleMap.AddMarker(markerOpt1);
            //
        }

        bool CheckLocationPermission()
        {
            bool permissionGranted = false;

            if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != Android.Content.PM.Permission.Granted &&
                ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) != Android.Content.PM.Permission.Granted)
            {
                permissionGranted = false;
                RequestPermissions(permissionGroupLocation, requestLocationId);
            }
            else
            {
                permissionGranted = true;
            }

            return permissionGranted;
        }

        void CreateLocationRequest()
        {
            mLocationRequest = new LocationRequest();
            mLocationRequest.SetInterval(UPDATE_INTERVAL);
            mLocationRequest.SetFastestInterval(FASTEST_INTERVAL);
            mLocationRequest.SetPriority(LocationRequest.PriorityHighAccuracy);
            mLocationRequest.SetSmallestDisplacement(DISPLACEMENT);
            locationClient = LocationServices.GetFusedLocationProviderClient(this);
            mLocationCallback = new LocationCallbackHelper();
            mLocationCallback.MyLocation += MLocationCallback_MyLocation;
            

        }

        private void MLocationCallback_MyLocation(object sender, LocationCallbackHelper.OnLocationCaptureEventArgs e)
        {
            mLastLocation = e.Location;
            LatLng myposititon = new LatLng(mLastLocation.Latitude, mLastLocation.Longitude);
            //tạo hiệu ứng bản đồ
            mainMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(myposititon,12));
                
        }

        //void MLocationCallback_MyLocation(object sender, LocationCallbackHelper.OnLocationCapturedEventArgs e)
        //{
        //    mLastLocation = e.Location;
        //    LatLng myposition = new LatLng(mLastLocation.Latitude, mLastLocation.Longitude);
        //    mainMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(myposition, 12));
        //}


        //void StopLocationUpdates()
        //{
        //    if (locationClient != null && mLocationCallback != null)
        //    {
        //        locationClient.RemoveLocationUpdates(mLocationCallback);
        //    }
        //}

        async void GetMyLocation()
        {
            if (!CheckLocationPermission())
            {
                return;
            }

            mLastLocation = await locationClient.GetLastLocationAsync();
            if (mLastLocation != null)
            {
                LatLng myposition = new LatLng(mLastLocation.Latitude, mLastLocation.Longitude);
                mainMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(myposition, 17));
            }
        }
         
        void StopLocation()
        {
            if(locationClient != null && mLocationCallback != null)
            {
                locationClient.RemoveLocationUpdates(mLocationCallback);
            }
        }


        void StartLocationUpdate() //update location
        {
            if(CheckLocationPermission())
            {
                locationClient.RequestLocationUpdates(mLocationRequest, mLocationCallback, null);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            if(grantResults.Length < 1)
            {
                return;
            }
            if (grantResults[0] == (int)Android.Content.PM.Permission.Granted)
            {
                StartLocationUpdate();
            }
            else
            {
                Toast.MakeText(this, "Permission was denied", ToastLength.Short).Show();

            }
        }


        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 1)
            {
                if (resultCode == Android.App.Result.Ok)
                {
                    var place = PlaceAutocomplete.GetPlace(this, data);
                    pickupLocationText.Text = place.NameFormatted.ToString();
                    mainMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(place.LatLng, 15));
                }
            }

            if (requestCode == 2)
            {
                if (resultCode == Android.App.Result.Ok)
                {
                    var place = PlaceAutocomplete.GetPlace(this, data);
                    destinationText.Text = place.NameFormatted.ToString();
                    mainMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(place.LatLng, 15));
                }
            }
        }

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {

            int id = menuItem.ItemId;

            if (id == Resource.Id.nav_home)
            {
                // Handle the camera action
            }
            //else if (id == Resource.Id.nav_profile)
            //{
            //    Intent intent = new Intent(this, typeof(RegisterActivity));
            //    StartActivity(intent);
            //}
          
            //else if (id == Resource.Id.nav_help)
            //{
                
            //}
         

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;

        }
    }
}