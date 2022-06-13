using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Views;
using Android.Widget;
using Project1.Activities.Essentials;
using Project1.Resources.Fragment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.View;

namespace Project1.Activities
{
    [Activity(Label = "report")]
    public class report : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        EditText sento, subject, content;
        Button btnsent;
        Spinner spinner;
        ImageView backButton;
        private DrawerLayout mDrawerLayout;

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.report);



            backButton = FindViewById<ImageView>(Resource.Id.backButton);
            backButton.Click += BackButton_Click;
           sento = FindViewById<EditText>(Resource.Id.edtTo);
            content = FindViewById<EditText>(Resource.Id.edtMessage);
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            string firstitem = spinner.SelectedItem.ToString();
            spinner.ItemSelected += (s, e) =>
            {

                if (firstitem.Equals(spinner.SelectedItem.ToString()))
                {

                }
                else
                {
                    Toast.MakeText(this, "Your have selected: " + e.Parent.GetItemAtPosition(e.Position).ToString(), ToastLength.Short).Show();
                }
            };

            btnsent = FindViewById<Button>(Resource.Id.btnSend);
            btnsent.Click += (s, e) =>
            {
                Intent email = new Intent(Intent.ActionSend);
                email.PutExtra(Intent.ExtraEmail, new String[] { sento.Text.ToString() });
                email.PutExtra(Intent.ExtraSubject, spinner.SelectedItem.ToString());
                email.PutExtra(Intent.ExtraText, content.Text.ToString());
                email.SetType("message/rfc822");
                StartActivity(Intent.CreateChooser(email, "Sent Email"));


            };





            SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(toolBar);

            SupportActionBar ab = SupportActionBar;
            ab.SetHomeAsUpIndicator(Resource.Drawable.menu16);
            ab.SetDisplayHomeAsUpEnabled(true);

         //   mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);
                //    txtName.Text = FirebaseAuth.Instance.CurrentUser.PhoneNumber;


            }


            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                // Commit the transaction.
                _ = new Intent(this, typeof(report)).SetFlags(ActivityFlags.ReorderToFront);
                Intent intent;
                switch (e.MenuItem.ItemId)
                {
                    case (Resource.Id.nav_feedback):
                        mDrawerLayout.CloseDrawers();
                        break;
                    case (Resource.Id.home):
                         intent = new Intent(this, typeof(MainActivity2)).SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        break;
                    case (Resource.Id.nav_sentSMS):
                        intent = new Intent(this, typeof(SentSms)).SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        break;
                    case (Resource.Id.nav_RePort):
                        intent = new Intent(this, typeof(MyIntro)).SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        break;
                    case (Resource.Id.nav_aboutus):
                        intent = new Intent(this, typeof(About)).SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(intent);
                        break;
                }


                //  ft.Commit();
                e.MenuItem.SetCheckable(false);
                mDrawerLayout.CloseDrawers();

            };



        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity2));
            StartActivity(intent);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return true;
        }

        private void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {
                e.MenuItem.SetChecked(true);
                     mDrawerLayout.CloseDrawers();
            };
        }
        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            int id = menuItem.ItemId;

            if (id == Resource.Id.nav_home)
            {
                // Handle the camera action
            }
            else if (id == Resource.Id.nav_aboutus)
            {

            }

            else if (id == Resource.Id.nav_feedback)
            {

            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

    }
}