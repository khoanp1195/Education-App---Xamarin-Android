using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Project1.EventListener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Project1
{
    [Activity(Label = "ForgotPass")]
    public class ForgotPass : Activity
    {
        EditText edtEmail;
        LinearLayout linearLayout;
        Button btnRese;
        FirebaseAuth mAuth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ForgotPassword);
            // Create your application here

            //Init Firebase
            mAuth = FirebaseAuth.Instance;
            Control();
         
        }

        public void Control()
        {
            edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            btnRese = FindViewById<Button>(Resource.Id.btnReset);
            btnRese.Click += BtnRese_Click;
            linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
        }
        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }

        private void BtnRese_Click(object sender, EventArgs e)
        {
            string email;
            email = edtEmail.Text;
            if(!email.Contains("@"))
            {
                Snackbar.Make(linearLayout, "Please Enter email have @ ", Snackbar.LengthShort).Show();
              

                Vibrate();
            }


            else
            {
                TaskCompletionListener taskCompletionListener = new TaskCompletionListener();
                taskCompletionListener.Sucess += taskCompletionListener_Success;
                taskCompletionListener.Failure += taskCompletionListioner_Failure;
                mAuth.SendPasswordResetEmail(email)
                    .AddOnSuccessListener(taskCompletionListener)
                    .AddOnFailureListener(taskCompletionListener);
            }
       

            
        }



        private void taskCompletionListener_Success(object sender, EventArgs e)
        {
            Snackbar.Make(linearLayout, "Sent Request SuccessFully. Please Check Mail !!!", Snackbar.LengthShort).Show();
        }

        private void taskCompletionListioner_Failure(object sender, EventArgs e)
        {
            Snackbar.Make(linearLayout, "Sent Request Error!! Please Enter Again", Snackbar.LengthShort).Show();
        }


   
    }
}