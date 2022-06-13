using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using Project1.Helpers;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    public class TakeNotesListeners : Java.Lang.Object, IValueEventListener
    {
        List<Notees> notesList = new List<Notees>();

        public event EventHandler<TakeNotesDataEventArgs> TakeNotesRetrived;


        public class TakeNotesDataEventArgs : EventArgs
        {
            public List<Notees> Notes { get; set; }
        }

        public void OnCancelled(DatabaseError error)
        {
          
        }

        public void OnDataChange(DataSnapshot snapshot)
        {
            if (snapshot.Value != null)
            {
                var child = snapshot.Children.ToEnumerable<DataSnapshot>();
                notesList.Clear();
                foreach (DataSnapshot noteListData in child)
                {
                    Notees notes = new Notees();
                    notes.ID = noteListData.Key;
                    notes.Title = noteListData.Child("Title").Value.ToString();
                    notes.Content = noteListData.Child("Content").Value.ToString();
           //         notes.Time = noteListData.Child("Time").Value.ToString();


                    notesList.Add(notes);
                }
                TakeNotesRetrived.Invoke(this, new TakeNotesDataEventArgs { Notes = notesList});
            }
        }


        //Select Normal
        public void Create()
        {
            DatabaseReference noteRef = AppDataHelper.GetDatabase().GetReference("Notes");
            noteRef.KeepSynced(true);
            noteRef.AddValueEventListener(this);
        }


        //Delete
        public void DeleteNote(string key)
        {
            DatabaseReference reference = AppDataHelper.GetDatabase().GetReference("Notes/" + key);
            reference.RemoveValue();
        }


    }
}