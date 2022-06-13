using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Project1.Model
{
    public class FavoriteWord
    {
        public string NewWord { get; set; }
        public string Mean { get; set; }
        public string Spelling { get; set; }
        public string type { get; set; }
        public string Example { get; set; }
        public string MeanEnglish { get; set; }
        public string Contribute { get; set; }
        public string Level { get; set; }
        public int ID { get; set; }

  

        public FavoriteWord(int id, string newWord, string mean, string spelling, string type, string example, string meanEnglish, string contribute, string level)
        {
            ID = id;
            NewWord = newWord;
            Mean = mean;
            Spelling = spelling;
            this.type = type;
            Example = example;
            MeanEnglish = meanEnglish;
            Contribute = contribute;
            Level = level;
        }

        public FavoriteWord()
        {
        }
    }
}