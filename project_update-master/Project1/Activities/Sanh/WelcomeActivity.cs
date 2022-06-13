using Android.App;
using Android.Content;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common.Apis;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using Firebase;
using Firebase.Auth;
using Google.Android.Material.Snackbar;
using Project1.Activities.Sanh;
using Project1.EventListener;
using Project1.Fragment;
using Project1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace Project1
{
    [Activity(Label = "WelcomeActivity",NoHistory =true,MainLauncher =false) ]
    public class WelcomeActivity : AppCompatActivity, IOnSuccessListener, IOnFailureListener
    {
        TextView txtSigin;
        TextView btnRegister;
        ImageView finger;
        ImageView imgGoogle;


        //Sigin In Google
        GoogleSignInOptions gso;
        GoogleApiClient googleApiClient;
        FirebaseAuth googlemAuth, mAuth;

        LinearLayout enter, exit, wait1;
        ProgressDialogueFragment progressDialogue;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.wait);

            txtSigin = FindViewById<TextView>(Resource.Id.txtSigin);
            btnRegister = FindViewById<TextView>(Resource.Id.btnRegister);
            wait1 = FindViewById<LinearLayout>(Resource.Id.wait1);

            enter = (LinearLayout)FindViewById(Resource.Id.wait1);
            exit = (LinearLayout)FindViewById(Resource.Id.wait1);


            finger = (ImageView)FindViewById(Resource.Id.imgFinger);
            finger.Click += delegate
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_finger dialog_Support = new dialog_finger();
                dialog_Support.Show(transaction, "Support Here");
            };


            txtSigin.Click += TxtSigin_Click;
            btnRegister.Click += BtnRegister_Click;
            // Create your application here



            //Sign In With Google
            gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                .RequestIdToken("188256006296-udl4ch755crsl6bpbak4tgpusfjk200c.apps.googleusercontent.com")
                .RequestEmail()
                .Build();
            googleApiClient = new GoogleApiClient.Builder(this)
                .AddApi(Auth.GOOGLE_SIGN_IN_API, gso).Build();

            googleApiClient.Connect();
            imgGoogle = FindViewById<ImageView>(Resource.Id.imgGoogle);

            imgGoogle.Click += Signingoogle_Click;
            IntializeDatabase();
        }
        void ShowProgressDialogue(string status)
        {
            progressDialogue = new ProgressDialogueFragment(status);
            var trans = SupportFragmentManager.BeginTransaction();
            progressDialogue.Cancelable = false;
            progressDialogue.Show(trans, "progress");
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
        private void Signingoogle_Click(object sender, EventArgs e)
        {
            var intent = Auth.GoogleSignInApi.GetSignInIntent(googleApiClient);
          
            StartActivityForResult(intent, 1);

        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 1)
            {
                GoogleSignInResult result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                if (result.IsSuccess)
                {
                    GoogleSignInAccount account = result.SignInAccount;
                    LoginWithFirebase(account);
                }

            }
        }
        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }


        private void LoginWithFirebase(GoogleSignInAccount account)
        {
            var credentials = GoogleAuthProvider.GetCredential(account.IdToken, null);
            mAuth.SignInWithCredential(credentials).AddOnSuccessListener(this)
            .AddOnFailureListener(this);
            ShowProgressDialogue("Please wait...");

        }
        private void taskCompletionListener_Failure(object sender, EventArgs e)
        {
            Snackbar.Make(wait1, "SignIn Failed !! Please Again", Snackbar.LengthShort).Show();
        }

        private void taskCompletionListener_Success(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(wait));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);

        }

        public void OnSuccess(Java.Lang.Object result)
        {
            Intent intent = new Intent(this, typeof(wait));
            StartActivity(intent);
        }

        public void OnFailure(Java.Lang.Exception e)
        {
            Vibrate();
            Snackbar.Make(wait1, "SignIn Failed !! Please Again", Snackbar.LengthShort).Show();

        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RegisterActivity));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
        }

        private void TxtSigin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
        }

        //protected override void OnResume()
        //{
        //    base.OnResume();
        //    // StartActivity(typeof(MainActivity)); //resume Mainactivity

        //    FirebaseUser currentUser = AppDataHelper.GetCurrentUser();


        //    if (currentUser != null)
        //    {
        //        StartActivity(typeof(MainActivity2));

        //    }
        //    else
        //    {
        //        StartActivity(typeof(WelcomeActivity));
        //    }



        //}
    }
}