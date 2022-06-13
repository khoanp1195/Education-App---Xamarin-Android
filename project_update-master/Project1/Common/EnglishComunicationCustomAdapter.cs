using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Project1.Model;



namespace Project1.Common
{
    public class ViewHolder3 : Java.Lang.Object
    {
        public TextView txtTittle { get; set; }
        public TextView txtContent1 { get; set; }
        public TextView txtContent2 { get; set; }
        public TextView txtContent3 { get; set; }
   
    }
    class EnglishComunicationCustomAdapter : BaseAdapter
    {
        private List<ComunicationEnglishModel> lsIQQuestion;
        private Context context;


     
        public EnglishComunicationCustomAdapter(Context context, List<ComunicationEnglishModel> lsIQQuestion)
        {
            this.context = context;
            this.lsIQQuestion = lsIQQuestion;
        }



        public override int Count
        {
            get
            {
                return lsIQQuestion.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            View view = inflater.Inflate(Resource.Layout.TipInterviewItem, null);

            var txtTittle = (TextView)view.FindViewById(Resource.Id.txtView_Tittle);
            var txtContent1 = (TextView)view.FindViewById(Resource.Id.txtView_Content1);
            var txtContent2 = (TextView)view.FindViewById(Resource.Id.txtView_Content2);
            var txtContent3 = (TextView)view.FindViewById(Resource.Id.txtView_Content3);





            txtTittle.Text = lsIQQuestion[position].Tittle;
            txtContent1.Text = lsIQQuestion[position].Content1;
            txtContent2.Text = lsIQQuestion[position].Content2;
            txtContent3.Text = lsIQQuestion[position].Content3;
  
   
        
            //if (position == 0)
            //    imgTop.SetBackgroundResource(Resource.Drawable.top1);
            //else if (position == 1)
            //    imgTop.SetBackgroundResource(Resource.Drawable.top2);
            //else
            //    imgTop.SetBackgroundResource(Resource.Drawable.top3);
            //txtTop.Text =$"{ lstRanking[position].Score.ToString("0.00")}";
            

            return view;
        }
   


    }
}