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
    public class Tasks
    {
        public string Id { get; set; }
        public string Tittle { get; set; }
        public string ContentTask { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}