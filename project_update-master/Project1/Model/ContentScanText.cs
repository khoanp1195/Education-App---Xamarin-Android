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
    public class ContentScanText
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Timer { get; set; }

        public ContentScanText(int id, string content, string timer)
        {
            Id = id;
            Content = content;
            Timer = timer;
        }

        public ContentScanText()
        {
        }
    }
}