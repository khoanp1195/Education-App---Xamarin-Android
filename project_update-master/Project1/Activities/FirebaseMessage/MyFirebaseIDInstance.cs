//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Util;
//using Android.Views;
//using Android.Widget;
//using Firebase.Iid;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Project1
//{
//    [Service]
//    [IntentFilter(new[] {
//        "com.google.firebase.INSTANCE_ID_EVENT"
//    })]
//    [Obsolete]
//    public class MyFirebaseIDInstance : FirebaseInstanceIdService
//    {
//        public override void OnTokenRefresh()
//        {
//            var refreshedToken = FirebaseInstanceId.Instance.Token;
//            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
//            SendTokenToServer(refreshedToken);
//        }

//        private void SendTokenToServer(string refreshedToken)
//        {
//            Log.Debug(PackageName, refreshedToken);
//        }
//    }

//}