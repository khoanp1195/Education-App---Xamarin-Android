
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project1.EventListeners;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Util;
using Project1.Helpers;
using Project1.Model;
using Android.Graphics;
using Project1.Adapter;
using Android.Support.V7.Widget;
using Xamarin.Essentials;

namespace Project1.Fragment
{
    public class EditAluminiFragment : Android.Support.V4.App.DialogFragment, Android.Speech.Tts.TextToSpeech.IOnInitListener
    {
        TextView fullnameText, departmentText, setText, example, status, tuloai, example2;
       
        LinearLayout linearLayout;

        Alumini thisAlunini;


        Button savechangesButton;
        ImageView speakbtn;

        List<FavoriteWord> lstIqQuestion = new List<FavoriteWord>();



        private Android.Speech.Tts.TextToSpeech tts;

        public EditAluminiFragment(Alumini alumini)
        {
            thisAlunini = alumini;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.edit_english, container, false);


            DbHelper.DbHelper db = new DbHelper.DbHelper(Context);

            tts = new Android.Speech.Tts.TextToSpeech(Context, (Android.Speech.Tts.TextToSpeech.IOnInitListener)this);
            speakbtn = (ImageView)view.FindViewById(Resource.Id.speakbtn);
            speakbtn.Click += delegate
             {
                 SpeakOut();
             };

            fullnameText = (TextView)view.FindViewById(Resource.Id.fullnameText);
            example = (TextView)view.FindViewById(Resource.Id.example);
            departmentText = (TextView)view.FindViewById(Resource.Id.departmentText);
            setText = (TextView)view.FindViewById(Resource.Id.setText);
            status = (TextView)view.FindViewById(Resource.Id.statusTxt);
            tuloai = (TextView)view.FindViewById(Resource.Id.tuloai);
           example2 = (TextView)view.FindViewById(Resource.Id.example2);
            
            linearLayout = (LinearLayout)view.FindViewById(Resource.Id.linearLayout1);
            savechangesButton = (Button)view.FindViewById(Resource.Id.submitButton);
            savechangesButton.Click += SavechangesButton_Click;

            fullnameText.Text = thisAlunini.NewWord;
            departmentText.Text = thisAlunini.Mean;
            setText.Text = thisAlunini.Spelling;
            status.Text = thisAlunini.Level;
            tuloai.Text = thisAlunini.type;
            example.Text = "Example: " + thisAlunini.Example;
            example2.Text = "Mean English: " + thisAlunini.MeanEnglish;
            

            return view;
        }

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            if (status == OperationResult.Success)
            {
                tts.SetLanguage(Java.Util.Locale.Us);
                tts.SetPitch(0.5f);
                tts.SetSpeechRate(2.0f);
                SpeakOut();
            }
        }


        private void SpeakOut()
        {
            string fullname =  fullnameText.Text;

           // AppDataHelper.GetDatabase().GetReference("Normal/" + thisAlunini.ID + "/NewWord").SetValue(fullname);
            if (!String.IsNullOrEmpty(fullname))
                tts.Speak(fullname, QueueMode.Flush, null);
        }




        private void SavechangesButton_Click(object sender, EventArgs e)
        {
            //string newWord = fullnameText.Text;
            //string mean = departmentText.Text;
            //string spelling = setText.Text;
            //string examplee = example.Text;
            //string level = status.Text;
            //string meanenglish = example2.Text;
            //string type = tuloai.Text;




            //AlertDialog.Builder saveDataAlert = new AlertDialog.Builder(Activity);
            //saveDataAlert.SetTitle("Add Your Favorite Word");
            //saveDataAlert.SetMessage("Are you sure?");
            //saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
            //{

            //    AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/NewWord").SetValue(newWord);
            //    AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/Mean").SetValue(mean);
            //    AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/Spelling").SetValue(spelling);
            //    AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/Type").SetValue(type);
            //    AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/Level").SetValue(level);
            //    AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/Example").SetValue(examplee);
            //    AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/MeanEnglish").SetValue(meanenglish);



            //    //Snackbar snackbar = Snackbar.Make(linearLayout, "Added Success", Snackbar.LengthShort);
            //    //View snackbarView = snackbar.View;
            //    //snackbarView.SetBackgroundColor(Color.Green);
            //    //snackbar.Show();

            //});
            //saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
            //{

            //    Snackbar snackbar = Snackbar.Make(linearLayout, "Added Failed", Snackbar.LengthShort);
            //    View snackbarView = snackbar.View;
            //    snackbarView.SetBackgroundColor(Color.Red);
            //    snackbar.Show();
            //    saveDataAlert.Dispose();
            //});

            //saveDataAlert.Show();


            try
            {
                fullnameText.Text = thisAlunini.NewWord;
                departmentText.Text = thisAlunini.Mean;
                setText.Text = thisAlunini.Spelling;
                status.Text = thisAlunini.Level;
                tuloai.Text = thisAlunini.type;
                example.Text = "Example: " + thisAlunini.Example;
                example2.Text = "Mean English: " + thisAlunini.MeanEnglish;

                DbHelper.DbHelper db = new DbHelper.DbHelper(Context);
                FavoriteWord iQQuestion = new FavoriteWord()
                {
                    NewWord = fullnameText.Text,
                    Mean = departmentText.Text,
                    Spelling = setText.Text,
                    Example = status.Text,
                    Level = tuloai.Text,
                    MeanEnglish = example.Text,
                    Contribute = example2.Text,


                };
                db.InsertFavoriteEnglishWord(iQQuestion);
                Snackbar snackbar = Snackbar.Make(linearLayout, "Add Success", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Green);
                snackbar.Show();
            }
            catch
            {
                Snackbar snackbar = Snackbar.Make(linearLayout, "Add Failed", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                Vibrate();
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
            }
          


        
            //  this.Dismiss();
        }
        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }
    }
}