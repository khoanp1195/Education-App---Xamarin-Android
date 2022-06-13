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
    class UserContributeAdapter : RecyclerView.Adapter
    {
        public event EventHandler<UserContributeAdapterClickEventArgs> ItemClick;
        public event EventHandler<UserContributeAdapterClickEventArgs> ItemLongClick;
        public event EventHandler<UserContributeAdapterClickEventArgs> DeleteItemClick; 
        List<Alumini> Items;

        private Context context;
        public UserContributeAdapter(List<Alumini>Data)
        {
            Items = Data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.usercontribute, parent, false);
           


            var vh = new UserContributeAdapterViewHolder(itemView, OnClick, OnLongClick, OnDeleteClick);
            return vh;
        }





        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as UserContributeAdapterViewHolder;
            //holder.TextView.Text = items[position];
            holder.newWordText.Text = Items[position].NewWord;
           
            holder.meanText.Text = "Tiếng Việt: " + Items[position].Mean;
            holder.exampleText.Text = "Ví dụ: " + Items[position].Example;
            holder.meanenglishText.Text = "Mean: " + Items[position].MeanEnglish;
            holder.spellingText.Text = "Phiên âm " + Items[position].Spelling;

            holder.usercontributeText.Text = Items[position].Contribute;

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

        public Action<object, UserContributeListeners.AluminDataEventArgs> AluminRetrived { get; internal set; }

        void OnClick(UserContributeAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(UserContributeAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);
        void OnDeleteClick(UserContributeAdapterClickEventArgs args) => DeleteItemClick(this, args);
    }



   


    public class UserContributeAdapterViewHolder : RecyclerView.ViewHolder
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
        public UserContributeAdapterViewHolder(View itemView, Action<UserContributeAdapterClickEventArgs> clickListener,
                            Action<UserContributeAdapterClickEventArgs> LongClickListener, Action<UserContributeAdapterClickEventArgs> deleteClickListener) : base(itemView)
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
                itemView.Click += (sender, e) => clickListener(new UserContributeAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.Click += (sender, e) => LongClickListener(new UserContributeAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            deleteButton.Click += (sender, e) => deleteClickListener(new UserContributeAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }
  


    public class UserContributeAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}