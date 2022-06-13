using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
{
    [Activity(Label = "IntroActivity")]
    public class IntroActivity : Activity
    {
        [Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.introlayout);
            // Create your application here

            RunOnUiThread(() =>
            {
                ISharedPreferences getPrefs = PreferenceManager.GetDefaultSharedPreferences(BaseContext);
                bool isFirstStart = getPrefs.GetBoolean("firstStart", true);

                if(isFirstStart)
                {
                    StartActivity(new Intent(this, typeof(MyIntro)));
                    Finish();
                    ISharedPreferencesEditor editor = getPrefs.Edit();
                    editor.PutBoolean("finish Start", false);
                    editor.Apply();
                }
            }
                  

          );
        }
    }
}