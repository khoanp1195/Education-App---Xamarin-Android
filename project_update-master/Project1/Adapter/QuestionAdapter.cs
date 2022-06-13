using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Project1.EventListeners;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Adapter
{
     class QuestionAdapter : RecyclerView.Adapter
    {
        public event EventHandler<AluminiAdapterClickEventArgs> ItemClick;
        public event EventHandler<AluminiAdapterClickEventArgs> ItemLongClick;
        public event EventHandler<AluminiAdapterClickEventArgs> DeleteItemClick;
        List<UserQuestion> Items;
      
        private Context context;
        public QuestionAdapter(List<UserQuestion> Data)
        {
            Items = Data;
        }

        public override int ItemCount => Items.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as QuestionAdapterViewHolder;
            //holder.TextView.Text = items[position];
            holder.titleText.Text = Items[position].Title;

            holder.contentText.Text = Items[position].Content;
            holder.categoryText.Text = Items[position].Category;
            holder.usercontributeText.Text = Items[position].Contribute;
            holder.timer1.Text = Items[position].Timer;
        



            holder.categoryText.Text = Items[position].Category;
            if (Items[position].Category == "Xamarin")
            {
                holder.categoryText.SetTextColor(Color.Rgb(9, 155, 11));
            }
            else if (Items[position].Category == "Interview")
            {
                holder.categoryText.SetTextColor(Color.Rgb(238, 134, 31));
            }
            else if (Items[position].Category == "Xamarin")
            {
                holder.categoryText.SetTextColor(Color.Blue);
            }
            else if (Items[position].Category == "Response")
            {
                holder.categoryText.SetTextColor(Color.Red);
            }

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup your layout here
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.QuestionRow, parent, false);



            var vh = new QuestionAdapterViewHolder(itemView, OnClick, OnLongClick, OnDeleteClick);
            return vh;
        }





        public Action<object, QuestionListeners.AluminDataEventArgs> AluminRetrived { get; internal set; }

        void OnClick(AluminiAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(AluminiAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);
        void OnDeleteClick(AluminiAdapterClickEventArgs args) => DeleteItemClick(this, args);




        public class QuestionAdapterViewHolder : RecyclerView.ViewHolder
        {
            //public TextView TextView { get; set; }
            public TextView titleText { get; set; }
            public TextView contentText { get; set; }
            public TextView categoryText { get; set; }
            public TextView usercontributeText { get; set; }
            public TextView timer1 { get; set; }
            public QuestionAdapterViewHolder(View itemView, Action<AluminiAdapterClickEventArgs> clickListener,
                                Action<AluminiAdapterClickEventArgs> LongClickListener, Action<AluminiAdapterClickEventArgs> deleteClickListener) : base(itemView)
            {
                //TextView = v;
                titleText = (TextView)itemView.FindViewById(Resource.Id.course);
                contentText = (TextView)itemView.FindViewById(Resource.Id.content1Text);
                categoryText = (TextView)itemView.FindViewById(Resource.Id.content2Text);
                usercontributeText = (TextView)itemView.FindViewById(Resource.Id.userText);
                timer1 = (TextView)itemView.FindViewById(Resource.Id.timer);
              

                itemView.Click += (sender, e) => clickListener(new AluminiAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
                itemView.Click += (sender, e) => LongClickListener(new AluminiAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
             //   deleteButton.Click += (sender, e) => deleteClickListener(new AluminiAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            }
        }



        public class AluminiAdapterClickEventArgs : EventArgs
        {
            public View View { get; set; }
            public int Position { get; set; }
        }
    }


}
