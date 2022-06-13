using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Database;
using Project1.Activities.Transformer;
using Project1.Adapter;
using Project1.EventListener;
using Project1.StudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities
{
    [Activity(Label = "StudyActivity", MainLauncher = false)]
    public class StudyActivity : AppCompatActivity, IValueEventListener, IFirebaseLoadnDone
    {
        ViewPager viewPager;
        StudyAdapter adapter;

        DatabaseReference english;
        IFirebaseLoadnDone firebaseLoadnDone;
        List<English> englishlist = new List<English>();  

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.viewpager_study);
            ///IntializeDatabase();
            english = FirebaseDatabase.Instance.GetReference("English");
            viewPager = (ViewPager)FindViewById(Resource.Id.viewPager1);
            viewPager.SetPageTransformer(true, new DepthPageTransformer());

            firebaseLoadnDone = this;
            LoadEnglish();
          
            // Create your application here
        }


        public void OnCancelled(DatabaseError error)
        {
            firebaseLoadnDone.OnFirebaseLoadFailure(error.Message);
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
                FirebaseDatabase.GetInstance(app).SetPersistenceEnabled(true);
                //   mDatabase = FirebaseDatabase.GetInstance(app);
            }
            else
            {
                //  mDatabase = FirebaseDatabase.GetInstance(app);
            }
            //  DatabaseReference dbrf = mDatabase.GetReference("UserSupport");
            // dbrf.SetValue("Ticket");

            //Toast.MakeText(this, "Make Test", ToastLength.Short).Show();
        }


        public void OnDataChange(DataSnapshot snapshot)
        {
            //clear already item in list
            englishlist.Clear();
            foreach(DataSnapshot englishSnapshot in snapshot.Children.ToEnumerable())
            {
                //Parse object
                English english = new English();
                english.name = englishSnapshot.Child("name").GetValue(true).ToString();
                english.description = englishSnapshot.Child("description").GetValue(true).ToString();
                english.image = englishSnapshot.Child("image").GetValue(true).ToString();


                englishlist.Add(english);
            }

            //listener
            firebaseLoadnDone.OnFirebaseLoadSuccess(englishlist);
        }


        private void LoadEnglish()
        {
            //english.AddListenerForSingleValueEvent(this);


            //Realtime
            english.AddValueEventListener(this);
        }

        protected override void OnResume()
        {
            english.AddValueEventListener(this);
            base.OnResume();
        }

        protected override void OnStop()
        {
            english.AddValueEventListener(this);
            base.OnStop();
        }
        protected override void OnDestroy()
        {
            english.AddValueEventListener(this);
            base.OnDestroy();
        }

        public void OnFirebaseLoadSuccess(List<English> englishList)
        {
            adapter = new StudyAdapter(this, englishList);
            viewPager.Adapter = adapter;
        }

        public void OnFirebaseLoadFailure(string message)
        {
            Toast.MakeText(this, message, ToastLength.Short).Show();
        }
    }
}