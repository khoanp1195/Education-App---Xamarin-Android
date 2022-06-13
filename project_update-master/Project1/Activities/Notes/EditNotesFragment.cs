
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

namespace Project1.Fragment
{
    public class EditNotesFragment : Android.Support.V4.App.DialogFragment
    {
        TextView txtTitle, txtContent, txtTime; 
       
        LinearLayout linearLayout;

        Notees thisNotes;


        Button savechangesButton;
        ImageView speakbtn;

        public EditNotesFragment()
        {
        }

        private TextToSpeech tts;

        public EditNotesFragment(Notees notes)
        {
            thisNotes = notes;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.detailNotes, container, false);


        

         
     
            txtTitle = (TextView)view.FindViewById(Resource.Id.txtTitle);
            txtContent = (TextView)view.FindViewById(Resource.Id.txtContent);
            txtTime = (TextView)view.FindViewById(Resource.Id.txtTime);
           
            
            linearLayout = (LinearLayout)view.FindViewById(Resource.Id.linearLayout1);
            savechangesButton = (Button)view.FindViewById(Resource.Id.submitButton);
         //   savechangesButton.Click += SavechangesButton_Click;

            txtTitle.Text = thisNotes.Title;
            txtContent.Text = thisNotes.Content;
            txtTime.Text = thisNotes.Time;
       
            

            return view;
        }

   

    




        //private void SavechangesButton_Click(object sender, EventArgs e)
        //{
        //    string newWord = fullnameText.Text;
        //    string mean = departmentText.Text;
        //    string spelling = setText.Text;
        //    string examplee = example.Text;
        //    string level = status.Text;
        //    string meanenglish = example2.Text;
        //    string type = tuloai.Text;

          


        //    AlertDialog.Builder saveDataAlert = new AlertDialog.Builder(Activity);
        //    saveDataAlert.SetTitle("Add Your Favorite Word");
        //    saveDataAlert.SetMessage("Are you sure?");
        //    saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
        //    {

        //        AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/NewWord").SetValue(newWord);
        //        AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/Mean").SetValue(mean);
        //        AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/Spelling").SetValue(spelling);
        //        AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/Type").SetValue(type);
        //        AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/Level").SetValue(level);
        //        AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/Example").SetValue(examplee);
        //        AppDataHelper.GetDatabase().GetReference("wordchose/" + thisAlunini.ID + "/MeanEnglish").SetValue(meanenglish);



        //        Snackbar snackbar = Snackbar.Make(linearLayout, "Added Success", Snackbar.LengthShort);
        //        View snackbarView = snackbar.View;
        //        snackbarView.SetBackgroundColor(Color.Green);
        //        snackbar.Show();

        //    });
        //    saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
        //    {

        //        Snackbar snackbar = Snackbar.Make(linearLayout, "Added Failed", Snackbar.LengthShort);
        //        View snackbarView = snackbar.View;
        //        snackbarView.SetBackgroundColor(Color.Red);
        //        snackbar.Show();
        //        saveDataAlert.Dispose();
        //    });

        //    saveDataAlert.Show();

        //    //  this.Dismiss();
        //}
    }
}