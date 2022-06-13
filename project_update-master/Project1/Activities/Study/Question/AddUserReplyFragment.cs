using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using FR.Ganfra.Materialspinner;
using Java.Util;
using Project1.Helpers;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Xamarin.Essentials;
using SupportV7 = Android.Support.V7.App;

namespace Project1.Activities.Study.Question
{
    public class AddUserReplyFragment : Android.Support.V4.App.DialogFragment
    {

        TextInputLayout fullnameText;
        TextInputLayout departmentText;
        TextInputLayout setText;
        MaterialSpinner statusSpinner;
        TextView timer1;
        Button submitButton;
        LinearLayout linearLayout1;
        System.Timers.Timer timer;
        List<string> statusList;
        string category;
        List<UserQuestion> AluminiList;
        ArrayAdapter<string> adapter;
        string status;
        private Context context;

        UserQuestion thisQuestion;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.newEnglish, container, false);

            fullnameText = (TextInputLayout)view.FindViewById(Resource.Id.fullnameText);
            departmentText = (TextInputLayout)view.FindViewById(Resource.Id.departmentText);
            setText = (TextInputLayout)view.FindViewById(Resource.Id.setText);
            statusSpinner = (MaterialSpinner)view.FindViewById(Resource.Id.statusSpinner);
            submitButton = (Button)view.FindViewById(Resource.Id.submitBtn);

            timer1 = (TextView)view.FindViewById(Resource.Id.timer);
            linearLayout1 = (LinearLayout)view.FindViewById(Resource.Id.linearLayout1);

            //submitButton.Click += SubmitButton_Click;


            submitButton.Click += SubmitButton_Click; 


            SetupStatusPinner();
            IntializeDatabase();

            return view;
        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {


            string title = fullnameText.EditText.Text;
            //string category = departmentText.EditText.Text;
            string content = departmentText.EditText.Text;


            DateTime dt = DateTime.Now;
            timer1.Text = dt.ToString();
            string timer = timer1.Text;

            string contribute = setText.EditText.Text;
            contribute = FirebaseAuth.Instance.CurrentUser.Email;
            //     string category = statusSpinner.Text;


            if (title.Length < 1)
            {
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Please enter text", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                Vibrate();
                return;
            }

            else if (content.Length < 1)
            {
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Please enter text", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                Vibrate();
                return;
            }



            HashMap aluminiInfo = new HashMap();
            aluminiInfo.Put("Title", title);
            aluminiInfo.Put("Content", content);
            aluminiInfo.Put("User", contribute);
            aluminiInfo.Put("Category", category);
            aluminiInfo.Put("Timer", timer);

            SupportV7.AlertDialog.Builder saveDataAlert = new SupportV7.AlertDialog.Builder(Activity);
            saveDataAlert.SetTitle("SAVE ALUMINI INFORMATION");
            saveDataAlert.SetMessage("Are you sure?");
            saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
            {

                // string key = AluminiList[e.Position].ID;
                //  AppDataHelper.GetDatabase().GetReference("UserReply/" + thisQuestion.ID + "/NewWord").Push().SetValue(title);
                // DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("UserReply").Push();
                //newAluminRef.SetValue(aluminiInfo);
                //this.Dismiss();

                //DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("alumini").Push();
                //    newAluminRef.SetValue(aluminiInfo);
                //    this.Dismiss();

                DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("UserReply").Push();
                newAluminRef.SetValue(aluminiInfo);
                saveDataAlert.Dispose();
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Sent Your Reply Sucess", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Green);
                snackbar.Show();


                //if (status == "Xamarin")
                //{

              
                //}

                //else if (status == "English")
                //{

                //    DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("UserReply").Push();
                //    newAluminRef.SetValue(aluminiInfo);
                //    saveDataAlert.Dispose();
                //    Snackbar snackbar = Snackbar.Make(linearLayout1, "Sent Your Reply Sucess", Snackbar.LengthShort);
                //    View snackbarView = snackbar.View;
                //    snackbarView.SetBackgroundColor(Color.Green);
                //    snackbar.Show();
                //}
                //else if (status == "OOP")
                //{

                //    DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("UserReply").Push();
                //    newAluminRef.SetValue(aluminiInfo);
                //    saveDataAlert.Dispose();
                //    Snackbar snackbar = Snackbar.Make(linearLayout1, "Sent Your Reply Sucess", Snackbar.LengthShort);
                //    View snackbarView = snackbar.View;
                //    snackbarView.SetBackgroundColor(Color.Green);
                //    snackbar.Show();
                //}

                //else if (status == "Angular")
                //{

                //    DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("UserReply").Push();
                //    newAluminRef.SetValue(aluminiInfo);
                //    saveDataAlert.Dispose();
                //    Snackbar snackbar = Snackbar.Make(linearLayout1, "Sent Your Reply Sucess", Snackbar.LengthShort);
                //    View snackbarView = snackbar.View;
                //    snackbarView.SetBackgroundColor(Color.Green);
                //    snackbar.Show();
                //}

                //else if (status == "UserResponse")
                //{

                //    DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("UserResponse").Push();
                //    newAluminRef.SetValue(aluminiInfo);
                //    saveDataAlert.Dispose();
                //    Snackbar snackbar = Snackbar.Make(linearLayout1, "Sent Your Reply Sucess", Snackbar.LengthShort);
                //    View snackbarView = snackbar.View;
                //    snackbarView.SetBackgroundColor(Color.Green);
                //    snackbar.Show();
                //}



            });
            saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {
                saveDataAlert.Dispose();
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Send Failed !!", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
            });

            saveDataAlert.Show();


        }

        // AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/NewWord").SetValue(newWord);

        void IntializeDatabase()
        {
            var app = FirebaseApp.InitializeApp(Context);

            if (app == null)
            {
                var options = new Firebase.FirebaseOptions.Builder()
                .SetApplicationId("project1-4e850")
                .SetApiKey("AIzaSyCou_P4H_wbYA3tWisjrOfq2b9nhYIzd7w")
                .SetDatabaseUrl("https://project1-4e850-default-rtdb.firebaseio.com")
                .SetStorageBucket("project1-4e850.appspot.com")
                .Build();

                app = FirebaseApp.InitializeApp(Context, options);
                FirebaseDatabase.GetInstance(app).SetPersistenceEnabled(true);
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

        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }

        public void SetupStatusPinner()
        {
            statusList = new List<string>();
            statusList.Add("Xamarin");
            statusList.Add("English");
            statusList.Add("OOP");
            statusList.Add("Angular");
            statusList.Add("UserResponse");

            adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleSpinnerDropDownItem, statusList);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            statusSpinner.Adapter = adapter;
            statusSpinner.ItemSelected += StatusSpinner_ItemSelected;
        }

        private void StatusSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (e.Position != -1)
            {
                category = statusList[e.Position];
            }
        }


        public override void OnStart()
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
            Activity.RunOnUiThread(() => { timer1.Text = dt.ToString(); });
        }
    }
}