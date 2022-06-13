using Project1.Model;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Project1.EventListener;

using System;

using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Project1.Adapter
{
    public class NotesAdapter : RecyclerView.Adapter
    {


        public event EventHandler<NotesAdapterClickEventArgs> ItemClick;
        public event EventHandler<NotesAdapterClickEventArgs> ItemLongClick;
        public event EventHandler<NotesAdapterClickEventArgs> DeleteItemClick;
     
        List<Notees> Items;

        private Context context;

        public NotesAdapter(List<Notees> Data)
        {
            Items = Data;
        }

    

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as NotesAdapterViewHolder;
            //holder.TextView.Text = items[position];
   


            holder.titleText.Text = Items[position].Title;

            holder.contentText.Text =  Items[position].Content;
            holder.timeText.Text = Items[position].Time;


        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup your layout here                    
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.NoteItems, parent, false);



            var vh = new NotesAdapterViewHolder(itemView, OnClick, OnLongClick, OnDeleteClick);
            return vh;
        }

        public Action<object, TakeNotesListeners.TakeNotesDataEventArgs> TakeNotesRetrived { get; internal set; }


        void OnClick(NotesAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(NotesAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

        void OnDeleteClick(NotesAdapterClickEventArgs args) => DeleteItemClick(this, args);

        public override int ItemCount => Items.Count;




    }


    public class NotesAdapterViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }
        public TextView titleText { get; set; }
        public TextView contentText { get; set; }
        public TextView timeText { get; set; }

        public ImageView deleteBtn { get; set; }

        public NotesAdapterViewHolder(View itemView, Action<NotesAdapterClickEventArgs> clickListener,
                            Action<NotesAdapterClickEventArgs> LongClickListener,
                            Action<NotesAdapterClickEventArgs> deleteClickListener

                            ) : base(itemView)
        {
            //TextView = v;
            titleText = (TextView)itemView.FindViewById(Resource.Id.txtTitle);
            timeText = (TextView)itemView.FindViewById(Resource.Id.txtTimer);
            contentText = (TextView)itemView.FindViewById(Resource.Id.txtContent);


            deleteBtn = (ImageView)itemView.FindViewById(Resource.Id.ic_delete);


       
            itemView.Click += (sender, e) => clickListener(new NotesAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.Click += (sender, e) => LongClickListener(new NotesAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            deleteBtn.Click += (sender, e) => deleteClickListener(new NotesAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }



    public class NotesAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}