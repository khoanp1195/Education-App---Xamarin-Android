using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Java.Util;
using Project1.Activities.Intro;
using Project1.Helpers;
using Xamarin.Essentials;
namespace Project1.Activities
{
    [Activity(Label = "Done", Theme = "@style/AppTheme")]
    public class DoneFlag : Activity
    {
        System.Timers.Timer timer;
        CardView btnTryAgain, homebtn, sentscore;
        TextView txtTotalScore, txtTotalQuestion, textView, userName, timerr;
        ProgressBar progressBarResult;
        ImageView btncamera, screenshot, pic_iq;
        NestedScrollView nestedScrollView1;
        [Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Done2);

            DbHelper.DbHelper db = new DbHelper.DbHelper(this);
            Vibrate();
            nestedScrollView1 = (NestedScrollView)FindViewById(Resource.Id.nestedScrollView1);



            sentscore = FindViewById<CardView>(Resource.Id.sentscore);
            sentscore.Click += Sentscore_Click;

            IntializeDatabase();

            userName = FindViewById<TextView>(Resource.Id.userName);
            userName.Text = FirebaseAuth.Instance.CurrentUser.Email;
            timerr = FindViewById<TextView>(Resource.Id.timer);

            //btncamera = FindViewById<ImageView>(Resource.Id.btnCamera);
            ///  btncamera.Click += Btncamera_Click;
            //  screenshot = FindViewById<ImageView> (Resource.Id.screenshot);

            btnTryAgain = FindViewById<CardView>(Resource.Id.btnTryAgain);
            txtTotalQuestion = FindViewById<TextView>(Resource.Id.txtTotalQuestion);
            txtTotalScore = FindViewById<TextView>(Resource.Id.txtTotalScore);
            progressBarResult = FindViewById<ProgressBar>(Resource.Id.doneProgressBar);
            pic_iq = FindViewById<ImageView>(Resource.Id.pic_iq);
            textView = FindViewById<TextView>(Resource.Id.textView);

            homebtn = FindViewById<CardView>(Resource.Id.homebtn);

            homebtn.Click += Homebtn_Click;

            btnTryAgain.Click += delegate
            {
                Intent intent = new Intent(this, typeof(IntroIQ));
                StartActivity(intent);
                Finish();
            };


            //Get Data
            Bundle bundle = Intent.Extras;
            if (bundle != null)
            {
                int score = bundle.GetInt("SCORE");
                int totalQuestion = bundle.GetInt("TOTAL");
                int correctAnswer = bundle.GetInt("CORRECT");

                //Update 2.0
                //int playCount = 0;
                //if(totalQuestion == 30) // EASY MODE
                //{
                //    playCount = db.GetPlayCount(0);
                //    playCount++;
                //    db.UpdatePlayCount(0, playCount);
                //}
                //else if (totalQuestion == 50) // MEDIUM MODE
                //{
                //    playCount = db.GetPlayCount(1);
                //    playCount++;
                //    db.UpdatePlayCount(1, playCount);
                //}
                //else if (totalQuestion == 100) // HARD MODE
                //{
                //    playCount = db.GetPlayCount(2);
                //    playCount++;
                //    db.UpdatePlayCount(2, playCount);
                //}
                //else if (totalQuestion == 200) // HARDEST MODE
                //{
                //    playCount = db.GetPlayCount(3);
                //    playCount++;
                //    db.UpdatePlayCount(3, playCount);
                //}

                //   int minus = ((int)((5.0 / (int)score) * 100)); //* (playCount - 1);
                int finalScore = score;
                //- minus;

                ///  txtTotalScore.Text = $"Ch? s? IQ c?a b?n là : {finalScore.ToString("0.00")}";


                if (finalScore > 0 && finalScore <= 60)
                {
                    txtTotalScore.Text = $"Your Result is : {finalScore.ToString("0.00")} \n It is very low. We recommend studying every day.";


                    //    pic_iq.Resources.GetDrawable(Resource.Drawable.stupidguy);
                    textView.Text = "Very Bad !!!!!";
                    pic_iq.SetImageResource(Resource.Drawable.stupidguy);




                }
                else if (finalScore > 60 && finalScore < 110)
                {
                    txtTotalScore.Text = $"Your IQ is : {finalScore.ToString("0.00")} \n It is Normal. We recommend studying every day.";



                }

                else if (finalScore > 130 && finalScore < 170)
                {
                    txtTotalScore.Text = $"Your IQ is : {finalScore.ToString("0.00") } \n You are genius";
                    pic_iq.Resources.GetDrawable(Resource.Drawable.albert);


                }
                //     + $"(-{5*(playCount-1)}%";
                txtTotalQuestion.Text = $"PASSED : {correctAnswer}/{totalQuestion}";

                progressBarResult.Max = totalQuestion;
                progressBarResult.Progress = correctAnswer;

                //Save score
                db.InsertFlagScore(finalScore);
            }
        }

        private void Sentscore_Click(object sender, EventArgs e)
        {

            //Get Data
            Bundle bundle = Intent.Extras;

            int score = bundle.GetInt("SCORE");
            string userName = FirebaseAuth.Instance.CurrentUser.Email;


            DateTime dt = DateTime.Now;
            timerr.Text = dt.ToString();
            string timer = timerr.Text;



            HashMap userrankingInfo = new HashMap();
            userrankingInfo.Put("Score", score);
            userrankingInfo.Put("Name", userName);
            userrankingInfo.Put("Time", timer);

            DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("UserFlagRanking").Push();
            newAluminRef.SetValue(userrankingInfo);
            Snackbar snackbar = Snackbar.Make(nestedScrollView1, "Sent Score Success !!!", Snackbar.LengthShort);
            View snackbarView = snackbar.View;
            snackbarView.SetBackgroundColor(Color.Green);
            snackbar.Show();
            if (sentscore.Visibility == Android.Views.ViewStates.Visible)
            {
                sentscore.Visibility = Android.Views.ViewStates.Gone;
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


        private void Homebtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
            Finish();
        }

        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }
        private async void Btncamera_Click(object sender, EventArgs e)
        {

        }
        protected override void OnStart()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            base.OnStart();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            RunOnUiThread(() => { timerr.Text = dt.ToString(); });
        }


    }
}