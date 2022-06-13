using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using FR.Ganfra.Materialspinner;
using Java.Util;
using Project1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using SupportV7 = Android.Support.V7.App;

namespace Project1.Activities.Study.XamarinCourse
{
    [Activity(Label = "addcontent")]
    public class addcontent : Activity
    {
        TextInputLayout nameText, numberText, content1, content2, content3, content4, content5, content6;
        TextInputLayout title1, title2, title3, title4, title5, title6, categoryText;
        MaterialSpinner statusSpinner;
        Button submitButton;
        NestedScrollView linearLayout1;


        ArrayAdapter<string> adapter;


        List<string> statusList;

        string status;
        private Context context;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addxamarin);
        //    SetupStatusPinner(); 
            nameText = (TextInputLayout)FindViewById(Resource.Id.nameText);
            numberText = (TextInputLayout)FindViewById(Resource.Id.numberText);
            content1 = (TextInputLayout)FindViewById(Resource.Id.content1Text);
            content2 = (TextInputLayout)FindViewById(Resource.Id.content2Text);
            content3 = (TextInputLayout)FindViewById(Resource.Id.content3Text);
            content4 = (TextInputLayout)FindViewById(Resource.Id.contetn4Text);
            content5 = (TextInputLayout)FindViewById(Resource.Id.content5Text);
            content6 = (TextInputLayout)FindViewById(Resource.Id.content6Text);
            statusSpinner = (MaterialSpinner)FindViewById(Resource.Id.statusSpinner);

            categoryText = (TextInputLayout)FindViewById(Resource.Id.categoryText);

            title1 = (TextInputLayout)FindViewById(Resource.Id.title1Text);
            title2 = (TextInputLayout)FindViewById(Resource.Id.title2Text);
            title3 = (TextInputLayout)FindViewById(Resource.Id.title3Text);
            title4 = (TextInputLayout)FindViewById(Resource.Id.title4Text);
            title5 = (TextInputLayout)FindViewById(Resource.Id.title5Text);
            title6 = (TextInputLayout)FindViewById(Resource.Id.title6Text);

            linearLayout1 = (NestedScrollView)FindViewById(Resource.Id.linearLayout1);

            SetupStatusPinner();

            submitButton = (Button)FindViewById(Resource.Id.submitBtn);
            submitButton.Click += SubmitButton_Click;

            // Create your application here
        }

    
        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string name = nameText.EditText.Text;
            string number = numberText.EditText.Text;
            string Content1 = content1.EditText.Text;
            string Content2 = content2.EditText.Text;
            string Content3 = content3.EditText.Text;
            string Content4 = content4.EditText.Text;
            string Content5 = content5.EditText.Text;
            string Content6 = content6.EditText.Text;
            string category = categoryText.EditText.Text;

            string Title1 = title1.EditText.Text;
            string Title2 = title2.EditText.Text;
            string Title3 = title3.EditText.Text;
            string Title4 = title4.EditText.Text;
            string Title5 = title5.EditText.Text;
            string Title6 = title6.EditText.Text;

            if (name.Length < 1)
            {
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Please enter text", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                Vibrate();
                return;
            }

            else if (number.Length < 1)
            {
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Please enter text", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
                Vibrate();
                return;
            }

            HashMap aluminiInfo = new HashMap();
            aluminiInfo.Put("Name", name);
            aluminiInfo.Put("Number", number);
            aluminiInfo.Put("Content1", Content1);
            aluminiInfo.Put("Content2", Content2);
            aluminiInfo.Put("Content3", Content3);
            aluminiInfo.Put("Content4", Content4);
            aluminiInfo.Put("Content5", Content5);
            aluminiInfo.Put("Content6", Content6);

            aluminiInfo.Put("Title1", Title1);
            aluminiInfo.Put("Title2", Title2);
            aluminiInfo.Put("Title3", Title3);
            aluminiInfo.Put("Title4", Title4);
            aluminiInfo.Put("Title5", Title5);
            aluminiInfo.Put("Title6", Title6);
            aluminiInfo.Put("Category", category);

            SupportV7.AlertDialog.Builder saveDataAlert = new SupportV7.AlertDialog.Builder(this);
            saveDataAlert.SetTitle("SAVE XAMARIN INFORMATION");
            saveDataAlert.SetMessage("Are you sure?");
            saveDataAlert.SetPositiveButton("Continue", (senderAlert, args) =>
            {

                if (status == "Xamarin")
                {
                    DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("Xamarin").Push();
                    newAluminRef.SetValue(aluminiInfo);
                    saveDataAlert.Dispose();
                    Snackbar snackbar = Snackbar.Make(linearLayout1, "Add to Xamarin Success", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Green);
                    snackbar.Show();
                    //DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("alumini").Push();
                    //    newAluminRef.SetValue(aluminiInfo);
                    //    this.Dismiss();

                }

               
                else if (status == "Interview")
                {
                    DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("Interview").Push();
                    newAluminRef.SetValue(aluminiInfo);
                    saveDataAlert.Dispose();
                    Snackbar snackbar = Snackbar.Make(linearLayout1, "Add to Interview Success", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Green);
                    snackbar.Show();

                }



                else if (status == "Question&Answer")
                {
                    DatabaseReference newAluminRef = AppDataHelper.GetDatabase().GetReference("Question&Answer").Push();
                    newAluminRef.SetValue(aluminiInfo);
                    saveDataAlert.Dispose();
                    Snackbar snackbar = Snackbar.Make(linearLayout1, "Add to Question & Answer Success", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Green);
                    snackbar.Show();

                }

            });
            saveDataAlert.SetNegativeButton("Cancel", (senderAlert, args) =>
            {
                saveDataAlert.Dispose();
                Snackbar snackbar = Snackbar.Make(linearLayout1, "Add Failed !! Please Again", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
            });

                saveDataAlert.Show();

           

        }
        public void SetupStatusPinner()
        {
            statusList = new List<string>();
            statusList.Add("Xamarin");
            statusList.Add("Interview");
            statusList.Add("Question&Answer");
          

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