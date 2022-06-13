using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Activities.CurvedBottom
{
    public class CurvedBottomNavigationView : BottomNavigationView
    {
        private Path mPath;
        private Paint mPaint;

        //Radius Of FabButton
        public int CURVE_CIRCLE_RADIUS = 90;

        //The Cooridinate of the first curve
        public Point mFirstCurveStartPoint = new Point();
        public Point mFirstCurveEndPoint = new Point();
        public Point mFirstCurveControlPoint1 = new Point();
        public Point mFirstCurveControlPoint2 = new Point();


        //The Second Cooridinate of the first curve
        public Point mSecondCurveStartPoint = new Point();
        public Point mSecondCurveEndPoint = new Point();
        public Point mSecondCurveControlPoint1 = new Point();
        public Point mSecondCurveControlPoint2 = new Point();


        public int mNavigationWidth, mNavigationHeight;

        //Constructor
        //public CurvedBottomNavigationView(Context context): super(context)
        //{
        //    InitView();
        //}

        public CurvedBottomNavigationView(Context context) :base(context)
        {
            InitView();
        }


        public CurvedBottomNavigationView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            InitView();
        }

        public CurvedBottomNavigationView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            InitView();
        }
        private void InitView()
        {
            mPath = new Path();
            mPaint = new Paint();
            mPaint.SetStyle(Paint.Style.FillAndStroke);
            mPaint.Color = Color.White;
            SetBackgroundColor(Color.Transparent);
        }
        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            mNavigationHeight = Height;
            mNavigationWidth = Width;


            mFirstCurveStartPoint.Set(mNavigationWidth / 2 - CURVE_CIRCLE_RADIUS * 2
                - CURVE_CIRCLE_RADIUS / 3, 0);

            mFirstCurveEndPoint.Set(mNavigationWidth / 2, CURVE_CIRCLE_RADIUS + (CURVE_CIRCLE_RADIUS / 4));

            mSecondCurveEndPoint.Set(mNavigationWidth / 2 + CURVE_CIRCLE_RADIUS * 2 + CURVE_CIRCLE_RADIUS / 3, 0);



            mFirstCurveControlPoint1.Set(mFirstCurveStartPoint.X + CURVE_CIRCLE_RADIUS + CURVE_CIRCLE_RADIUS/4,mFirstCurveStartPoint.Y);


            mFirstCurveControlPoint2.Set(mFirstCurveEndPoint.X - CURVE_CIRCLE_RADIUS * 2 + CURVE_CIRCLE_RADIUS, mFirstCurveEndPoint.Y);


            mSecondCurveControlPoint1.Set(mSecondCurveStartPoint.X + CURVE_CIRCLE_RADIUS * 2 - CURVE_CIRCLE_RADIUS, mSecondCurveStartPoint.Y);

            mSecondCurveControlPoint2.Set(mSecondCurveEndPoint.X - CURVE_CIRCLE_RADIUS + CURVE_CIRCLE_RADIUS / 4, mSecondCurveEndPoint.Y);







        }


        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            mPath.Reset();
            mPath.MoveTo(0f, 0f);
            mPath.LineTo(mFirstCurveStartPoint.X,mFirstCurveStartPoint.Y);
            mPath.CubicTo(mFirstCurveControlPoint1.X, mFirstCurveControlPoint1.Y,
                mFirstCurveControlPoint2.X, mFirstCurveControlPoint2.Y,
                mFirstCurveEndPoint.X, mFirstCurveEndPoint.Y);


            mPath.CubicTo(mSecondCurveControlPoint1.X, mSecondCurveControlPoint1.Y,
        mSecondCurveControlPoint2.X, mSecondCurveControlPoint2.Y,
        mSecondCurveEndPoint.X, mSecondCurveEndPoint.Y);

            mPath.LineTo(mNavigationWidth, 0);
            mPath.LineTo(mNavigationWidth, mNavigationHeight);
            mPath.LineTo(0, mNavigationHeight);
            mPath.Close();

            canvas.DrawPath(mPath, mPaint);
        }
    }
}