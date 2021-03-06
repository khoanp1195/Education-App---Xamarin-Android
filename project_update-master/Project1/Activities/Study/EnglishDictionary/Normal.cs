using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System;

using System.Collections.Generic;

using System.Linq;
using Project1.Fragment;
using Project1.Model;
using Project1.EventListeners;
using Project1.Adapter;
using Xamarin.Essentials;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Graphics;
using Android.Content;
using Android.Support.V4.Widget;
using System.ComponentModel;
using System.Threading;
using Firebase.Database;

namespace Project1.Study
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class Normal : AppCompatActivity
    {
        ImageView addButton;
        ImageView searchButton, backButton;
        EditText searchText;
      
        AddAluminFragment addAluminFragment;


        //Swipe Refresh
        private SwipeRefreshLayout refreshLayout;

        EditText search;
        Button btnSearch;
        LinearLayout linearLayout;
        RecyclerView myRecyclerView;
        AluminiAdapter adapter;
        
        List<Alumini> AluminiList;
        AluminListeners aluminListener;


        ProgressDialogueFragment progressDialogue;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.firebase);
            myRecyclerView = (RecyclerView)FindViewById(Resource.Id.recyclerView1);
            searchButton = (ImageView)FindViewById(Resource.Id.searchButton);
            addButton = (ImageView)FindViewById(Resource.Id.addNewButton);
            searchText = (EditText)FindViewById(Resource.Id.searchText);
            backButton = (ImageView)FindViewById(Resource.Id.backButton);

            backButton.Click += BackButton_Click;

            linearLayout = (LinearLayout)FindViewById(Resource.Id.linearLayout1);

            searchText.TextChanged += SearchText_TextChanged;
            searchButton.Click += SearchButton_Click;
            addButton.Click += AddButton_Click;

            ShowProgressDialogue("Loading Data...");

            RetriveData();

            

            refreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.swipeRefreshLayout);
            refreshLayout.SetColorSchemeColors(Color.Red, Color.Green, Color.Blue, Color.Yellow);
            refreshLayout.Refresh += RefreshLayout_Refresh;


        }


        private void RefreshLayout_Refresh(object sender, EventArgs e)
        {
            //Data Refresh Place  
            BackgroundWorker work = new BackgroundWorker();
            work.DoWork += Work_DoWork;
            work.RunWorkerCompleted += Work_RunWorkerCompleted;
            work.RunWorkerAsync();
        }
        private void Work_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            refreshLayout.Refreshing = false;
        }
        private void Work_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
        }





        private void BackButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.EnterFromLeft, Resource.Animation.abc_popup_enter);
        }

        private void SearchText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<Alumini> SearchResult = new List<Alumini>
                (from alumini in AluminiList
                 where alumini.NewWord.ToLower().Contains(searchText.Text.ToLower()) || alumini.Spelling.ToLower().Contains(searchText.Text.ToLower()) ||
                 alumini.Mean.ToLower().Contains(searchText.Text.ToLower()) || alumini.Level.ToLower().Contains(searchText.Text.ToLower())
                 select alumini).ToList();
           

            adapter = new AluminiAdapter(SearchResult);
            adapter.DeleteItemClick += Adapter_DeleteItemClick;

            //SetupRecyClerView();
            adapter.ItemLongClick += Adapter_ItemLongClick1;
            aluminListener.AluminRetrived += AluminListener_AluminRetrived;
            myRecyclerView.SetAdapter(adapter);

        }
        public void RetriveData()
        {
            
            aluminListener = new AluminListeners();
            aluminListener.Create();
            
            aluminListener.AluminRetrived += AluminListener_AluminRetrived;
            ClossProgressDialogue();
        }

            

        private void AluminListener_AluminRetrived(object sender, AluminListeners.AluminDataEventArgs e)
        {
  
            AluminiList = e.Alumini;
            SetupRecyClerView();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            addAluminFragment = new AddAluminFragment();
            var trans = SupportFragmentManager.BeginTransaction();
            addAluminFragment.Show(trans, "new alumini");
        }

        private void SetupRecyClerView()
        {
            myRecyclerView.SetLayoutManager(new Android.Support.V7.Widget.LinearLayoutManager(myRecyclerView.Context));
            adapter = new AluminiAdapter(AluminiList);
            adapter.DeleteItemClick += Adapter_DeleteItemClick;


            adapter.ItemLongClick += Adapter_ItemLongClick1;
            myRecyclerView.SetAdapter(adapter);
        }

        private void Adapter_ItemLongClick1(object sender, AluminiAdapterClickEventArgs e)
        {
            Alumini thisAlumini = AluminiList[e.Position];
            EditAluminiFragment editAluminiFragment = new EditAluminiFragment(thisAlumini);
            var trans = SupportFragmentManager.BeginTransaction();
            editAluminiFragment.Show(trans, "edit");
        }


        void ShowProgressDialogue(string status)
        {
            progressDialogue = new ProgressDialogueFragment(status);
            var trans = SupportFragmentManager.BeginTransaction();
            progressDialogue.Cancelable = false;
            progressDialogue.Show(trans, "progress");
        }

        void ClossProgressDialogue()
        {
            if (progressDialogue != null)
            {
                progressDialogue.Dismiss();
                progressDialogue = null;
            }
        }


        //Delete 
        private void Adapter_DeleteItemClick(object sender, AluminiAdapterClickEventArgs e)
        {
            string key = AluminiList[e.Position].ID;
            Android.Support.V7.App.AlertDialog.Builder deleteAlumini = new Android.Support.V7.App.AlertDialog.Builder(this);
            deleteAlumini.SetTitle("Delete Alumini");
            deleteAlumini.SetMessage("Are you sure?");
            deleteAlumini.SetPositiveButton("Continue", (deleteAlert, args) =>
            {
                // Deletes Alumini From the Database
              ///  aluminListener.DeleteNormal(key);

                Snackbar snackbar = Snackbar.Make(linearLayout, "Sorry You Can't Delete", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
              
            });

            deleteAlumini.SetNegativeButton("Cancel", (deleteAlert, args) =>
            {
                deleteAlumini.Dispose();
                Snackbar snackbar = Snackbar.Make(linearLayout, "Delete Failed !!", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
            });

            deleteAlumini.Show();
        }

      
        private void SearchButton_Click(object sender, System.EventArgs e)
        {
            if (searchText.Visibility == Android.Views.ViewStates.Gone)
            {
                searchText.Visibility = Android.Views.ViewStates.Visible;
            }
            else
            {
                searchText.ClearFocus();
                searchText.Visibility = Android.Views.ViewStates.Gone;
            }
        }
    }
}

//public void CreateData()
//{
//    AluminiList = new List<Alumini>();
//    AluminiList.Add(new Alumini { Department = "Department of Computer Science", FullName = "Mark Edwardds", ID = "1", Set = "2011", Status = "Graduated" });
//    AluminiList.Add(new Alumini { Department = "Department of Civil Engineering", FullName = "Jonh Doe", ID = "2", Set = "2014", Status = "Graduated" });

//    AluminiList.Add(new Alumini { Department = "Department of King Studies", FullName = "John Snow", ID = "3", Set = "2012", Status = "Drop Out" });
//    AluminiList.Add(new Alumini { Department = "Department of History", FullName = "Uchenna Nnodim", ID = "4", Set = "2016", Status = "Graduated" });
//    AluminiList.Add(new Alumini { Department = "Department of Computer Science", FullName = "Gregg Williams", ID = "5", Set = "2014", Status = "Failed" });

//}


//Recieve DATA


//Search