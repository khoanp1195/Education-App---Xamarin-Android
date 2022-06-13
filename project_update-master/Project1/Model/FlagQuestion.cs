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
    public class FlagQuestion
    {
        public int Id { get; set; }
     //   public string question { get; set; }
        public string Image { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
 

        public FlagQuestion(int id, string image, string answerA, string answerB, string answerC, string answerD, string correctAnswer)
        {
            Id = id;
            Image = image;
            AnswerA = answerA;
            AnswerB = answerB;
            AnswerC = answerC;
            AnswerD = answerD;
            CorrectAnswer = correctAnswer;
     
        }
    }
}