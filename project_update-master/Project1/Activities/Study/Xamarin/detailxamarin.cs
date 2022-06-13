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
    [Activity(Label = "detailxamarin")]
    public class detailxamarin : Android.Support.V4.App.DialogFragment
    {
        TextView name, number, content1, content2, content3, content4, content5, content6;
        TextView title1, title2, title3, title4, title5, title6, category;

        ImageView deleteButton;
        LinearLayout linearLayout;

        XamarinCourse thisCourse;

        public detailxamarin()
        {
        }

        public detailxamarin(XamarinCourse xamarin)
        {
            thisCourse = xamarin;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.detailxamarin, container, false);




            deleteButton = view.FindViewById<ImageView>(Resource.Id.deleteButton);

         

            name = view.FindViewById<TextView>(Resource.Id.name);
            number = view.FindViewById<TextView>(Resource.Id.number);
            content1 = view.FindViewById<TextView>(Resource.Id.content1);
            content2 = view.FindViewById<TextView>(Resource.Id.content2);
            content3 = view.FindViewById<TextView>(Resource.Id.content3);
            content4 = view.FindViewById<TextView>(Resource.Id.content4);
            content5 = view.FindViewById<TextView>(Resource.Id.content5);
            content6 = view.FindViewById<TextView>(Resource.Id.content6);

            title1 = view.FindViewById<TextView>(Resource.Id.title1);
            title2 = view.FindViewById<TextView>(Resource.Id.title2);
            title3 = view.FindViewById<TextView>(Resource.Id.title3);
            title4 = view.FindViewById<TextView>(Resource.Id.title4);
            title5 = view.FindViewById<TextView>(Resource.Id.title5);
            title6 = view.FindViewById<TextView>(Resource.Id.title6);
            category = view.FindViewById<TextView>(Resource.Id.category);

            linearLayout = (LinearLayout)view.FindViewById(Resource.Id.linearLayout1);


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


            return view;
        }

   
    }
}