using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities.Webview
{
    [Activity(Label = "Angular")]
    public class Angular : Activity
    {

        WebView webview1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AngularWebview);
            // Create your application here

            webview1 = (WebView)FindViewById(Resource.Id.webView1);


            webview1.Settings.JavaScriptEnabled = true;
            webview1.LoadUrl("https://itnavi.com.vn/blog/angular-la-gi");
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}