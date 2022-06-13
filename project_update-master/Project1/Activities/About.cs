using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using AndroidAboutPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities
{
    [Activity(Label = "AboutPage")]
    public class About : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            Element  adsElement = new Element();

            adsElement.Title = "Advertise Here";


            View aboutpage = new AboutPage(this)
                .IsRtl(false)
                .SetImage(Resource.Drawable.icon_quiz)
                .SetDescription("This is demo version")
                .AddItem(new Element() { Title = "Verision 1.0" })
                .AddItem(adsElement)
                .AddGroup("Connect with me")
                .AddEmail("zphuongkhoaz@gmail.com")
                .AddWebsite("")
                .AddFacebook("Nguyen Phuong Khoa")
                .AddInstagram("Phuongkhoaaa")
                .AddGitHub("https://github.com/khoanp1195")
                .AddItem((Element)CreateCopyRight())
                .AddYoutube("khoanguyen")
                .Create();
            SetContentView(aboutpage);

            // Create your application here
        }

        private object CreateCopyRight()
        {
           Element copyright = new Element();
            String coppyrightString = $"Coppyright [DateTime.Now.Year] by Khoa ";
            copyright.Title = coppyrightString;
            copyright.IconDrawable = Resource.Drawable.icon_quiz;
            return copyright;
        }
    }
}