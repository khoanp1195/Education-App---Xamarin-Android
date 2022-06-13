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
using Android.Support.V4.Widget;

namespace Project1
{
    public class NormalInterview : Android.Support.V4.App.Fragment
    {
        RecyclerView myRecyclerView;
        List<XamarinCourse> xamarinList;

        XamarinListeners xamarinListeners;


        LinearLayout linearLayout;

        XamarinAdapter adapter;

        ExpandableListAdapter listAdapter;
        ExpandableListView expListView;
        List<string> listDataHeader;
        Dictionary<string, List<string>> listDataChild;
        int previousGroup = -1;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here    
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.ExpandableView, container, false);


            expListView = view.FindViewById<ExpandableListView>(Resource.Id.lvExp);

            myRecyclerView = (RecyclerView)view.FindViewById(Resource.Id.recyclerView1);
            linearLayout = (LinearLayout)view.FindViewById(Resource.Id.linearLayout1);


            // Prepare list data
            FnGetListData();

            //Bind list
            listAdapter = new ExpandableListAdapter((Activity)Context, listDataHeader, listDataChild);
            expListView.SetAdapter(listAdapter);

            FnClickEvents();




            return view;
        }

        void FnClickEvents()
        {
            //Listening to child item selection
            expListView.ChildClick += delegate (object sender, ExpandableListView.ChildClickEventArgs e) {
                Toast.MakeText(Context, "child clicked", ToastLength.Short).Show();
            };

            //Listening to group expand
            //modified so that on selection of one group other opened group has been closed
            expListView.GroupExpand += delegate (object sender, ExpandableListView.GroupExpandEventArgs e) {

                if (e.GroupPosition != previousGroup)
                    expListView.CollapseGroup(previousGroup);
                previousGroup = e.GroupPosition;
            };

            //Listening to group collapse
            expListView.GroupCollapse += delegate (object sender, ExpandableListView.GroupCollapseEventArgs e) {
                Toast.MakeText(Context, "group collapsed", ToastLength.Short).Show();
            };

        }
        void FnGetListData()
        {
            listDataHeader = new List<string>();
            listDataChild = new Dictionary<string, List<string>>();

            // Adding child data
            listDataHeader.Add("Q1: What is Xamarin?");
            listDataHeader.Add("Q2: How to display static HTML string in Xamarin.Forms?");
            listDataHeader.Add("Q3: What are Pages in Xamarin.Forms?");
            listDataHeader.Add("Q4: Name few widely used Layout Controls ");
            listDataHeader.Add("Q5: What are Pages in Xamarin.Forms?");
            listDataHeader.Add("Q6: What are the various flavors of Xamarin Applications that can be made?");
            listDataHeader.Add("Q7: What is the basic architecture of Xamarin.Forms project?");
            listDataHeader.Add("Q8: What is the difference between Margin and Padding properties?");
            listDataHeader.Add("Q9: Explain Lifecycle methods of Xamarin.Forms app ");
            listDataHeader.Add("Q10: What is Xamarin.Forms and what are the benefits of using it?");

            // Adding child data
            var lstCS = new List<string>();
            lstCS.Add("Xamarin is a Cross Platform Mobile Development technology by Microsoft where we can develop the native app using the same code base across all platforms (iOS, Android, UWP) " +
                "using the C# language. Xamarin uses two approaches for the app development:Xamarin.Forms and Xamarin Native." + "\n" + "Xamarin.Forms uses MVVM & XAML while Xamarin Native uses native UI technology and MVC or MVVMCross Architecture.");


            var lstEC = new List<string>();
            lstEC.Add("We can use WebView control to display static HTML string. WebView can be used to display Websites, HTML string, Documents, Local Files depending on the platform support.");


            var lstMech = new List<string>();
            lstMech.Add("Pages are Xamarin Forms generic representation of Cross Mobil Application Screens. A Page occupies most or all of a screen and contains a single child." +
                "On IOS, the Page is mapped to ViewController, on Android, it is mapped to somewhat like Activity and on Universal Windows Platform, it is mapped to  Page.Pages can be of several types, viz.Master / Detail Page, navigational Page, Carousel Page, Tabbed Page, Template Page, etc.");


            var Q4 = new List<string>();
            Q4.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");
            var Q5 = new List<string>();
            Q5.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");


            var Q6 = new List<string>();
            Q6.Add("Xamarin allows two different ways of creating applications, based on the amount of code reusability and customization:" +
                "The first approach is the Traditional Native Approach wherein platform - specific apps using Xamarin.iOSiOS and Xamarin.Android can be made. This way of creating apps is generally used when there is a lot of customization specific to the platform is required as it allows direct access to platform - specific APIs.Xamarin.iOS is used for iOS applications and Xamarin.Android is used to create Android applications." +
                "The second approach is creating apps through Xamarin.Forms approach.Xamarin.Forms are used when there is a possibility of reuse of a lot of platform - independent code and the focus is less on custom UI.The platform - independent code is separated and kept in Shared Project or PCL or.NET Standard Library and Platform Specific projects consume this common code by including it.");



            var Q7 = new List<string>();
            Q7.Add("Xamarin.Forms can consists of four (this varies based on requirements) projects under one solution." +
                ".NET Standard, PCL or Shared Project" +
                "iOS ProjectAndroid Project" +
                "UWP Project" +
                "Here, .NET Standard, PCL or Shared Project contains all UI & Business logic inside it." +
                "iOS, Android, UWP contains platform specific code containing Renderers or Dependency Services Implementations.");

            var Q8 = new List<string>();
            Q8.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");

            var Q9 = new List<string>();
            Q9.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");

            var Q10 = new List<string>();
            Q10.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");
            var Q11 = new List<string>();
            Q11.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");

            var Q12 = new List<string>();
            Q12.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");

            var Q13 = new List<string>();
            Q13.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");
            var Q14 = new List<string>();
            Q14.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");


            var Q15 = new List<string>();
            Q15.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");

            var Q16 = new List<string>();
            Q16.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");

            var Q17 = new List<string>();
            Q17.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");

            var Q18 = new List<string>();
            Q18.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");
            var Q19 = new List<string>();
            Q19.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");

            var Q20 = new List<string>();
            Q20.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");

            var Q21 = new List<string>();
            Q21.Add("Frame: It contains a single element as a child having a default padding of 20." +
                "Grid: It is used when UI components are to be arranged into Rows & Columns." +
                "StackLayout: It is used when UI components are to be arranged either horizontally or vertically." +
                "ScrollView: It enables the scrolling for a child element if required.It has one child only." +
                "There are other Layout Controls too like AbsoluteLayout, RelativeLayout, ContentView, ContentPresenter, etc.");




            // Header, Child data
            listDataChild.Add(listDataHeader[0], lstCS);
            listDataChild.Add(listDataHeader[1], lstEC);
            listDataChild.Add(listDataHeader[2], lstMech);
            listDataChild.Add(listDataHeader[3], Q4);
            listDataChild.Add(listDataHeader[4], Q5);
            listDataChild.Add(listDataHeader[5], Q6);
            listDataChild.Add(listDataHeader[6], Q7);
            listDataChild.Add(listDataHeader[7], Q8);
            listDataChild.Add(listDataHeader[8], Q9);
            listDataChild.Add(listDataHeader[9], Q10);

            //listDataChild.Add(listDataHeader[11], Q12);
            //listDataChild.Add(listDataHeader[12], Q13);
            //listDataChild.Add(listDataHeader[13], Q14);
            //listDataChild.Add(listDataHeader[14], Q15);
            //listDataChild.Add(listDataHeader[15], Q16);
            //listDataChild.Add(listDataHeader[16], Q17);
            //listDataChild.Add(listDataHeader[17], Q18);
            //listDataChild.Add(listDataHeader[18], Q19);
            //listDataChild.Add(listDataHeader[19], Q20);
            // listDataChild.Add(listDataHeader[20], Q21);
        }





    }
}