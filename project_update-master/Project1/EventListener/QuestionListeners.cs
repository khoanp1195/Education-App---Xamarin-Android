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
using Firebase.Database;
using Project1.Helpers;
using Project1.Model;

namespace Project1.EventListeners
{
    public class QuestionListeners : Java.Lang.Object, IValueEventListener
    {
        List<UserQuestion> xamarinList = new List<UserQuestion>();

        public event EventHandler<AluminDataEventArgs> AluminRetrived;

        public class AluminDataEventArgs : EventArgs
        {
            public List<UserQuestion> UserQuestions { get; set; }
        }

        public void OnCancelled(DatabaseError error)
        {
           
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
           if(snapshot.Value != null)
            {
                var child = snapshot.Children.ToEnumerable<DataSnapshot>();
                xamarinList.Clear();
               foreach (DataSnapshot xamarinData in child)
                {
                    UserQuestion xamarinCourse = new UserQuestion();
                    xamarinCourse.ID = xamarinData.Key;
                    xamarinCourse.Title = xamarinData.Child("Title").Value.ToString();
                    xamarinCourse.Content = xamarinData.Child("Content").Value.ToString();
                    xamarinCourse.Contribute = xamarinData.Child("User").Value.ToString();
                    xamarinCourse.Category = xamarinData.Child("Category").Value.ToString();
                    xamarinCourse.Timer = xamarinData.Child("Timer").Value.ToString();



                    xamarinList.Add(xamarinCourse);
                }
                AluminRetrived.Invoke(this, new AluminDataEventArgs {UserQuestions = xamarinList });
            }
          
        }



        //Select Normal
        public void Create()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("HistoryUserQuestion");
            alumiRef.KeepSynced(true);
            alumiRef.AddValueEventListener(this); 
     
        }

        public void Create2()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("UserQuestion/UserReply");
            alumiRef.KeepSynced(true);
            alumiRef.AddValueEventListener(this);
       
        }
        public void Create3()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("TodayQuesiton");
          alumiRef.KeepSynced(true);
            alumiRef.AddValueEventListener(this);
           
        }
        public void Create4()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("UserReply");
            alumiRef.KeepSynced(true);
            alumiRef.AddValueEventListener(this);
           ;
        }



        //Select Normal
        public void Create1(string key)
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference( key + "/UserReply");
            alumiRef.KeepSynced(true);
            alumiRef.AddValueEventListener(this);
          
        }



        public void DeleteAlumini(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("UserQuestion/" + key);
            reference.RemoveValue();
        }


     
    }
}