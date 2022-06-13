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
    public class XamarinListeners : Java.Lang.Object, IValueEventListener
    {
        List<XamarinCourse> xamarinList = new List<XamarinCourse>();

        public event EventHandler<AluminDataEventArgs> AluminRetrived;

        public class AluminDataEventArgs : EventArgs
        {
            public List<XamarinCourse> XamarinCourse { get; set; }
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
                    XamarinCourse xamarinCourse = new XamarinCourse();
                    xamarinCourse.ID = xamarinData.Key;
                    xamarinCourse.Name = xamarinData.Child("Name").Value.ToString();
                    xamarinCourse.Number = xamarinData.Child("Number").Value.ToString();
                    xamarinCourse.Content1 = xamarinData.Child("Content1").Value.ToString();
                    xamarinCourse.Content2 = xamarinData.Child("Content2").Value.ToString();
                    xamarinCourse.Content3 = xamarinData.Child("Content3").Value.ToString();
                    xamarinCourse.Content4 = xamarinData.Child("Content4").Value.ToString();
                    xamarinCourse.Content5 = xamarinData.Child("Content5").Value.ToString();
                    xamarinCourse.Content6 = xamarinData.Child("Content6").Value.ToString();


                    xamarinCourse.Title1 = xamarinData.Child("Title1").Value.ToString();
                    xamarinCourse.Title2 = xamarinData.Child("Title2").Value.ToString();
                    xamarinCourse.Title3 = xamarinData.Child("Title3").Value.ToString();
                    xamarinCourse.Title4 = xamarinData.Child("Title4").Value.ToString();
                    xamarinCourse.Title5 = xamarinData.Child("Title5").Value.ToString();
                    xamarinCourse.Title6 = xamarinData.Child("Title6").Value.ToString();

                    xamarinCourse.Category = xamarinData.Child("Category").Value.ToString();


                  
                    xamarinList.Add(xamarinCourse);

                }
                AluminRetrived.Invoke(this, new AluminDataEventArgs {XamarinCourse = xamarinList });
            }
          
        }



        //Select Normal
        public void Create()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("Xamarin");
            alumiRef.KeepSynced(true);
            alumiRef.AddValueEventListener(this);
        }


        //Selected Word
        public void Create1()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("Bookmark");
            alumiRef.KeepSynced(true);
            alumiRef.AddValueEventListener(this);
        }

        public void Create2()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("Interview");
            alumiRef.KeepSynced(true);
            alumiRef.AddValueEventListener(this);
        }





        public void DeleteAlumini(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("Xamarin/" + key);
            reference.KeepSynced(true);
            reference.RemoveValue();
        }


        public void DeleteNormal(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("Normal/" + key);
    
            reference.RemoveValue();
        }



        public void DeleteAdvanced(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("Advanced/" + key);
            reference.RemoveValue();
        }
    }
}