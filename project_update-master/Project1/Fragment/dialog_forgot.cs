using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
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

namespace Project1.Fragment
{
    [Obsolete]
    public class dialog_forgot :DialogFragment
    {
        EditText edtEmail;
        LinearLayout linearLayout;
        Button btnRese;
        FirebaseAuth mAuth;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.ForgotPassword, container, false);
            //Init Firebase
            mAuth = FirebaseAuth.Instance;


            //Control
            edtEmail = view.FindViewById<EditText>(Resource.Id.edtEmail);
            btnRese = view.FindViewById<Button>(Resource.Id.btnReset);
            btnRese.Click += BtnRese_Click;
            linearLayout = view.FindViewById<LinearLayout>(Resource.Id.linearLayout1);



            return view;
        }


        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            Dialog.Window.SetLayout(500, 500);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }

        private void BtnRese_Click(object sender, EventArgs e)
        {
            string email;
            email = edtEmail.Text;
            if (!email.Contains("@"))
            {
                Snackbar.Make(linearLayout, "Please Enter email have @ ", Snackbar.LengthShort).Show();
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