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
    public class ViewHolder1 : Java.Lang.Object
    {
        public TextView txtContent { get; set; }
   
        public TextView txtTimer { get; set; }


        public ImageView btnDelete { get; set; }
    }
    class ContentScanTextAdapter : BaseAdapter
    {
        private List<ContentScanText> lsIQQuestion;
        private Context context;


     
        public ContentScanTextAdapter(Context context, List<ContentScanText> lsIQQuestion)
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
            View view = inflater.Inflate(Resource.Layout.contentScanText_listview_item, null);

            var txtContent = (TextView)view.FindViewById(Resource.Id.txtView_Content);

            var txtTimer = (TextView)view.FindViewById(Resource.Id.txtView_Timer);
          

            var btnDelete = (ImageView)view.FindViewById(Resource.Id.imgDelete);

            btnDelete.Click += (object sender, EventArgs e) =>
            {

                AlertDialog.Builder builder = new AlertDialog.Builder(context);
                AlertDialog confirm = builder.Create();
                confirm.SetTitle("Confirm Delete");
                confirm.SetMessage("Are you sure delete?");
                confirm.SetButton("OK", (s, ev) =>
                {
                    var poldel = (int)((sender as ImageView).Tag);

                    string Id = lsIQQuestion[poldel].Id.ToString();
                    string Content = lsIQQuestion[poldel].Content;
                    string Timer = lsIQQuestion[poldel].Timer;
                   

                    lsIQQuestion.RemoveAt(poldel);

                    DeleteSelectedQuestion(Id);
                    NotifyDataSetChanged();

                    Toast.MakeText(context, "Content Scan Text Deeletd Successfully", ToastLength.Short).Show();
                });
                confirm.SetButton2("Cancel", (s, ev) =>
                {

                });

                confirm.Show();
            };

         ///   convertView.Tag = holder;
            btnDelete.Tag = position;
       



            txtContent.Text = lsIQQuestion[position].Content;
            txtTimer.Text = lsIQQuestion[position].Timer;
        

        
            //if (position == 0)
            //    imgTop.SetBackgroundResource(Resource.Drawable.top1);
            //else if (position == 1)
            //    imgTop.SetBackgroundResource(Resource.Drawable.top2);
            //else
            //    imgTop.SetBackgroundResource(Resource.Drawable.top3);
            //txtTop.Text =$"{ lstRanking[position].Score.ToString("0.00")}";
            

            return view;
        }
        private void DeleteSelectedQuestion(string scantextId)
        {
            DbHelper.DbHelper _db = new DbHelper.DbHelper(context);
            _db.DeleteScanText(scantextId);
        }


    }
}