using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Project1.Acitivties.ActivitiesPlaying;
using Project1.Common;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities.AddQuestionQuizz
{
    [Activity(Label = "AddQuestionQuizz", MainLauncher = false)]
    public class QuestionQuizz : AppCompatActivity
    {
        ListView lstView;
        ImageView addButton;
        ImageView searchButton, backButton;

        EditText edtSearch;
        ImageView imgSearch;
        List<IQQuestion> listItsms = null;


        RelativeLayout relativeLayout1;

        //Floating Button
        private static bool isFabOpen;
        private FloatingActionButton fabAirballoon;
        private FloatingActionButton fabCake;
        private FloatingActionButton fabMain;
        private FloatingActionButton fabNote;


        AddQuestionQuizzDialogFragment addQuestionQuizzDialogFragment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.QuestionQuizz);


            relativeLayout1 = (RelativeLayout)FindViewById(Resource.Id.relativeLayout1);
            edtSearch = (EditText)FindViewById(Resource.Id.edtSearch);
            imgSearch = (ImageView)FindViewById(Resource.Id.imgSearch);

            imgSearch.Click += delegate
            {
                LoadQuestionList();
            };

            addButton = (ImageView)FindViewById(Resource.Id.addNewButton);
            backButton = (ImageView)FindViewById(Resource.Id.backButton);
            lstView = FindViewById<ListView>(Resource.Id.lstView);

            DbHelper.DbHelper db = new DbHelper.DbHelper(this);
            List<IQQuestion> lstQuestion = db.GetIQQuestions();
            if (lstQuestion.Count > 0)
            {
                QuestionCustomAdapter adapter = new QuestionCustomAdapter(this, lstQuestion);
                lstView.Adapter = adapter;
            }
            // Create your application here


            fabAirballoon = FindViewById<FloatingActionButton>(Resource.Id.fab_airballoon);
            fabCake = FindViewById<FloatingActionButton>(Resource.Id.fab_cake);
            fabNote = FindViewById<FloatingActionButton>(Resource.Id.fab_note);
            fabNote.Click += (o, e) =>
            {
                //if (!isFabOpen)
                //    ShowFabMenu();



                //else
                //    CloseFabMenu();

                addQuestionQuizzDialogFragment = new AddQuestionQuizzDialogFragment();
                var trans = SupportFragmentManager.BeginTransaction();
                addQuestionQuizzDialogFragment.Show(trans, "New Question");
                CloseFabMenu();
          

            };

            fabMain = FindViewById<FloatingActionButton>(Resource.Id.fab_main);


            fabMain.Click += (o, e) =>
            {
                if (!isFabOpen)
                    ShowFabMenu();
                else
                    CloseFabMenu();
            };

            fabCake.Click += (o, e) =>
            {
                CloseFabMenu();
                Toast.MakeText(this, "Test now...!", ToastLength.Short).Show();
                StartActivity(new Intent(this, typeof(UserAddQuestion)));
            };

            fabAirballoon.Click += (o, e) =>
            {
                CloseFabMenu();
                Toast.MakeText(this, "Search!", ToastLength.Short).Show();


                if (relativeLayout1.Visibility == Android.Views.ViewStates.Gone)
                {
                    relativeLayout1.Visibility = Android.Views.ViewStates.Visible;
                }
                else
                {
                    relativeLayout1.ClearFocus();
                    relativeLayout1.Visibility = Android.Views.ViewStates.Gone;
                }

            };



            backButton.Click += BackButton_Click;
            addButton.Click += AddButton_Click;
        }

        private void ShowFabMenu()
        {
            isFabOpen = true;
            fabNote.Visibility = ViewStates.Visible;
            fabAirballoon.Visibility = ViewStates.Visible;
            fabCake.Visibility = ViewStates.Visible;


            fabMain.Animate().Rotation(135f);

            fabAirballoon.Animate()
                .TranslationY(-Resources.GetDimension(Resource.Dimension.standard_100))
                .Rotation(0f);
            fabCake.Animate()
                .TranslationY(-Resources.GetDimension(Resource.Dimension.standard_55))
                .Rotation(0f);
            fabNote.Animate()
       .TranslationY(-Resources.GetDimension(Resource.Dimension.standard_145))
       .Rotation(0f);
        }

        private void CloseFabMenu()
        {
            isFabOpen = false;

            fabNote.Animate().Rotation(0f)

              .TranslationY(0f)
              .Rotation(90f);
            fabMain.Animate().Rotation(0f)

                .TranslationY(0f)
                .Rotation(90f);
            fabCake.Animate()
                .TranslationY(0f)
                .Rotation(90f).SetListener(new FabAnimatorListener(fabCake, fabAirballoon));
        }

        private class FabAnimatorListener : Java.Lang.Object, Animator.IAnimatorListener
        {
            View[] viewsToHide;

            public FabAnimatorListener(params View[] viewsToHide)
            {
                this.viewsToHide = viewsToHide;
            }

            public void OnAnimationCancel(Animator animation)
            {
            }

            public void OnAnimationEnd(Animator animation)
            {
                if (!isFabOpen)
                    foreach (var view in viewsToHide)
                        view.Visibility = ViewStates.Gone;
            }

            public void OnAnimationRepeat(Animator animation)
            {
            }

            public void OnAnimationStart(Animator animation)
            {
            }
        }







        private void LoadQuestionList()
        {
            DbHelper.DbHelper dbVals = new DbHelper.DbHelper(this);
            if (edtSearch.Text.Trim().Length < 1)
            {
                listItsms = dbVals.GetIQQuestions();
            }
            else
            {

                listItsms = dbVals.GetContactsBySearchName(edtSearch.Text.Trim());
            }

            lstView.Adapter = new QuestionCustomAdapter(this, listItsms);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.EnterFromLeft, Resource.Animation.abc_popup_enter);
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            addQuestionQuizzDialogFragment = new AddQuestionQuizzDialogFragment();
            var trans = SupportFragmentManager.BeginTransaction();
            addQuestionQuizzDialogFragment.Show(trans, "New Question");
        }
    }
}