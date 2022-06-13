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
    public class UserContributeListeners : Java.Lang.Object, IValueEventListener
    {
        List<Alumini> aluminiList = new List<Alumini>();

        public event EventHandler<AluminDataEventArgs> AluminRetrived;

        public class AluminDataEventArgs : EventArgs
        {
            public List<Alumini> Alumini { get; set; }
        }

        public void OnCancelled(DatabaseError error)
        {
           
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
           if(snapshot.Value != null)
            {
                var child = snapshot.Children.ToEnumerable<DataSnapshot>();
                aluminiList.Clear();
               foreach (DataSnapshot aluminiData in child)
                {
                    Alumini alumini = new Alumini();
                    alumini.ID = aluminiData.Key;
                    alumini.NewWord = aluminiData.Child("NewWord").Value.ToString();
                    alumini.Mean = aluminiData.Child("Mean").Value.ToString();
                    alumini.Spelling = aluminiData.Child("Spelling").Value.ToString();
                    alumini.type = aluminiData.Child("Type").Value.ToString();
                    alumini.Level = aluminiData.Child("Level").Value.ToString();
                    alumini.MeanEnglish = aluminiData.Child("MeanEnglish").Value.ToString();
                   alumini.Contribute = aluminiData.Child("UserContribute").Value.ToString();
                    
                    alumini.Example = aluminiData.Child("Example").Value.ToString();
                    aluminiList.Add(alumini);
                }
                AluminRetrived.Invoke(this, new AluminDataEventArgs { Alumini = aluminiList });
            }
          
        }



     



        public void Create3()
        {
            DatabaseReference alumiRef = AppDataHelper.GetDatabase().GetReference("ContributeWord");
            alumiRef.KeepSynced(true);
            alumiRef.AddValueEventListener(this);
        }


        public void DeleteAlumini(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("UserContribute/" + key);

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