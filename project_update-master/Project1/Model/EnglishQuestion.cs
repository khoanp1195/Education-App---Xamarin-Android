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
    public class EnglishQuestion
    {
        public int Id { get; set; } 
        public string Question { get; set; }
        public string ans_A { get; set; }
        public string ans_B { get; set; }
        public string ans_C { get; set; }
        public string ans_D { get; set; }
        public string result { get; set; }
        public string image { get; set; }

        public EnglishQuestion(int id, string question, string ans_A, string ans_B, string ans_C, string ans_D, string result, string image)
        {
            Id = id;
            Question = question;
            this.ans_A = ans_A;
            this.ans_B = ans_B;
            this.ans_C = ans_C;
            this.ans_D = ans_D;
            this.result = result;
            this.image = image;
        }
    }
}