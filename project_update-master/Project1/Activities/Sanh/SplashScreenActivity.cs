using Android.App;
using Android.Content;  
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.ViewPager.Widget;
using Com.Airbnb.Lottie;
using Firebase.Auth;
using Project1.Helpers;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AndroidX.AppCompat.App;
using Android.Animation;
using Felipecsl.GifImageViewLibrary;
using System.IO;
using System.Timers;

namespace Project1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class SplashScreenActivity : AppCompatActivity
    {
        private ViewPager pager;
        LottieAnimationView lottieAnimationView;
        private GifImageView gifImageView;
        private ProgressBar progressBar;



        TextView txtWait, txtWait1;





        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.splashscreen1);

            gifImageView = FindViewById<GifImageView>(Resource.Id.gifImageView);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);


            txtWait = FindViewById<TextView>(Resource.Id.txtWait);
            txtWait1 = FindViewById<TextView>(Resource.Id.txtWait1);

            Stream input = Assets.Open("education.gif");
            byte[] bytes = ConvertFileToByteArray(input);
            gifImageView.SetBytes(bytes);
            gifImageView.StartAnimation();

            

        }


        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                Toast.MakeText(this, "No internet connection", ToastLength.Short).Show();
                txtWait1.Visibility = ViewStates.Visible;
                txtWait.Visibility = ViewStates.Gone;

                return;
            }
            else
            {
                StartActivity(new Intent(this, typeof(IntroActivity)));
            }
            
        }

        private byte[] ConvertFileToByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }

        }




        protected override void OnResume()
        {
            base.OnResume();
            // StartActivity(typeof(MainActivity)); //resume Mainactivity

            FirebaseUser currentUser = AppDataHelper.GetCurrentUser();


            if(currentUser != null)
            {
                //  StartActivity(typeof(MainActivity2));
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = 6000;
                timer.AutoReset = false;
                timer.Elapsed += Timer_Elapsed1; ;
                timer.Start();
            }
            else
            {
                //  StartActivity(typeof(MyIntro));
                //Wait for 3 seconds and start new Activity
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = 5000;
                timer.AutoReset = false;
                timer.Elapsed += Timer_Elapsed;
                timer.Start();

            }

            //void Timer_Elapsed(object sender, ElapsedEventArgs e)
            //{
            //    StartActivity(new Intent(this, typeof(MainActivity2)));
            //}

        }

        private void Timer_Elapsed1(object sender, ElapsedEventArgs e)
        {
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                Toast.MakeText(this, "No internet connection", ToastLength.Short).Show();
                txtWait1.Visibility = ViewStates.Visible;
                txtWait.Visibility = ViewStates.Gone;
                return;
            }
            else
            {
                StartActivity(new Intent(this, typeof(MainActivity2)));
            }
        }
    }
    }
