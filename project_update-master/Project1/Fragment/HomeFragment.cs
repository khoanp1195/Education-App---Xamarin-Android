using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Firebase;
using Firebase.Database;
using Android.Views;
using Android.Gms.Maps;
using AndroidX.CardView.Widget;
using Android.Support.V7.Widget;
using Android.Content;
using Project1.Activities;
using Project1.Activities.Intro;
using System.Timers;
using System;
using Firebase.Auth;
using Android.Gms.Common;
using Android.Util;

using Project1.Model;
using Project1.Common;
using System.Collections.Generic;
using AndroidX.RecyclerView.Widget;
using Project1.EventListeners;
using Project1.Adapter;
using Project1.Fragment;
using System.Linq;
using Project1.Acitivties.Study;
using Project1.Activities.Study.Course;
using Android.Support.Design.Widget;
using Android.Graphics;
using Android.Support.V4.Widget;
using Project1.Activities.Study.Question;
using Project1.Study;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.IO;
using Project1.Activities.Study.EnglishDictionary;
using Project1.Acitivties;
using Project1.Activities.AddQuestionQuizz;
using Android.Animation;
using Project1.Activities.ScanText;
using Project1.Activities.RestfulApi;
using Project1.Activities.Local_Notification;

namespace Project1.Fragments
{
    public class HomeFragment : Android.Support.V4.App.Fragment
    {

        Android.Support.V7.Widget.CardView cardView1, cardView2, cardView4, cardView5, cardView14, cardView15, cardView16, cardView17,
            cardView21, cardView20, cardView24, cardView30, reply, interviewTip, English, OOP,
            EnglishVideo, MaUI, OOPVideo, AndroidVideo;
        Timer timer;
        EditText searchText, edtSearchh;

        ImageView play1, play2, play3, play4, play5, oclock;
        Button tokenBtn, btnstart;
        TextView timer1, txtName, txtMSG, viewall, viewall2, txtVerified, viewallvideo, setNotification;

        NestedScrollView nestedScrollView;


        //FirebaseAuth

        FirebaseAuth mAuth;


        //TOday Question
        Android.Support.V7.Widget.RecyclerView myRecyclerView, myRecyclerView12;
      


        List<UserQuestion> xamarinList;
        QuestionAdapter adapter;
        QuestionListeners xamarinListeners;


        //Weather
        TextView placeTextView;
        TextView temperatureTextView;
        TextView weatherDescriptionTextView;

        ImageView weatherImageView;

        Button getWeatherButton;
        EditText cityNameText;


        //Bottomsheets
        BottomSheetBehavior welcomeBottomSheetBehavior;



        ImageView circleImageView;



        //Floating Button
        private static bool isFabOpen;
        private FloatingActionButton fabAirballoon;
        private FloatingActionButton fabCake;
        private FloatingActionButton fabMain;
        private FloatingActionButton fabNote;
        private FloatingActionButton fab_tasks;



        //Today Word

        AluminiAdapter adapter1;

        List<Alumini> AluminiList;
        AluminListeners aluminListener;
        ProgressDialogueFragment progressDialogue;

        ListView lstView, lstView1, lstView2, lstView3, lstView11;

        ImageView position;

        //public GoogleMap mainMap;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Log.Debug("Token", "Intance Id Token : " + FirebaseInstanceId.Instance.Token);
           RetriveData();

           

            // Create your fragment here
        }

        [Obsolete]
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
           View view = inflater.Inflate(Resource.Layout.home_fragment, container, false);
            //SupportMapFragment mapFragment = (SupportMapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            //mapFragment.GetMapAsync(this);
            IntializeDatabase();
            RetriveData();
            RetriveData1();
            GetWeather("Saigon");

            viewallvideo = (TextView)view.FindViewById(Resource.Id.viewallvideo);
            viewallvideo.Click += Viewallvideo_Click;
            EnglishVideo = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.EnglishVideo);
            EnglishVideo.Click += EnglishVideo_Click;
            MaUI = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.MaUI);
            MaUI.Click += MaUI_Click;
            OOPVideo = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.OOPVideo);
            OOPVideo.Click += OOPVideo_Click;
            AndroidVideo = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.AndroidVideo);
            AndroidVideo.Click += AndroidVideo_Click;





            oclock = (ImageView)view.FindViewById(Resource.Id.oclock);
            oclock.Click += delegate
            {
                StartActivity(new Intent(Context, typeof(Notification_Activity)));
            };




            circleImageView = (ImageView)view.FindViewById(Resource.Id.circleImageView);
      
            //Bottomsheet
       
            position = (ImageView)view.FindViewById(Resource.Id.position);
            position.Click += Position_Click;

            placeTextView = (TextView)view.FindViewById(Resource.Id.placeText);
            setNotification = (TextView)view.FindViewById(Resource.Id.setNotification);
            setNotification.Click += SetNotification_Click;
          
            weatherDescriptionTextView = (TextView)view.FindViewById(Resource.Id.weatherDescriptionText);
            weatherImageView = (ImageView)view.FindViewById(Resource.Id.weatherImage);


            interviewTip = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.interviewTip);
            interviewTip.Click += InterviewTip_Click;

            weatherImageView.Click += WeatherImageView_Click;
           

            temperatureTextView = (TextView)view.FindViewById(Resource.Id.temperatureTextView);
            getWeatherButton = (Button)view.FindViewById(Resource.Id.getWeatherButton);
            cityNameText = (EditText)view.FindViewById(Resource.Id.cityNameText);
            getWeatherButton.Click += GetWeatherButton_Click;


            viewall2 = (TextView)view.FindViewById(Resource.Id.viewall2);
            viewall2.Click += Viewall2_Click;

            play1 = (ImageView)view.FindViewById(Resource.Id.play1);
            play2 = (ImageView)view.FindViewById(Resource.Id.play2);
            play3 = (ImageView)view.FindViewById(Resource.Id.play3);
            play4 = (ImageView)view.FindViewById(Resource.Id.play4);
            play5 = (ImageView)view.FindViewById(Resource.Id.play5);

            play1.Click += Play1_Click;
            play2.Click += Play2_Click;
            play3.Click += Play3_Click;
            play4.Click += Play4_Click;
            play5.Click += Play5_Click;


         //   nestedScrollView = (NestedScrollView)view.FindViewById(Resource.Id.nestedScrollView1);


            myRecyclerView = (Android.Support.V7.Widget.RecyclerView)view.FindViewById(Resource.Id.recyclerView1);
            myRecyclerView12 = (Android.Support.V7.Widget.RecyclerView)view.FindViewById(Resource.Id.recyclerView12);


          //  btnstart = (Button)view.FindViewById(Resource.Id.btnstart);
           // btnstart.Click += Btnstart_Click;

            viewall = (TextView)view.FindViewById(Resource.Id.viewall);
            viewall.Click += Viewall_Click;

            cardView21 = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.cardView21);
            cardView20 = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.cardView20);
            cardView24 = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.cardView24);
            cardView30 = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.cardView30);

            English = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.English);
            English.Click += English_Click1;
            OOP = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.OOP);
            OOP.Click += OOP_Click; ;
          
          
            reply = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.reply);
            reply.Click += Reply_Click;

            cardView21.Click += CardView21_Click;
            cardView20.Click += CardView20_Click;
            cardView24.Click += CardView24_Click;
            cardView30.Click += CardView30_Click;


            cardView14 = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.cardView14);
            cardView15 = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.cardView15);
            cardView16 = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.cardView16);
            cardView17 = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.cardView17);
            cardView14.Click += CardView14_Click;
            cardView15.Click += CardView15_Click;
            cardView16.Click += CardView16_Click;
            cardView17.Click += CardView17_Click;



            timer1 = (TextView)view.FindViewById(Resource.Id.timer1);

            txtMSG = (TextView)view.FindViewById(Resource.Id.txtMSG);

            txtName = (TextView)view.FindViewById(Resource.Id.txtName);
            searchText = (EditText)view.FindViewById(Resource.Id.edtSearch);
           edtSearchh = (EditText)view.FindViewById(Resource.Id.edtSearchh);


            edtSearchh.TextChanged += EdtSearchh_TextChanged;


           
         //   searchText.TextChanged += SearchText_TextChanged; 



            tokenBtn = (Button)view.FindViewById(Resource.Id.tokenBtn);

             txtName.Text = FirebaseAuth.Instance.CurrentUser.Email;

            lstView = view.FindViewById<ListView>(Resource.Id.lstView);
            lstView1 = view.FindViewById<ListView>(Resource.Id.lstView1);
            lstView2 = view.FindViewById<ListView>(Resource.Id.lstView2);
            lstView3 = view.FindViewById<ListView>(Resource.Id.lstView3);
            lstView11 = view.FindViewById<ListView>(Resource.Id.lstView11);


            DbHelper.DbHelper db5 = new DbHelper.DbHelper(Context);
            List<Ranking> lstRanking5 = db5.GetRanking();
            if (lstRanking5.Count > 0)
            {
                CustomAdapter adapter = new CustomAdapter(Context, lstRanking5);
                lstView11.Adapter = adapter;
            }



            DbHelper.DbHelper db = new DbHelper.DbHelper(Context);
            List<Ranking> lstRanking = db.GetFlagRanking();
            if (lstRanking.Count > 0)
            {
                CustomAdapter adapter = new CustomAdapter(Context, lstRanking);
                lstView.Adapter = adapter;
            }

            DbHelper.DbHelper db1 = new DbHelper.DbHelper(Context);
            List<Ranking> lstRanking1 = db.GetRanking();
            if (lstRanking1.Count > 0)
            {
                CustomAdapter adapter = new CustomAdapter(Context, lstRanking1);
                lstView1.Adapter = adapter;
            }

            DbHelper.DbHelper db2 = new DbHelper.DbHelper(Context);
            List<Ranking> lstRanking2 = db.GetXamarinRanking();
            if (lstRanking2.Count > 0)
            {
                CustomAdapter adapter = new CustomAdapter(Context, lstRanking2);
                lstView2.Adapter = adapter;
            }

            DbHelper.DbHelper db3 = new DbHelper.DbHelper(Context);
            List<Ranking> lstRanking3 = db.GetRanking();
            if (lstRanking3.Count > 0)
            {
                CustomAdapter adapter = new CustomAdapter(Context, lstRanking3);
                lstView3.Adapter = adapter;
            }


            cardView5 = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.cardView5);
            cardView5.Click += delegate
            {
                Intent intent = new Intent(Context, typeof(IntroIQ));

                StartActivity(intent);
                Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
            };






            cardView2 = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.cardView2);

        

            IsPlayServicesAvailable();


            //tokenBtn.Click += delegate
            //{
            //    Log.Debug("Token", "Intance Id Token : " + FirebaseInstanceId.Instance.Token);
            //};

            // Check if user's email is verified
        


            void IntializeDatabase()
            {
                var app = FirebaseApp.InitializeApp(Context);

                if (app == null)
                {
                    var options = new Firebase.FirebaseOptions.Builder()
                    .SetApplicationId("project1-4e850")
                    .SetApiKey("AIzaSyCou_P4H_wbYA3tWisjrOfq2b9nhYIzd7w")
                    .SetDatabaseUrl("https://project1-4e850-default-rtdb.firebaseio.com")
                    .SetStorageBucket("project1-4e850.appspot.com")
                    .Build();

                    app = FirebaseApp.InitializeApp(Context, options);
                    FirebaseDatabase.GetInstance(app).SetPersistenceEnabled(true);
                    //  mAuth = FirebaseAuth.Instance;





                    ///   mDatabase = FirebaseDatabase.GetInstance(app);
                }
                else
                {
                    // mDatabase = FirebaseDatabase.GetInstance(app);
                   
                }
                //  DatabaseReference dbrf = mDatabase.GetReference("UserSupport");
                // dbrf.SetValue("Ticket");

                //Toast.MakeText(this, "Make Test", ToastLength.Short).Show();


             

            }



            cardView1 =  (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.cardView1);

            cardView1.Click += delegate
            {
                Intent intent = new Intent(Context, typeof(HomeGame));
                StartActivity(intent);
                Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
            };

            cardView4 = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.cardView4);


            cardView4.Click += CardView4_Click;





            //Floating Action Button
            fabAirballoon = view.FindViewById<FloatingActionButton>(Resource.Id.fab_airballoon);
            fabCake = view.FindViewById<FloatingActionButton>(Resource.Id.fab_cake);
            fab_tasks = view.FindViewById<FloatingActionButton>(Resource.Id.fab_tasks);
            fab_tasks.Click += (o, e) =>
             {
                 StartActivity(new Intent(Context, typeof(Notes)));
                 CloseFabMenu();
             };


            fabNote = view.FindViewById<FloatingActionButton>(Resource.Id.fab_note);
            fabNote.Click += (o, e) =>
            {
                //if (!isFabOpen)
                //    ShowFabMenu();



                //else
                //    CloseFabMenu();
                StartActivity(new Intent(Context, typeof(ScanTextActivity)));
                CloseFabMenu();


            };

            fabMain = view.FindViewById<FloatingActionButton>(Resource.Id.fab_main);


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
                StartActivity(new Intent(Context, typeof(Calculator)));

            };

            fabAirballoon.Click += (o, e) =>
            {
                CloseFabMenu();
                StartActivity(new Intent(Context, typeof(ContentScanTextActivity)));


            };

            return view;
        }

        private void SetNotification_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(Notification_Activity));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

            private void Viewallvideo_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(InterView_Fragment));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void AndroidVideo_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(AndroidTutorial));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void OOPVideo_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(Csharptutorial));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void MaUI_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(MAUI));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void EnglishVideo_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(OxfordComunication));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void English_Click1(object sender, EventArgs e)
        {
            StartActivity(new Intent(Context, typeof(EnglishComunicationCourse)));
        }

        private void OOP_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Context, typeof(OOPInterview)));
        }

        private void English_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Context, typeof(EnglishComunicationCourse)));
        }

        private void InterviewTip_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Context, typeof(TipInterview)));
        }

        //Floatting Action Button
        private void ShowFabMenu()
        {
            isFabOpen = true;
            fabNote.Visibility = ViewStates.Visible;
            fabAirballoon.Visibility = ViewStates.Visible;
            fabCake.Visibility = ViewStates.Visible;
            fab_tasks.Visibility = ViewStates.Visible;


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



            fab_tasks.Animate()
              .TranslationY(-Resources.GetDimension(Resource.Dimension.standard_195))
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

            fab_tasks.Animate()
                    .TranslationY(0f)
                .Rotation(90f).SetListener(new FabAnimatorListener(fabCake, fabAirballoon));
            fabCake.Animate()
                .TranslationY(0f)
                .Rotation(90f).SetListener(new FabAnimatorListener(fabCake, fabAirballoon));
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





        private void Play5_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(QuestionQuizz));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void Position_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(MainActivity));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView4_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(IntroIQ));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void WeatherImageView_Click(object sender, EventArgs e)
        {
           
                if (cityNameText.Visibility  == Android.Views.ViewStates.Gone && getWeatherButton.Visibility == Android.Views.ViewStates.Gone)
                {
                      cityNameText.Visibility = Android.Views.ViewStates.Visible;
                    getWeatherButton.Visibility = Android.Views.ViewStates.Visible;
                }
                else
                {
                cityNameText.ClearFocus();
                cityNameText.Visibility = Android.Views.ViewStates.Gone;
                getWeatherButton.ClearFocus();
                getWeatherButton.Visibility = Android.Views.ViewStates.Gone;
                }
           
        }

        private void GetWeatherButton_Click(object sender, System.EventArgs e)
        {
            string place = cityNameText.Text;
            GetWeather(place);
            cityNameText.Text = "";
        }
        private void Viewall2_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(TodayWord));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void Play4_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(IntroIQ));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void Play3_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(IntroMath));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void Play2_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(IntroEnglish));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void Play1_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(IntroMath));

            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);

        }

        public void RetriveData1()
        {
            aluminListener = new AluminListeners();
            aluminListener.Create5();

            aluminListener.AluminRetrived += AluminListener_AluminRetrived1;
        }
        private void AluminListener_AluminRetrived1(object sender, AluminListeners.AluminDataEventArgs e)
        {
            AluminiList = e.Alumini;
            SetupRecyClerView1();
        }

        private void SetupRecyClerView1()
        {
            myRecyclerView12.SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(myRecyclerView12.Context));
            adapter1 = new AluminiAdapter(AluminiList);
           


            adapter1.ItemLongClick += Adapter_ItemLongClick1;
            myRecyclerView12.SetAdapter(adapter1);
        }
        private void Adapter_ItemLongClick1(object sender, AluminiAdapterClickEventArgs e)
        {
            Alumini thisAlumini = AluminiList[e.Position];
            EditAluminiFragment editAluminiFragment = new EditAluminiFragment(thisAlumini);
            var trans = FragmentManager.BeginTransaction();
            editAluminiFragment.Show(trans, "edit");
        }



        private void Reply_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(UserReply));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView30_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(Study1));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView24_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(Study1));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView20_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(Study1));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView21_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(Study1));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void Viewall_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(AllCourese));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void EdtSearchh_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
             List<Alumini> SearchResult = new List<Alumini>
                (from alumini in AluminiList
                 where alumini.NewWord.ToLower().Contains(edtSearchh.Text.ToLower()) || alumini.Spelling.ToLower().Contains(edtSearchh.Text.ToLower()) ||
                 alumini.Mean.ToLower().Contains(edtSearchh.Text.ToLower()) || alumini.Level.ToLower().Contains(edtSearchh.Text.ToLower())
                 select alumini).ToList();


            //   myRecyclerView12.Visibility = Android.Views.ViewStates.Visible;

            adapter1 = new AluminiAdapter(SearchResult);
            adapter1.ItemLongClick += Adapter_ItemLongClick1;
            myRecyclerView12.SetAdapter(adapter1);
        }

        ////private void SearchText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        ////{
        ////    List<Alumini> SearchResult1 = new List<Alumini>
        ////      (from alumini in AluminiList
        ////       where alumini.NewWord.ToLower().Contains(searchText.Text.ToLower()) || alumini.Spelling.ToLower().Contains(searchText.Text.ToLower()) ||
        ////       alumini.Mean.ToLower().Contains(searchText.Text.ToLower()) || alumini.Contribute.ToLower().Contains(searchText.Text.ToLower())
        ////       select alumini).ToList();

        ////    if (SearchResult1.ToList() == null)
        ////    {

        ////        //     _ = problemlottie.Visibility == Android.Views.ViewStates.Gone;
        ////        Snackbar snackbar = Snackbar.Make(nestedScrollView, "No Result", Snackbar.LengthShort);
        ////        View snackbarView = snackbar.View;
        ////        snackbarView.SetBackgroundColor(Color.Red);
        ////        snackbar.Show();


        ////    }
        ////    else if (SearchResult1.ToList() != null)
        ////    {
        ////        adapter = new AluminiAdapter(SearchResult1);
        ////    }

        //    //    adapter.DeleteItemClick += Adapter_DeleteItemClick;


        //    adapter.ItemLongClick += Adapter_ItemLongClick1;
        //    myRecyclerView.SetAdapter(adapter);
        //}

        private void Btnstart_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(Study1));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView17_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(HighScore));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView16_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(ScoreXamarin));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView15_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(HighScore));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void CardView14_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Context, typeof(ScoreFlag));
            StartActivity(intent);
            Activity.OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }


        // Retrieve Data User Question
        public void RetriveData()
        {
            xamarinListeners = new QuestionListeners();
            xamarinListeners.Create3();
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
            var trans = Activity.SupportFragmentManager.BeginTransaction();

            editAluminiFragment.Show(trans, "edit");
        }




        private bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(Context);
            if (resultCode != ConnectionResult.Success)
            {

                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    txtMSG.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    txtMSG.Text = "THis device can not connet";
                }

                return false;

            }
            else
            {
               // txtMSG = (TextView)"Connect AVAILABLE";
                return true;
            }
              
        }
               

        public override void OnStart()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            base.OnStart();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            Activity.RunOnUiThread(() => { timer1.Text = dt.ToString(); }); 
        }

        //public void OnMapReady(GoogleMap googleMap)
        //{
        //    mainMap = googleMap;
        //}


        //Get Weeather From Open Weather API
        async void GetWeather(string place)
        {
            string apiKey = "7217ff95e49eab55b03196b592c63415";
            string apiBase = "https://api.openweathermap.org/data/2.5/weather?q=";
            string unit = "metric";

            if (string.IsNullOrEmpty(place))
            {
                Toast.MakeText(Context, "please enter a valid city name", ToastLength.Short).Show();
                return;
            }

            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                Toast.MakeText(Context, "No internet connection", ToastLength.Short).Show();
                return;
            }

            ShowProgressDialogue("Fetching data...");

            // Asynchronous API call using HttpClient
            string url = apiBase + place + "&appid=" + apiKey + "&units=" + unit;
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string result = await client.GetStringAsync(url);

            Console.WriteLine(result);

            var resultObject = JObject.Parse(result);
            string weatherDescription = resultObject["weather"][0]["description"].ToString();
            string icon = resultObject["weather"][0]["icon"].ToString();
           string temperature = resultObject["main"]["temp"].ToString();
            string placename = resultObject["name"].ToString();
            string country = resultObject["sys"]["country"].ToString();
            weatherDescription = System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(weatherDescription);

            weatherDescriptionTextView.Text = weatherDescription;
            placeTextView.Text = placename + ", " + country;
            temperatureTextView.Text = temperature + "°C";


            // Download Image using WebRequest
            string ImageUrl = "http://openweathermap.org/img/w/" + icon + ".png";
            System.Net.WebRequest request = default(System.Net.WebRequest);
            request = WebRequest.Create(ImageUrl);
            request.Timeout = int.MaxValue;
            request.Method = "GET";

            WebResponse response = default(WebResponse);
            response = await request.GetResponseAsync();
            MemoryStream ms = new MemoryStream();
            response.GetResponseStream().CopyTo(ms);
            byte[] imageData = ms.ToArray();

            Bitmap bitmap = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
            weatherImageView.SetImageBitmap(bitmap);


            ClossProgressDialogue();
        }


        //Show Progress Dialog
        void ShowProgressDialogue(string status)
        {
            progressDialogue = new ProgressDialogueFragment(status);
            var trans = FragmentManager.BeginTransaction();
            progressDialogue.Cancelable = false;
            progressDialogue.Show(trans, "progress");
        }


        //Close Progress Dialog
        void ClossProgressDialogue()
        {
            if (progressDialogue != null)
            {
                progressDialogue.Dismiss();
                progressDialogue = null;
            }
        }


    }
}