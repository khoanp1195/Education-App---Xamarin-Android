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
    public class XamarinInterview
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string Content3 { get; set; }
        public string muc { get; set; }

        public XamarinInterview(int id, string tittle, string content1, string content2, string content3, string muc)
        {
            Id = id;
            Tittle = tittle;
            Content1 = content1;
            Content2 = content2;
            Content3 = content3;
            this.muc = muc;
        }
    }
}