using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.Nfc;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Project1.Activities.Intro;
using Project1.Fragment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities.Sanh
{
    [Activity(Label = "wait")]
    public class wait : Activity, IOnCompleteListener
    {
        CardView home, play, test;
        TextView txtName, signout, txtNamee, txtWelcome, txtEmailVerified;
        Button btnHome, btnverifiedcode;
        //Bottomsheets
        BottomSheetBehavior welcomebackBottonsheetBehavior, howtoPlayBottomsheetBehavior;
        FirebaseAuth mAuth;
        FirebaseUser user;

        public void OnComplete(Task task)
        {

            Toast.MakeText(this, "Send Email Success", ToastLength.Short).Show();


        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.sanh2);


            IntializeDatabase();

            btnverifiedcode = (Button)FindViewById(Resource.Id.btnverifiedcode);
            txtWelcome = (TextView)FindViewById(Resource.Id.txtWelcome);
            txtEmailVerified = (TextView)FindViewById(Resource.Id.txtEmailVerified);

            test = (CardView)FindViewById(Resource.Id.test);
            test.Click += Test_Click;


            mAuth = FirebaseAuth.Instance;
            user = mAuth.CurrentUser;

            btnHome = (Button)FindViewById(Resource.Id.btnHome);

            if (!user.IsEmailVerified)
            {
                btnverifiedcode.Visibility = ViewStates.Visible;
                btnHome.Visibility = ViewStates.Gone;

                txtWelcome.Visibility = ViewStates.Gone;
                txtEmailVerified.Visibility = ViewStates.Visible;


                btnverifiedcode.Click += delegate
                {
                    user.SendEmailVerification()
                        .AddOnCompleteListener(this);
                    Toast.MakeText(this, "Send Email Success", ToastLength.Short).Show();
                };

            }

                txtNamee = (TextView)FindViewById(Resource.Id.txtNamee);
                txtNamee.Text = "Hello " + FirebaseAuth.Instance.CurrentUser.Email;

                signout = (TextView)FindViewById(Resource.Id.signout);
                signout.Click += Signout_Click;

                // Create your application here

                btnHome.Click += BtnHome_Click;

                txtName = (TextView)FindViewById(Resource.Id.txtName);
                txtName.Text = FirebaseAuth.Instance.CurrentUser.Email;
                home = (CardView)FindViewById(Resource.Id.home);
                home.Click += Home_Click;

                play = (CardView)FindViewById(Resource.Id.test);
                play.Click += Play_Click;


                //Bottomsheet
                FrameLayout howtoplayDetailsView = (NestedScrollView)FindViewById(Resource.Id.howtoplay_bottomsheet);
                ///    howtoPlayBottomsheetBehavior = BottomSheetBehavior.From(howtoplayDetailsView);
                FrameLayout welcomebackDetailsView = (CardView)FindViewById(Resource.Id.welcomeback_bottomsheet);
                welcomebackBottonsheetBehavior = BottomSheetBehavior.From(welcomebackDetailsView);

            }

        [Obsolete]
        private void Test_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_support dialog_Support = new dialog_support();
            dialog_Support.Show(transaction, "Support Here");
        }

        void IntializeDatabase()
            {
                var app = FirebaseApp.InitializeApp(this);



                if (app == null)
                {
                    var options = new FirebaseOptions.Builder()
                    .SetApplicationId("project1-4e850")
                    .SetApiKey("AIzaSyCou_P4H_wbYA3tWisjrOfq2b9nhYIzd7w")
                    .SetDatabaseUrl("https://project1-4e850-default-rtdb.firebaseio.com")
                    .SetStorageBucket("project1-4e850.appspot.com")
                    .Build();

                    app = FirebaseApp.InitializeApp(this, options);
                    mAuth = FirebaseAuth.Instance;

                }
                else
                {

                    mAuth = FirebaseAuth.Instance;
                }


            }
            void Home_Click(object sender, System.EventArgs e)
            {
                welcomebackBottonsheetBehavior.State = BottomSheetBehavior.StateExpanded;
            }


            void Signout_Click(object sender, EventArgs e)
            {
                Intent intent = new Intent(this, typeof(WelcomeActivity));
                StartActivity(intent);
                Finish();
            }

            void BtnHome_Click(object sender, EventArgs e)
            {
                Intent intent = new Intent(this, typeof(MainActivity2));
                StartActivity(intent);
            }

            void Play_Click(object sender, EventArgs e)
            {
            //    howtoPlayBottomsheetBehavior.State = BottomSheetBehavior.StateExpanded;
            }



        }
    }
