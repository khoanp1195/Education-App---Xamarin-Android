using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.Model
{
    public class UserRanking
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Score { get; set; }
        public string Time { get; set; }
        public string Category { get; set; }
    }
}