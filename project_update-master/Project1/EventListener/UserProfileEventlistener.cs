using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using Project1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    public class UserProfileEventlistener : Java.Lang.Object, IValueEventListener
    {
        ISharedPreferences preferences = Application.Context.GetSharedPreferences("userinfo", FileCreationMode.Private);
        ISharedPreferencesEditor editor;
        public void OnCancelled(DatabaseError error)
        {
            throw new NotImplementedException();
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
            if(snapshot.Value != null)
            {
                string fullname, email, phone = " ";
                fullname = (snapshot.Child("fullnaame") != null) ? snapshot.Child("fullname").Value.ToString() : " ";
                email = (snapshot.Child("email") != null) ? snapshot.Child("email").Value.ToString() : " ";

                if(snapshot.Child("phone") != null)
                {
                    phone = snapshot.Child("phone").Value.ToString();
                }

                editor.PutString("fullname", fullname);
                editor.PutString("email", email);
                editor.PutString("phone", phone);
                editor.Apply();
            }

           
        }

        //public void Create()
        //{
        //    editor = preferences.Edit();
        //    FirebaseDatabase database = AppDataHelper.GetDatabase();
        //    string userId = AppDataHelper.GetCurrentUser().Uid;
        //    DatabaseReference profileReferences = database.GetReference("users/" + userId);
        //    profileReferences.AddValueEventListener(this);

        //}
    }
}