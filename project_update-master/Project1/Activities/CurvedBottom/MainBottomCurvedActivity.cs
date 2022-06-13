using Android.Animation;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Sdsmdg.Harjot.Vectormaster;
using Com.Sdsmdg.Harjot.Vectormaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Support.Design.Widget.BottomNavigationView;

namespace Project1.Activities.CurvedBottom
{
    [Activity(Label = "MainBottomCurvedActivity",MainLauncher =false)]
    public class MainBottomCurvedActivity : AppCompatActivity,IOnNavigationItemSelectedListener
    {

        private CurvedBottomNavigationView bottom_nav;
        private VectorMasterView home, ranking, quiz;

        RelativeLayout relativeLayout1;
        private PathModel outline;
        ValueAnimator valueAnimator;

        public bool OnNavigationItemSelected(IMenuItem item)
        {
           switch(item.ItemId)
            {
                case Resource.Id.action_home:
                    Draw(6);
                    relativeLayout1.SetX(bottom_nav.mFirstCurveControlPoint1.X);
                    home.Visibility = ViewStates.Visible;
                    ranking.Visibility = ViewStates.Gone;
                    quiz.Visibility = ViewStates.Gone;
                    SelectAnimation(home);
                    break;

                case Resource.Id.action_english:
                    Draw(2);
                    relativeLayout1.SetX(bottom_nav.mFirstCurveControlPoint1.X);
                    home.Visibility = ViewStates.Gone;
                    ranking.Visibility = ViewStates.Visible;
                    quiz.Visibility = ViewStates.Gone;
                    SelectAnimation(ranking);
                    break;

                case Resource.Id.action_ranking:
                    Draw();
                    relativeLayout1.SetX(bottom_nav.mFirstCurveControlPoint1.X);
                    home.Visibility = ViewStates.Gone;
                    ranking.Visibility = ViewStates.Gone;
                    quiz.Visibility = ViewStates.Visible;
                    SelectAnimation(quiz);
                    break;
            }
            return true;
        }

        private void Draw()
        {
            bottom_nav.mFirstCurveStartPoint.Set(bottom_nav.mNavigationWidth *10/12
               - bottom_nav.CURVE_CIRCLE_RADIUS * 2 - bottom_nav.CURVE_CIRCLE_RADIUS / 3, 0);
            bottom_nav.mFirstCurveEndPoint.Set(bottom_nav.mNavigationWidth * 10 / 12, bottom_nav.CURVE_CIRCLE_RADIUS +
              bottom_nav.CURVE_CIRCLE_RADIUS / 4);


            bottom_nav.mSecondCurveStartPoint = bottom_nav.mFirstCurveEndPoint;
            bottom_nav.mSecondCurveEndPoint.Set(bottom_nav.mNavigationWidth * 10 / 12 + bottom_nav.CURVE_CIRCLE_RADIUS * 2

                + bottom_nav.CURVE_CIRCLE_RADIUS / 3, 0);


            bottom_nav.mFirstCurveControlPoint1.Set(bottom_nav.mFirstCurveStartPoint.X
                + bottom_nav.CURVE_CIRCLE_RADIUS + bottom_nav.CURVE_CIRCLE_RADIUS / 4,
                bottom_nav.mFirstCurveStartPoint.Y);
            bottom_nav.mFirstCurveControlPoint2.Set(bottom_nav.mFirstCurveEndPoint.X
                - bottom_nav.CURVE_CIRCLE_RADIUS * 2 + bottom_nav.CURVE_CIRCLE_RADIUS,
                bottom_nav.mFirstCurveEndPoint.Y);

            //Second
            bottom_nav.mSecondCurveControlPoint1.Set(bottom_nav.mSecondCurveStartPoint.X
                + bottom_nav.CURVE_CIRCLE_RADIUS * 2 - bottom_nav.CURVE_CIRCLE_RADIUS,
                bottom_nav.mSecondCurveStartPoint.Y);


            bottom_nav.mSecondCurveControlPoint2.Set(bottom_nav.mSecondCurveEndPoint.X
          - bottom_nav.CURVE_CIRCLE_RADIUS + bottom_nav.CURVE_CIRCLE_RADIUS / 4,
          bottom_nav.mSecondCurveEndPoint.Y);
        }

        private void Draw(int i)
        {
            bottom_nav.mFirstCurveStartPoint.Set(bottom_nav.mNavigationWidth / i
                - bottom_nav.CURVE_CIRCLE_RADIUS * 2 - bottom_nav.CURVE_CIRCLE_RADIUS / 3, 0);
            bottom_nav.mFirstCurveEndPoint.Set(bottom_nav.mNavigationWidth / i, bottom_nav.CURVE_CIRCLE_RADIUS +
              bottom_nav.CURVE_CIRCLE_RADIUS / 4);


            bottom_nav.mSecondCurveStartPoint = bottom_nav.mFirstCurveEndPoint;
            bottom_nav.mSecondCurveEndPoint.Set(bottom_nav.mNavigationWidth / i + bottom_nav.CURVE_CIRCLE_RADIUS * 2

                + bottom_nav.CURVE_CIRCLE_RADIUS / 3, 0);


            bottom_nav.mFirstCurveControlPoint1.Set(bottom_nav.mFirstCurveStartPoint.X
                + bottom_nav.CURVE_CIRCLE_RADIUS + bottom_nav.CURVE_CIRCLE_RADIUS / 4,
                bottom_nav.mFirstCurveStartPoint.Y);
            bottom_nav.mFirstCurveControlPoint2.Set(bottom_nav.mFirstCurveEndPoint.X
                - bottom_nav.CURVE_CIRCLE_RADIUS * 2 + bottom_nav.CURVE_CIRCLE_RADIUS,
                bottom_nav.mFirstCurveEndPoint.Y);

            //Second
            bottom_nav.mSecondCurveControlPoint1.Set(bottom_nav.mSecondCurveStartPoint.X
                + bottom_nav.CURVE_CIRCLE_RADIUS * 2 - bottom_nav.CURVE_CIRCLE_RADIUS,
                bottom_nav.mSecondCurveStartPoint.Y);


            bottom_nav.mSecondCurveControlPoint2.Set(bottom_nav.mSecondCurveEndPoint.X
          - bottom_nav.CURVE_CIRCLE_RADIUS + bottom_nav.CURVE_CIRCLE_RADIUS/4,
          bottom_nav.mSecondCurveEndPoint.Y);

        }

        private void SelectAnimation(VectorMasterView fab)
        {
            outline = fab.GetPathModelByName("home");
            outline.StrokeColor = Color.White;
            outline.TrimPathEnd = 0.0f;

            //Init Value Animator
            valueAnimator = ValueAnimator.OfFloat(0f, 1f);
            valueAnimator.SetDuration(1000);
            valueAnimator.AddUpdateListener(new MyUpdateListener(this, fab));
            valueAnimator.Start();


        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CurvedBottom);
            // Create your application here

            bottom_nav = FindViewById<CurvedBottomNavigationView>(Resource.Id.bottom_navigation_bar);
            home = FindViewById<VectorMasterView>(Resource.Id.home);
            ranking = FindViewById<VectorMasterView>(Resource.Id.ranking);
            quiz = FindViewById<VectorMasterView>(Resource.Id.quiz);

            relativeLayout1 = FindViewById<RelativeLayout>(Resource.Id.relativeLayout1);

            bottom_nav.InflateMenu(Resource.Menu.bottomnav);
            bottom_nav.SelectedItemId = Resource.Id.action_home;

            bottom_nav.SetOnNavigationItemSelectedListener(this);

        }

        private class MyUpdateListener : Java.Lang.Object, ValueAnimator.IAnimatorUpdateListener
        {
            private MainBottomCurvedActivity mainBottomCurvedActivity;
            private VectorMasterView fab;
            
            public MyUpdateListener(MainBottomCurvedActivity mainBottomCurvedActivity, VectorMasterView fab)
            {
                this.mainBottomCurvedActivity = mainBottomCurvedActivity;
                this.fab = fab;
            }

            public void OnAnimationUpdate(ValueAnimator animation)
            {
                mainBottomCurvedActivity.outline.TrimPathEnd = (float)mainBottomCurvedActivity.valueAnimator.AnimatedValue;
                fab.Update();
                    
            }
        }
    }
}