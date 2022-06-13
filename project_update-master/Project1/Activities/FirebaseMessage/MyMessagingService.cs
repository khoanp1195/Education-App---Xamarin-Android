//using Android.App;
//using Android.Content;
//using Android.Graphics;
//using Android.OS;
//using Android.Runtime;
//using Android.Support.V4.App;
//using Android.Views;
//using Android.Widget;
//using Firebase.Messaging;
//using Project1.Activities.Intro;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using static Android.App.Notification.MessagingStyle;

//namespace Project1.Activities.FirebaseMessage
//{
//    [Service]
//    [IntentFilter(new[] {
//        "com.google.firebase.MESSAGING_EVENT"
//    })]
//    public class MyMessagingService : FirebaseMessagingService
//    {



//        //Notification channel
//        private readonly string NOTIFICATION_CHANNEL_ID = "com.companyname.project1";

//        public override void OnMessageReceived(RemoteMessage message)
//        {
//            if (!message.Data.GetEnumerator().MoveNext())
//                SendNotificaton(message.GetNotification().Title, message.GetNotification().Body);
//            else
//                SendNotificaton(message.Data);
//        }

//        private void SendNotificaton(IDictionary<string, string> data)
//        {
//            string title, body;
//            data.TryGetValue("title", out title);
//            data.TryGetValue("body", out body);

//            SendNotificaton(title, body);
//        }


//        private void SendNotificaton(string title, string body)
//        {
//            NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);

//            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
//            {
//                NotificationChannel notificationChannel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, "Notification chanel",
//                    Android.App.NotificationImportance.Default);



//                notificationChannel.Description = "Khoa channel";
//                notificationChannel.EnableLights(true);
//                notificationChannel.LightColor = Color.Blue;
//                notificationChannel.SetVibrationPattern(new long[] { 0, 1000, 500, 1000 });

//                notificationManager.CreateNotificationChannel(notificationChannel);

//            }

//            var intent = new Intent(this, typeof(IntroIQ));
//            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);
//            NotificationCompat.Builder notificationBuider = new NotificationCompat.Builder(this, NOTIFICATION_CHANNEL_ID);
//            notificationBuider.SetAutoCancel(true)
//                .SetDefaults(-1)
//                .SetWhen(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
//                .SetContentTitle(title)
//                .SetSmallIcon(Resource.Drawable.ic_message)
//                .SetGroupAlertBehavior((int)NotificationGroupAlertBehavior.All)
//                   .SetContentIntent(pendingIntent)



//                .SetContentText(body)
//                .SetContentInfo("info");



//            notificationManager.Notify(new Random().Next(), notificationBuider.Build());






//        }
//    }
//}