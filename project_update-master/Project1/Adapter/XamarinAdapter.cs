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
     class XamarinAdapter : RecyclerView.Adapter
    {
        public event EventHandler<AluminiAdapterClickEventArgs> ItemClick;
        public event EventHandler<AluminiAdapterClickEventArgs> ItemLongClick;
        public event EventHandler<AluminiAdapterClickEventArgs> DeleteItemClick;
        List<XamarinCourse> Items;

        private Context context;
        public XamarinAdapter(List<XamarinCourse> Data)
        {
            Items = Data;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup your layout here
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.AngularRow, parent, false);



            var vh = new XamarinAdapterViewHolder(itemView, OnClick, OnLongClick, OnDeleteClick);
            return vh;
        }

        public override int ItemCount => Items.Count;





        void OnClick(AluminiAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(AluminiAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);
        void OnDeleteClick(AluminiAdapterClickEventArgs args) => DeleteItemClick(this, args);

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as XamarinAdapterViewHolder;
            //holder.TextView.Text = items[position];
            holder.namecourseText.Text = Items[position].Name;

            holder.numberText.Text = Items[position].Number;
            holder.content1Text.Text = Items[position].Content1;
            holder.content2Text.Text = Items[position].Content2;
            holder.content3Text.Text = Items[position].Content3;
            holder.content4Text.Text = Items[position].Content4;
            holder.content5Text.Text = Items[position].Content5;
            holder.content6Text.Text = Items[position].Content6;


            holder.title1Text.Text = Items[position].Title1;
            holder.title2Text.Text = Items[position].Title2;
            holder.title3Text.Text = Items[position].Title3;
            holder.title4Text.Text = Items[position].Title4;
            holder.title5Text.Text = Items[position].Title5;
            holder.title6Text.Text = Items[position].Title6;


            holder.statusText.Text = Items[position].Category;
            if (Items[position].Category == "Xamarin")
            {
                holder.statusText.SetTextColor(Color.Rgb(9, 155, 11));
            }
            else if (Items[position].Category == "Interview")
            {
                holder.statusText.SetTextColor(Color.Rgb(238, 134, 31));
            }


        }




        public class XamarinAdapterViewHolder : RecyclerView.ViewHolder
        {
            //public TextView TextView { get; set; }
            public TextView namecourseText { get; set; }
            public TextView numberText { get; set; }
            public TextView content1Text { get; set; }
            public TextView content2Text { get; set; }
            public TextView content3Text { get; set; }
            public TextView content4Text { get; set; }
            public TextView content5Text { get; set; }
            public TextView content6Text { get; set; }

            public TextView title1Text { get; set; }
            public TextView title2Text { get; set; }
            public TextView title3Text { get; set; }
            public TextView title4Text { get; set; }
            public TextView title5Text { get; set; }
            public TextView title6Text { get; set; }
            public TextView statusText { get; set; }

            public XamarinAdapterViewHolder(View itemView, Action<AluminiAdapterClickEventArgs> clickListener,
                                Action<AluminiAdapterClickEventArgs> LongClickListener, Action<AluminiAdapterClickEventArgs> deleteClickListener) : base(itemView)
            {
                //TextView = v;
                namecourseText = (TextView)itemView.FindViewById(Resource.Id.course);
                numberText = (TextView)itemView.FindViewById(Resource.Id.number);
                content1Text = (TextView)itemView.FindViewById(Resource.Id.content1Text);
                content2Text = (TextView)itemView.FindViewById(Resource.Id.content2Text);
                content3Text = (TextView)itemView.FindViewById(Resource.Id.content3Text);
                content4Text = (TextView)itemView.FindViewById(Resource.Id.content4Text);
                content5Text = (TextView)itemView.FindViewById(Resource.Id.content5Text);
                content6Text = (TextView)itemView.FindViewById(Resource.Id.content6Text);

                title1Text = (TextView)itemView.FindViewById(Resource.Id.title1Text);
                title2Text = (TextView)itemView.FindViewById(Resource.Id.title2Text);
                title3Text = (TextView)itemView.FindViewById(Resource.Id.title3Text);
                title4Text = (TextView)itemView.FindViewById(Resource.Id.title4Text);
                title5Text = (TextView)itemView.FindViewById(Resource.Id.title5Text);
                title6Text = (TextView)itemView.FindViewById(Resource.Id.title6Text);

                statusText = (TextView)itemView.FindViewById(Resource.Id.statusText);


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
