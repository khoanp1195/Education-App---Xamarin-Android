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
    public class ViewHolder4 : Java.Lang.Object
    {
        //public TextView TextView { get; set; }
        public TextView newWordText { get; set; }
        public TextView levelText { get; set; }
        public TextView spellingText { get; set; }
        public TextView meanText { get; set; }
        public TextView exampleText { get; set; }
        public TextView typeText { get; set; }
        public ImageView deleteButton { get; set; }
        public TextView meanenglishText { get; set; }
        public TextView usercontributeText { get; set; }

    }
    class FavoriteWordCustomAdapter : BaseAdapter
    {
        private List<FavoriteWord> lsIQQuestion;
        private Context context;


     
        public FavoriteWordCustomAdapter(Context context, List<FavoriteWord> lsIQQuestion)
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
            View view = inflater.Inflate(Resource.Layout.FavoriteWordRow, null);

            var newWordText = (TextView)view.FindViewById(Resource.Id.nameText);
           var  meanText = (TextView)view.FindViewById(Resource.Id.departmentText);
           var  levelText = (TextView)view.FindViewById(Resource.Id.statusText);
           var  spellingText = (TextView)view.FindViewById(Resource.Id.setText);
 
           var  exampleText = (TextView)view.FindViewById(Resource.Id.exampleText);
          var   typeText = (TextView)view.FindViewById(Resource.Id.tuloaiText);
           var  meanenglishText = (TextView)view.FindViewById(Resource.Id.exampleText2);
            var usercontributeText = (TextView)view.FindViewById(Resource.Id.usercontributeText);





            newWordText.Text = lsIQQuestion[position].NewWord;
            meanText.Text = lsIQQuestion[position].Mean;
            levelText.Text = lsIQQuestion[position].Level;
            spellingText.Text = lsIQQuestion[position].Spelling;
            exampleText.Text = lsIQQuestion[position].Example;
            spellingText.Text = lsIQQuestion[position].Spelling;
            typeText.Text = lsIQQuestion[position].type;
            meanenglishText.Text = lsIQQuestion[position].MeanEnglish;
            usercontributeText.Text = lsIQQuestion[position].Contribute;
  
   
        
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