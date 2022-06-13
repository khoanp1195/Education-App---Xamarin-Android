using Android.App;
using Android.Content;
using Android.Gms.Location;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Helper
{
    public class LocationCallbackHelper : LocationCallback
    {
        public EventHandler<OnLocationCaptureEventArgs> MyLocation;
        public class OnLocationCaptureEventArgs : EventArgs
        {
            public Android.Locations
                .Location Location
            { get; set; }

        }

            public override void OnLocationAvailability(LocationAvailability locationAvailability)
        {
            Log.Debug("Uber clone", "IsLocationAvailavle: {0}", locationAvailability.IsLocationAvailable);
        }

        public override void OnLocationResult(LocationResult result)
        {
            if(result.Locations.Count != 0)
            {
                MyLocation?.Invoke(this, new OnLocationCaptureEventArgs { Location = result.Locations[0]});
            }
        }
        
            


       

        }



    }

  