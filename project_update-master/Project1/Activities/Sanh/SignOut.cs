using Android.App;
using Android.Content;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common.Apis;
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

namespace Project1.Acitivties.Sanh
{
    [Activity]
    public class SignOut : Activity
    {

        FirebaseAuth mAuth;
        ImageView backBtn;
        TextView txtName;

        //Sigin In Google
        GoogleSignInOptions gso;
        GoogleApiClient googleApiClient;

        Button cancel, yes;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.signout);
            // Create your application here

            //Init Firebase
            mAuth = FirebaseAuth.Instance;

            txtName = (TextView)FindViewById(Resource.Id.txtName);

            txtName.Text = "Bye Bye !!!" + FirebaseAuth.Instance.CurrentUser.Email;

            backBtn = (ImageView)FindViewById(Resource.Id.backButton);
            backBtn.Click += BackBtn_Click;

         
            cancel = (Button)FindViewById(Resource.Id.cancel);
            cancel.Click += Cancel_Click;

           yes = (Button)FindViewById(Resource.Id.signout);
            yes.Click += Yes_Click;
         
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);


            
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(WelcomeActivity)); 
            StartActivity(intent);
            mAuth.SignOut();

           
            
         
            Finish();
           
     
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
        }
    }
}