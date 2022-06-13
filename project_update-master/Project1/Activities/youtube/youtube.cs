using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class youtube : Activity
    {
        WebView webView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.youtube);
            // Create your application here

            webView = FindViewById<WebView>(Resource.Id.webview);
            WebSettings settings = webView.Settings;
            settings.JavaScriptEnabled =true;
            webView.SetWebChromeClient(new WebChromeClient());
            webView.LoadUrl("https://www.youtube.com/embed/DHHY8m3rEzU");

        }
    }
}