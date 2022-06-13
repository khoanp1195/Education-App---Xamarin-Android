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
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtQuestion { get; set; }
        public TextView txtImage { get; set; }
        public TextView txtAnswerA { get; set; }
        public TextView txtAnswerB { get; set; }
        public TextView txtAnswerC { get; set; }
        public TextView txtAnswerD { get; set; }
        public TextView CorrecrAnswer { get; set; }
        public TextView muc { get; set; }


        public ImageView btnDelete { get; set; }
    }
    class QuestionCustomAdapter : BaseAdapter
    {
        private List<IQQuestion> lsIQQuestion;
        private Context context;


     
        public QuestionCustomAdapter(Context context, List<IQQuestion> lsIQQuestion)
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
            View view = inflater.Inflate(Resource.Layout.questionIQ_listview_item, null);

            var txtQuesion = (TextView)view.FindViewById(Resource.Id.txtView_Question);
            var txtImage = (TextView)view.FindViewById(Resource.Id.txtView_Image);
            var txtAnswerA = (TextView)view.FindViewById(Resource.Id.txtView_AnswerA);
            var txtAnswerB = (TextView)view.FindViewById(Resource.Id.txtView_AnswerB);
            var txtAnswerC = (TextView)view.FindViewById(Resource.Id.txtView_AnswerC);
            var txtAnswerD = (TextView)view.FindViewById(Resource.Id.txtView_AnswerD);
            var txtCorrectAnswer = (TextView)view.FindViewById(Resource.Id.Correct_Answer);
            var txtMuc = (TextView)view.FindViewById(Resource.Id.muc_Answer);

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

                    string id = lsIQQuestion[poldel].Id.ToString();
                    string Question = lsIQQuestion[poldel].Question;
                    string AnswerA = lsIQQuestion[poldel].AnswerA.ToString();
                    string AnswerB = lsIQQuestion[poldel].AnswerB.ToString();
                    string AnswerC = lsIQQuestion[poldel].AnswerC.ToString();
                    string AnswerD = lsIQQuestion[poldel].AnswerD.ToString();
                    string CorrectAnswer = lsIQQuestion[poldel].CorrectAnswer.ToString();
                    string Image = lsIQQuestion[poldel].Image.ToString();
                    string muc = lsIQQuestion[poldel].muc.ToString();

                    lsIQQuestion.RemoveAt(poldel);

                    DeleteSelectedQuestion(id);
                    NotifyDataSetChanged();

                    Toast.MakeText(context, "Question Deeletd Successfully", ToastLength.Short).Show();
                });
                confirm.SetButton2("Cancel", (s, ev) =>
                {

                });

                confirm.Show();
            };

         ///   convertView.Tag = holder;
            btnDelete.Tag = position;
       



            txtQuesion.Text = lsIQQuestion[position].Question;
            txtImage.Text = lsIQQuestion[position].Image;
            txtAnswerA.Text = lsIQQuestion[position].AnswerA;
            txtAnswerB.Text = lsIQQuestion[position].AnswerB;
            txtAnswerC.Text = lsIQQuestion[position].AnswerC;
            txtAnswerD.Text = lsIQQuestion[position].AnswerD;
            txtCorrectAnswer.Text = "Correct Answer: " + lsIQQuestion[position].CorrectAnswer;
            txtMuc.Text = "Muc: " + lsIQQuestion[position].muc;

        
            //if (position == 0)
            //    imgTop.SetBackgroundResource(Resource.Drawable.top1);
            //else if (position == 1)
            //    imgTop.SetBackgroundResource(Resource.Drawable.top2);
            //else
            //    imgTop.SetBackgroundResource(Resource.Drawable.top3);
            //txtTop.Text =$"{ lstRanking[position].Score.ToString("0.00")}";
            

            return view;
        }
        private void DeleteSelectedQuestion(string contactId)
        {
            DbHelper.DbHelper _db = new DbHelper.DbHelper(context);
            _db.DeleteContact(contactId);
        }


    }
}