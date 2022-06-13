using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Graphics;
using Project1.Model;
using Android.Content;
using Xamarin.Essentials;
using Project1.EventListeners;

namespace Project1.Adapter
{
    class AluminiAdapter : RecyclerView.Adapter
    {
        public event EventHandler<AluminiAdapterClickEventArgs> ItemClick;
        public event EventHandler<AluminiAdapterClickEventArgs> ItemLongClick;
        public event EventHandler<AluminiAdapterClickEventArgs> DeleteItemClick; 
        List<Alumini> Items;

        private Context context;
        public AluminiAdapter(List<Alumini>Data)
        {
            Items = Data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.EnglishRow, parent, false);
           


            var vh = new AluminiAdapterViewHolder(itemView, OnClick, OnLongClick, OnDeleteClick);
            return vh;
        }





        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as AluminiAdapterViewHolder;
            //holder.TextView.Text = items[position];
            holder.newWordText.Text = Items[position].NewWord;
           
            holder.meanText.Text = "Tiếng Việt: " + Items[position].Mean;
            holder.exampleText.Text = "Ví dụ: " + Items[position].Example;
            holder.meanenglishText.Text = "Mean: " + Items[position].MeanEnglish;
            holder.spellingText.Text = "Phiên âm " + Items[position].Spelling;

            holder.usercontributeText.Text = Items[position].type;

            holder.typeText.Text = Items[position].type;
            if (Items[position].type == "None")
            {
                holder.spellingText.SetTextColor(Color.Rgb(9, 155, 11));
            }
            else if (Items[position].type == "n")
            {
                holder.spellingText.SetTextColor(Color.Rgb(238, 134, 31));
            }
            else if (Items[position].Level == "v")
            {
                holder.spellingText.SetTextColor(Color.Red);
            }
            else if (Items[position].Level == "adj")
            {
                holder.spellingText.SetTextColor(Color.Maroon);
            }
            else if (Items[position].Level == "adv")
            {
                holder.spellingText.SetTextColor(Color.Maroon);
            }




            holder.levelText.Text = Items[position].Level;
            if (Items[position].Level == "Normal")
            {
                holder.spellingText.SetTextColor(Color.Rgb(9, 155, 11));
            }
            else if (Items[position].Level == "Advanced")
            {
                holder.spellingText.SetTextColor(Color.Rgb(238, 134, 31));
            }
            else if (Items[position].Level == "Comunication")
            {
                holder.spellingText.SetTextColor(Color.Red);
            }
            else if (Items[position].Level == "Dropped Out")
            {
                holder.spellingText.SetTextColor(Color.Maroon);
            }

        }

        public override int ItemCount => Items.Count;

        public Action<object, AluminListeners.AluminDataEventArgs> AluminRetrived { get; internal set; }

        void OnClick(AluminiAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(AluminiAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);
        void OnDeleteClick(AluminiAdapterClickEventArgs args) => DeleteItemClick(this, args);
    }



   


    public class AluminiAdapterViewHolder : RecyclerView.ViewHolder
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
        public AluminiAdapterViewHolder(View itemView, Action<AluminiAdapterClickEventArgs> clickListener,
                            Action<AluminiAdapterClickEventArgs> LongClickListener, Action<AluminiAdapterClickEventArgs> deleteClickListener) : base(itemView)
        {
            //TextView = v;
            newWordText = (TextView)itemView.FindViewById(Resource.Id.nameText);
            meanText = (TextView)itemView.FindViewById(Resource.Id.departmentText);
            levelText = (TextView)itemView.FindViewById(Resource.Id.statusText);
            spellingText = (TextView)itemView.FindViewById(Resource.Id.setText);
            deleteButton = (ImageView)itemView.FindViewById(Resource.Id.deleteButton);
            exampleText = (TextView)itemView.FindViewById(Resource.Id.exampleText);
            typeText = (TextView)itemView.FindViewById(Resource.Id.tuloaiText);
            meanenglishText = (TextView)itemView.FindViewById(Resource.Id.exampleText2);
            usercontributeText = (TextView)itemView.FindViewById(Resource.Id.usercontributeText);
                itemView.Click += (sender, e) => clickListener(new AluminiAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.Click += (sender, e) => LongClickListener(new AluminiAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            deleteButton.Click += (sender, e) => deleteClickListener(new AluminiAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }
  


    public class AluminiAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}