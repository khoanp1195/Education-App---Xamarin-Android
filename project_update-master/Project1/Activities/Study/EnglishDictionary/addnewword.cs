using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Database;

using FR.Ganfra.Materialspinner;
using Java.Util;
using Project1.Fragment;
using Project1.Helpers;
using Xamarin.Essentials;
using SupportV7 = Android.Support.V7.App;

namespace Project1.Activities.Study.EnglishDictionary
{
    [Activity(Label = "addnewword")]
    public class addcontent : Activity
    {

        TextInputLayout fullnameText;
        TextInputLayout departmentText;
        ImageView backButton;
        TextInputLayout setText, meanenglishText;
        TextView usercontribute, txtFirebase;
        TextInputLayout exampleText;
        MaterialSpinner statusSpinner, tuloaiSpinner;
        Button submitButton;
        NestedScrollView linearLayout1;

        List<string> statusList;
        List<string> typeList;
        ArrayAdapter<string> adapter;
        string status;
        string tuloai;
        private Context context;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addnewword);
            // Create your application here





            fullnameText = (TextInputLayout)FindViewById(Resource.Id.fullnameText);
            departmentText = (TextInputLayout)FindViewById(Resource.Id.departmentText);
            setText = (TextInputLayout)FindViewById(Resource.Id.setText);
            statusSpinner = (MaterialSpinner)FindViewById(Resource.Id.statusSpinner);
            tuloaiSpinner = (MaterialSpinner)FindViewById(Resource.Id.tuloaiSpinner);
            submitButton = (Button)FindViewById(Resource.Id.submitBtn);

            exampleText = (TextInputLayout)FindViewById(Resource.Id.exampleText);
            backButton = (ImageView)FindViewById(Resource.Id.backButton);

            usercontribute = (TextView)FindViewById(Resource.Id.usercontribute);
            txtFirebase = (TextView)FindViewById(Resource.Id.txtFirebase);

            usercontribute.Text = FirebaseAuth.Instance.CurrentUser.Email; 
            //  usercontribute.Text = FirebaseAuth.Instance.CurrentUser.Email; 
            meanenglishText = (TextInputLayout)FindViewById(Resource.Id.meanenglishText);

            backButton.Click += BackButton_Click;

            IntializeDatabase();

            linearLayout1 = (NestedScrollView)FindViewById(Resource.Id.linearLayout1);

            submitButton.Click += SubmitButton_Click;
            SetupStatusPinner();
            SetupStatusPinner2();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
        }

        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
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

        [Obsolete]
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string newWord = fullnameText.EditText.Text;
            string mean = departmentText.EditText.Text;
            string spelling = setText.EditText.Text;

            string usercontributee = usercontribute.Text;
            usercontributee = FirebaseAuth.Instance.CurrentUser.Email;
            string meanenglish = setText.EditText.Text;
            //  string status = statusSpinner.

            string example = exampleText.EditText.Text;
            


            if (newWord.Length < 1)
            {
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Please enter text", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                Vibrate();
                return;
            }

            else if (newWord.Length < 1)
            {
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Please enter text", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                Vibrate();
                return;
            }

            else if (spelling.Length < 1)
            {
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Please enter text", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                Vibrate();
                return;
            }

            HashMap aluminiInfo = new HashMap();
            aluminiInfo.Put("NewWord", newWord);
            aluminiInfo.Put("Mean", mean);
            aluminiInfo.Put("Spelling", spelling);
            aluminiInfo.Put("Level", status);
            aluminiInfo.Put("Example", example);
             aluminiInfo.Put("Type", tuloai);
            aluminiInfo.Put("MeanEnglish", meanenglish);
            aluminiInfo.Put("UserContribute", usercontributee);
            SupportV7.AlertDialog.Builder saveDataAlert = new SupportV7.AlertDialog.Builder(this);
            saveDataAlert.SetTitle("SAVE ALUMINI INFORMATION");
            saveDataAlert.SetMessage("Are you sure?");
            saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
            {

                if (status == "Normal")
                {

                    DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("Normal").Push();
                    newAluminRef.SetValue(aluminiInfo);
                    saveDataAlert.Dispose();
                    Snackbar snackbar = Snackbar.Make(linearLayout1, "Sorry you don't have permisson", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Red);
                    snackbar.Show();
                }

                else if (status == "Advanced")
                {

                  //  DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("Advanced").Push();
                  //  newAluminRef.SetValue(aluminiInfo);
                   saveDataAlert.Dispose();
                    Snackbar snackbar = Snackbar.Make(linearLayout1, "Sorry you don't have permisson", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Red);
                    snackbar.Show();
                }
                else if (status == "UserContribute")
                {

                    DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("UserContribute").Push();
                    newAluminRef.SetValue(aluminiInfo);
                    saveDataAlert.Dispose();
                    Snackbar snackbar = Snackbar.Make(linearLayout1, "Add Success", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Green);
                    snackbar.Show();
                }
                //DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("alumini").Push();
                //    newAluminRef.SetValue(aluminiInfo);
                //    this.Dismiss();
            });
            saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {
                saveDataAlert.Dispose();
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Add Failed !!", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
            });

            saveDataAlert.Show();

        //    FirebaseMessaging.Instance.SubscribeToTopic(usercontribute.Text + "your_topic_name");
          //Log.Debug("Token","Instance ID Token" + FirebaseInstanceId.Instance.Token);

        }

        //Spinner Type
        public void SetupStatusPinner2()
        {
            typeList = new List<string>();
            typeList.Add("n");
            typeList.Add("v");
            typeList.Add("Adv");
            typeList.Add("Adj");

            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, typeList);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            tuloaiSpinner.Adapter = adapter;
            tuloaiSpinner.ItemSelected += TuloaiSpinner_ItemSelected;
            IsPlayServicesAvailable();
        }

        private void TuloaiSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                tuloai = typeList[e.Position];
            }
        }


        private bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if(resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    txtFirebase.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    txtFirebase.Text = "not support";
                }
                return false;

            }
            else
            {
                txtFirebase.Text = "GPLAYSERVICES is available";
                return true;
            }
        }


        //SPiner Level
        public void SetupStatusPinner()
        {
            statusList = new List<string>();
           // statusList.Add("Normal");
            statusList.Add("UserContribute");
            //statusList.Add("Advanced");
            ///statusList.Add("Comunication");
            //statusList.Add("None");

            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, statusList);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            statusSpinner.Adapter = adapter;
            statusSpinner.ItemSelected += StatusSpinner_ItemSelected;
        }

        private void StatusSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                status = statusList[e.Position];
            }
        }

    }
}