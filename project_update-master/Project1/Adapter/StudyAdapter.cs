using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Project1.StudyModel;
using Square.Picasso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Adapter
{
    public class StudyAdapter : PagerAdapter
    {
        Context context;
        List<English> englishlist;
        LayoutInflater inflater;

        public StudyAdapter(Context context, List<English> englishstudy)
        {
            this.context = context;
            this.englishlist = englishstudy;
            inflater = LayoutInflater.From(context);
        }
        public override int Count => englishlist.Count;    

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return view == @object;
        }

        public override void DestroyItem(View container, int position, Java.Lang.Object @object)
        {
            ((ViewPager)container).RemoveView((View)@object);
        }

        
        public override Java.Lang.Object InstantiateItem (ViewGroup container, int position )
        {
            //Inflate View
            var itemView = inflater.Inflate(Resource.Layout.viewpager_item, container,false);


            //view
            var english_image = itemView.FindViewById<ImageView>(Resource.Id.english_image);
            var english_name = itemView.FindViewById<TextView>(Resource.Id.englishtitle);
            var english_description = itemView.FindViewById<TextView>(Resource.Id.englishdescription);

            //data
            Picasso.With(context).Load(englishlist[position].image).Into(english_image);
            english_name.Text = englishlist[position].name; 
            english_description.Text = englishlist[position].description;


            //Event
            itemView.Click += delegate
            {
                Toast.MakeText(context, "" + englishlist[position].name, ToastLength.Long).Show();
            };

            container.AddView(itemView);
            return itemView;



        }
    
    }
}