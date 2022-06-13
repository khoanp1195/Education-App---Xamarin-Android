using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Project1.Activities.AddQuestionQuizz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class AndroidTutorial : Activity
    {
        WebView webView;
        ImageView backButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.youtube);
            // Create your application here


            backButton = FindViewById<ImageView>(Resource.Id.backButton);
            backButton.Click += BackButton_Click;

            webView = FindViewById<WebView>(Resource.Id.webview);
            WebSettings settings = webView.Settings;
            settings.JavaScriptEnabled =true;
            webView.SetWebChromeClient(new WebChromeClient());
            webView.LoadUrl("https://www.youtube.com/embed/tZvjSl9dswg");

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);

        }
    }
}