using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Google.Android.Material.Snackbar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static Android.Views.View;

namespace Project1.Activities.Profile
{
    [Activity(Label = "Profile_Activity")]
    public class Profile_Activity : Activity, IOnClickListener, IOnCompleteListener
    {
        ImageView backButton;
        TextView txtName;
        Button btnResetPass, btnChangePass, btnChangePass1;
        EditText edtChangePass, edtChangePass1;

        LinearLayout linearLayout1;


        FirebaseAuth auth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.profile);

            backButton = FindViewById<ImageView>(Resource.Id.backButton);

            backButton.Click += BackButton_Click;

            txtName = FindViewById<TextView>(Resource.Id.txtName);


            edtChangePass = (EditText)FindViewById<EditText>(Resource.Id.edtChangePass);
            edtChangePass1 = (EditText)FindViewById<EditText>(Resource.Id.edtChangePass1);


            linearLayout1=(LinearLayout)FindViewById(Resource.Id.linearLayout1);

            txtName.Text = FirebaseAuth.Instance.CurrentUser.Email;

            btnChangePass1 = (Button)FindViewById<Button>(Resource.Id.btnChangePass1);

        
            btnChangePass = FindViewById<Button>(Resource.Id.btnChangePass1);
            btnChangePass1.Click += BtnChangePass1_Click;

            btnChangePass.Click += BtnChangePass_Click;

            edtChangePass = FindViewById<EditText>(Resource.Id.edtChangePass);

            IntializeDatabase();





            
        }

        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }
        private void BtnChangePass1_Click(object sender, EventArgs e)
        {
            string Password,ConfirmPassword;
            Password = edtChangePass.Text;
            ConfirmPassword = edtChangePass1.Text;
            if (Password.Length <= 6)
            {
                Snackbar.Make(linearLayout1, "Password Requries > 6 characters ", Snackbar.LengthShort).Show();
                Vibrate();
                return;
            }
            else if (ConfirmPassword != Password)
            {
                Snackbar.Make(linearLayout1, "Password is not matching", Snackbar.LengthShort).Show();


                Vibrate();
                return;
            }

            ChangePassword(edtChangePass.Text);
        }

        private void BtnChangePass_Click(object sender, EventArgs e)
        {
            //if (edtChangePass.Visibility == Android.Views.ViewStates.Gone || btnChangePass1.Visibility == Android.Views.ViewStates.Gone)
            //{
            //    edtChangePass.Visibility = Android.Views.ViewStates.Visible;
            //    btnChangePass1.Visibility = Android.Views.ViewStates.Visible;
             
            //}
            //else
            //{
            //    edtChangePass.ClearFocus();
            //    edtChangePass.Visibility = Android.Views.ViewStates.Gone;
            //}

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
                //  mDatabase = FirebaseDatabase.GetInstance(app);

                //Init Firebase
                auth = FirebaseAuth.GetInstance(app);

            }
            else
            {
                ///  mDatabase = FirebaseDatabase.GetInstance(app);
            }
            //  DatabaseReference dbrf = mDatabase.GetReference("UserSupport");
            // dbrf.SetValue("Ticket");
            auth = FirebaseAuth.GetInstance(app);
            //Toast.MakeText(this, "Make Test", ToastLength.Short).Show();
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
        }

        private void ChangePassword(string newPassword)
        {

           
            Android.Support.V7.App.AlertDialog.Builder deleteAlumini = new Android.Support.V7.App.AlertDialog.Builder(this);
            deleteAlumini.SetTitle("Change Password");
            deleteAlumini.SetMessage("Are you sure?");
            deleteAlumini.SetPositiveButton("Continue", (deleteAlert, args) =>
            {
                // Deletes Alumini From the Database
                ///  aluminListener.DeleteNormal(key);

                Snackbar snackbar = Snackbar.Make(linearLayout1, "Your Password Changed", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Green);
                snackbar.Show();
                FirebaseUser user = auth.CurrentUser;
            
                user.UpdatePassword(newPassword)
                    .AddOnCompleteListener(this);

            });

            deleteAlumini.SetNegativeButton("Cancel", (deleteAlert, args) =>
            {
                deleteAlumini.Dispose();
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Changing Failed", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
            });

            deleteAlumini.Show();
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful == true)
            {
                Snackbar snackBar = Snackbar.Make(linearLayout1, "Password has been changed", Snackbar.LengthShort);
                snackBar.Show();
            }
        }

        public void OnClick(View v)
        {
            throw new NotImplementedException();
        }

      
    }
}