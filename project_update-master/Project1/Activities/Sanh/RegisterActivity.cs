using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Auth;
using Firebase.Database;
using Firebase;
using System.Text.RegularExpressions;
using Android.Util;
using Google.Android.Material.Snackbar;
using AndroidX.ConstraintLayout.Widget;
using Android.Gms.Tasks;
using Project1.EventListener;
using Java.Util;
using Xamarin.Essentials;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Firebase.Firestore;
using Project1.Helpers;

namespace Project1
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : AppCompatActivity
    {
        EditText fullname, email, password, phone, confirm_password;
        ImageView btnback;
        Button btnRegister;
        TextView signin;


        //Firebase Auth,Firebase Database, FireStore
        FirebaseAuth mAuth;
        FirebaseDatabase mDatabase;
        FirebaseFirestore database;

        NestedScrollView registerLayout, enter, exit;
        TaskCompletionListener taskCompletionListener = new TaskCompletionListener();
        string fullName, Email, Password, Phone, confirmpassword;

        ISharedPreferences preferences = Application.Context.GetSharedPreferences("userInfo", FileCreationMode.Private);
        ISharedPreferencesEditor editor;
        ProgressDialogueFragment progressDialogue;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);
            ConnectControl();

            IntializeDatabase();
            RetriveData();
            SaveToShareReference();
            mAuth = FirebaseAuth.Instance;

            // Create your application here
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
                mDatabase = FirebaseDatabase.GetInstance(app);
            }
            else
            {
                mDatabase = FirebaseDatabase.GetInstance(app);
            }
          //  DatabaseReference dbrf = mDatabase.GetReference("UserSupport");
           // dbrf.SetValue("Ticket");

            //Toast.MakeText(this, "Make Test", ToastLength.Short).Show();
        }


        void ConnectControl()
        {
          //  btnback = (ImageView)FindViewById(Resource.Id.btnback);
        



            enter = (NestedScrollView)FindViewById(Resource.Id.nestedScrollView1);
            exit = (NestedScrollView)FindViewById(Resource.Id.nestedScrollView1);

            confirm_password = (EditText)FindViewById(Resource.Id.confirm_password);

            fullname = (EditText)FindViewById(Resource.Id.editName);
            email = (EditText)FindViewById(Resource.Id.edt_email);
            signin = (TextView)FindViewById(Resource.Id.signin);
            signin.Click += Signin_Click;
            password = (EditText)FindViewById(Resource.Id.edt_password);
            phone = (EditText)FindViewById(Resource.Id.edt_phone);
            registerLayout = (NestedScrollView)FindViewById(Resource.Id.nestedScrollView1);


            database = AppDataHelper.GetFirestore();
            mAuth = AppDataHelper.GetFirebaseAuth();

            btnRegister = (Button)FindViewById(Resource.Id.button);
            btnRegister.Click += btnRegisterClick;
        }

 
        private void Signin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(LoginActivity));
            //Vibrator vibrator = (Vibrator)GetSystemService(Context.VibratorService);
            //vibrator.Vibrate(100);

         
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.EnterFromRight, Resource.Animation.abc_popup_enter);
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

        private void btnRegisterClick(object sender, EventArgs e)
        {
          
            fullName = fullname.Text;
            Email = email.Text;
            Password = password.Text;
            confirmpassword = confirm_password.Text;
            Phone = phone.Text;


            if(fullName.Length <= 3)
            {
                Snackbar.Make(registerLayout, "Maybe this is not your full name ? Please Again", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }

            else if (Phone.Length <= 6)
            {
                Snackbar.Make(registerLayout, "Sorry Please Again", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }
            else if(!Email.Contains('@'))
            {
                Snackbar.Make(registerLayout, "Email you enter the wrong format ", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }
            else if(Password.Length <= 6)
            {
                Snackbar.Make(registerLayout, "Password Requries > 6 characters ", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }
            else if (confirmpassword != Password)
            {
                Snackbar.Make(registerLayout, "Password is not matching", Snackbar.LengthShort).Show();
               
                
                Vibrate();
                return;
            }
      ;


            ShowProgressDialogue("Registering you..");
            RegisterUser(fullName, Phone, Email, Password);
        //    ShowProgressDialogue("Fetching weather...");

          //  Intent intent = new Intent(this,typeof(LoginActivity));
           // StartActivity(intent);
        }

        void RegisterUser(string fullname, string phone, string email, string password)
        {
            taskCompletionListener.Sucess += taskCompletionListener_Success;
            taskCompletionListener.Failure += taskCompletionListener_Failure;

            mAuth.CreateUserWithEmailAndPassword(email, password)
                .AddOnSuccessListener(this, taskCompletionListener)
                .AddOnFailureListener(this, taskCompletionListener);
        
        }

        private void taskCompletionListener_Failure(object sender, EventArgs e)
        {
            CloseProgressDialogue();
            Snackbar.Make(registerLayout, "Register Fail", Snackbar.LengthShort).Show();
        }

        private void taskCompletionListener_Success(object sender, EventArgs e)
        {
            Snackbar.Make(registerLayout, "Register Success", Snackbar.LengthShort).Show();
            HashMap userMap = new HashMap();

            userMap.Put("email", Email);
            userMap.Put("fullname", fullName);
            userMap.Put("phone", Phone);

            // DatabaseReference userReference = mDatabase.GetReference("users/" + mAuth.CurrentUser.Uid);
            // userReference.SetValue(userMap);

            DocumentReference userReference = database.Collection("users").Document(mAuth.CurrentUser.Uid);
           userReference.Set(userMap);
      
            CloseProgressDialogue();
            StartActivity(typeof(LoginActivity));
            Finish();


        }

        void SaveToShareReference()
        {
            ISharedPreferences preferences = Application.Context.GetSharedPreferences("userInfo", FileCreationMode.Private);//FileCreationMode tệp thông tin người dùng chế độ private
            ISharedPreferencesEditor editor;
            editor = preferences.Edit();
            editor.PutString("email", (string)email);
            editor.PutString("fulname", (string)fullname);
            editor.PutString("phone", (string)phone);

            editor.Apply();


        }

        void RetriveData()
        {
            string email = preferences.GetString("email", "");
        }





        void ShowProgressDialogue(string status)
        {
            progressDialogue = new ProgressDialogueFragment(status);
            var trans = SupportFragmentManager.BeginTransaction();
            progressDialogue.Cancelable = false;
            progressDialogue.Show(trans, "Progress");
        }

        void CloseProgressDialogue()
        {
            if (progressDialogue != null)
            {
                progressDialogue.Dismiss();
                progressDialogue = null;
            }
        }



    }
    }
