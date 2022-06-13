using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Firebase;
using Firebase.Database;
using Android.Views;
using Android.Gms.Maps;
using AndroidX.CardView.Widget;
using Android.Support.V7.Widget;
using Android.Content;
using Project1.Activities;
using Project1.Activities.Intro;
using System.Timers;
using System;
using Firebase.Auth;
using Android.Gms.Common;
using Android.Util;
using SupportV7 = Android.Support.V7.App;

using Project1.Model;
using Project1.Common;
using System.Collections.Generic;
using AndroidX.RecyclerView.Widget;
using Project1.EventListeners;
using Project1.Adapter;
using Project1.Fragment;
using System.Linq;
using Project1.Acitivties.Study;
using Android.Support.Design.Widget;
using FR.Ganfra.Materialspinner;
using Xamarin.Essentials;
using Android.Graphics;
using Java.Util;
using Project1.Helpers;

namespace Project1.Fragment
{
    public class AddNoteFragment : Android.Support.V4.App.DialogFragment
    { 
        TextInputLayout titleText;
        TextInputLayout contentText;
        TextInputLayout timerText;
      
        TextView timer1;
        Button submitButton;
        LinearLayout linearLayout1;
        System.Timers.Timer timer;
        List<string> statusList;
        string category;
        List<Notees> noteList;
        ArrayAdapter<string> adapter;
        string status;
        private Context context;

        Notees thisNotes;

     

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            View view = inflater.Inflate(Resource.Layout.addNotes, container, false);

            titleText = (TextInputLayout)view.FindViewById(Resource.Id.titleText);
            contentText = (TextInputLayout)view.FindViewById(Resource.Id.contentText);
        
         
            submitButton = (Button)view.FindViewById(Resource.Id.btnAdd);

            timer1 = (TextView)view.FindViewById(Resource.Id.timer);
            linearLayout1 =(LinearLayout)view.FindViewById(Resource.Id.linearLayout1);

            //submitButton.Click += SubmitButton_Click;


            submitButton.Click += SubmitButton_Click; ;

        
      
            IntializeDatabase();

            return view;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

            
                string title = titleText.EditText.Text;
                //string category = departmentText.EditText.Text;
                string content = contentText.EditText.Text;


                DateTime dt = DateTime.Now;
                timer1.Text = dt.ToString();
                string timer = timer1.Text;

          
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
      
                aluminiInfo.Put("Timer", timer);

                SupportV7.AlertDialog.Builder saveDataAlert = new SupportV7.AlertDialog.Builder(Activity);
                saveDataAlert.SetTitle("SAVE NOTES INFORMATION");
                saveDataAlert.SetMessage("Are you sure?");
                saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
                {


                    DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("Notes").Push();
                    newAluminRef.SetValue(aluminiInfo);
                    saveDataAlert.Dispose();
                    Snackbar snackbar = Snackbar.Make(linearLayout1, "Add Success!!", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Green);
                    snackbar.Show();




                    //DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("alumini").Push();
                    //    newAluminRef.SetValue(aluminiInfo);
                    //    this.Dismiss();
                });
                saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    saveDataAlert.Dispose();
                    Snackbar snackbar = Snackbar.Make(linearLayout1, "Save Failed !!", Snackbar.LengthShort);
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