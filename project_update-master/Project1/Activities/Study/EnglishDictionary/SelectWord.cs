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

namespace Project1.Study
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class SelectWord : AppCompatActivity
    {
        ImageView addButton;
        ImageView searchButton;
        EditText searchText;
        RecyclerView myRecyclerView;
        List<Alumini> AluminiList;

        AddAluminFragment addAluminFragment;
        AluminListeners aluminListener;


        LinearLayout linearLayout;

        AluminiAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.firebase);
            myRecyclerView = (RecyclerView)FindViewById(Resource.Id.recyclerView1);
            searchButton = (ImageView)FindViewById(Resource.Id.searchButton);
            addButton = (ImageView)FindViewById(Resource.Id.addNewButton);
            searchText = (EditText)FindViewById(Resource.Id.searchText);

            linearLayout = (LinearLayout)FindViewById(Resource.Id.linearLayout1);

            searchText.TextChanged += SearchText_TextChanged;
            searchButton.Click += SearchButton_Click;
            addButton.Click += AddButton_Click;

            RetriveData();

        }





        private void SearchText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<Alumini> SearchResult =
                (from alumini in AluminiList
                 where alumini.NewWord.ToLower().Contains(searchText.Text.ToLower()) || alumini.Spelling.ToLower().Contains(searchText.Text.ToLower()) ||
                 alumini.Mean.ToLower().Contains(searchText.Text.ToLower()) || alumini.Level.ToLower().Contains(searchText.Text.ToLower())
                 select alumini).ToList();

            adapter = new AluminiAdapter(SearchResult);
            myRecyclerView.SetAdapter(adapter);

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            addAluminFragment = new AddAluminFragment();
            var trans = SupportFragmentManager.BeginTransaction();
            addAluminFragment.Show(trans, "new Word");
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





        //Delete 
        private void Adapter_DeleteItemClick(object sender, AluminiAdapterClickEventArgs e)
        {
            string key = AluminiList[e.Position].ID;
            Android.Support.V7.App.AlertDialog.Builder deleteAlumini = new Android.Support.V7.App.AlertDialog.Builder(this);
            deleteAlumini.SetTitle("Delete Word");
            deleteAlumini.SetMessage("Are you sure?");
            deleteAlumini.SetPositiveButton("Continue", (deleteAlert, args) =>
            {
                // Deletes Alumini From the Database
                aluminListener.DeleteNormal(key);

                Snackbar snackbar = Snackbar.Make(linearLayout, "Delete Success", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Green);
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
        public void RetriveData()
        {
            aluminListener = new AluminListeners();
            aluminListener.Create1();
            aluminListener.AluminRetrived += AluminListener_AluminRetrived;
        }

        private void AluminListener_AluminRetrived(object sender, AluminListeners.AluminDataEventArgs e)
        {
            AluminiList = e.Alumini;
            SetupRecyClerView();
        }


        //Search
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