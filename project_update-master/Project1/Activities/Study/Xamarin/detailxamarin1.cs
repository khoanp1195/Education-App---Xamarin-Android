using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    [Activity(Label = "detailxamarin1")]
    public class detailxamarin1 : Activity
    {
        TextView name, number, content1, content2, content3, content4, content5, content6;
        TextView title1, title2, title3, title4, title5, title6, category;

        ImageView deleteButton;
        LinearLayout linearLayout;

        XamarinCourse thisCourse;

        public detailxamarin1()
        {
        }


        public detailxamarin1(XamarinCourse xamarin)
        {
            thisCourse = xamarin;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.detailxamarin);

            // Create your application here


            deleteButton = FindViewById<ImageView>(Resource.Id.deleteButton);



            name = FindViewById<TextView>(Resource.Id.name);
            number = FindViewById<TextView>(Resource.Id.number);
            content1 = FindViewById<TextView>(Resource.Id.content1);
            content2 = FindViewById<TextView>(Resource.Id.content2);
            content3 = FindViewById<TextView>(Resource.Id.content3);
            content4 = FindViewById<TextView>(Resource.Id.content4);
            content5 = FindViewById<TextView>(Resource.Id.content5);
            content6 = FindViewById<TextView>(Resource.Id.content6);

            title1 = FindViewById<TextView>(Resource.Id.title1);
            title2 = FindViewById<TextView>(Resource.Id.title2);
            title3 = FindViewById<TextView>(Resource.Id.title3);
            title4 = FindViewById<TextView>(Resource.Id.title4);
            title5 = FindViewById<TextView>(Resource.Id.title5);
            title6 = FindViewById<TextView>(Resource.Id.title6);
            category = FindViewById<TextView>(Resource.Id.category);

            linearLayout = (LinearLayout)FindViewById(Resource.Id.linearLayout1);


            name.Text = thisCourse.Name;
            number.Text = thisCourse.Number;

            content1.Text = thisCourse.Content1;
            content2.Text = thisCourse.Content2;
            content3.Text = thisCourse.Content3;
            content4.Text = thisCourse.Content4;
            content5.Text = thisCourse.Content5;
            content6.Text = thisCourse.Content6;


            title1.Text = thisCourse.Title1;
            title2.Text = thisCourse.Title2;
            title3.Text = thisCourse.Title3;
            title4.Text = thisCourse.Title4;
            title5.Text = thisCourse.Title5;
            title6.Text = thisCourse.Title6;

            category.Text = thisCourse.Category;
        }
    }
}