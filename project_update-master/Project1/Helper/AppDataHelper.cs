using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Firestore;

namespace Project1.Helpers
{
   public static class AppDataHelper
    {
       static  ISharedPreferences preferences = Application.Context.GetSharedPreferences("userinfo", FileCreationMode.Private);

        static ISharedPreferencesEditor editor;


        //Get Firebase Firestore
        public static FirebaseFirestore GetFirestore()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseFirestore database;

            if (app == null)
            {
                var options = new Firebase.FirebaseOptions.Builder()
                     .SetApplicationId("project1-4e850")
                    .SetApiKey("AIzaSyCou_P4H_wbYA3tWisjrOfq2b9nhYIzd7w")
                    .SetDatabaseUrl("https://project1-4e850-default-rtdb.firebaseio.com")
                    .SetStorageBucket("project1-4e850.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);
                database = FirebaseFirestore.GetInstance(app);
            }
            else
            {
                database = FirebaseFirestore.GetInstance(app);
            }
            return database;
        }


        //Get Firebase Database
        public static FirebaseDatabase GetDatabase()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseDatabase database;
            if (app == null)
            {
                var options = new Firebase.FirebaseOptions.Builder()

                    .SetApplicationId("project1-4e850")
                    .SetApiKey("AIzaSyCou_P4H_wbYA3tWisjrOfq2b9nhYIzd7w")
                    .SetDatabaseUrl("https://project1-4e850-default-rtdb.firebaseio.com")
                    .SetStorageBucket("project1-4e850.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);
                database = FirebaseDatabase.GetInstance(app);
                FirebaseDatabase.GetInstance(app).SetPersistenceEnabled(true);
            }
            else
            {
                database = FirebaseDatabase.GetInstance(app);

            }

            return database;
        }

        //Get Firebase Auth
        public static FirebaseAuth GetFirebaseAuth()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseAuth mAuth;

            if (app == null)
            {
                var options = new Firebase.FirebaseOptions.Builder()

                    .SetApplicationId("uber-clone-da636")
                    .SetApiKey("AIzaSyBpBjZCW6lj0r9KbfZ0ymvpzDziJvaJeu4")
                    .SetDatabaseUrl("https://uber-clone-da636.firebaseio.com")
                    .SetStorageBucket("uber-clone-da636.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);
                mAuth = FirebaseAuth.Instance;
            }
            else
            {
                mAuth = FirebaseAuth.Instance;
            }

            return mAuth;
        }


        //Get CurrentUser
        public static FirebaseUser GetCurrentUser()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseAuth mAuth;
            FirebaseUser mUser;

            if (app == null)
            {
                var options = new Firebase.FirebaseOptions.Builder()

                    .SetApplicationId("uber-clone-da636")
                    .SetApiKey("AIzaSyBpBjZCW6lj0r9KbfZ0ymvpzDziJvaJeu4")
                    .SetDatabaseUrl("https://uber-clone-da636.firebaseio.com")
                    .SetStorageBucket("uber-clone-da636.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);
                mAuth = FirebaseAuth.Instance;
                mUser = mAuth.CurrentUser;
            }
            else
            {
                mAuth = FirebaseAuth.Instance;
                mUser = mAuth.CurrentUser;
            }

            return mUser;
        }





        //Get FullName

        public static void SaveFullName(string fullname)
        {
            editor = preferences.Edit();
            editor.PutString("fullname", fullname);
            editor.Apply();
        }

        public static string GetFullName()
        {
            string fullname = preferences.GetString("fullname", "");
            return fullname;
        }





        //Get Email
        public static string GetEmail()
        {
            string email = preferences.GetString("email", "");
            return email;
        }



        //Get Phone
        public static string GetPhone()
        {
            string phone = preferences.GetString("phone", "");
            return phone;
        }
    }
}