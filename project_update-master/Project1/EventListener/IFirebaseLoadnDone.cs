using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Project1.StudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.EventListener
{
    public interface IFirebaseLoadnDone
    {
        public void OnFirebaseLoadSuccess(List<English> englishList);
        public void OnFirebaseLoadFailure(string message);
    }
}