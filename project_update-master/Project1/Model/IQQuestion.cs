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
    public class IQQuestion
    {

        public int Id { get; set; }
        public string Question { get; set; }
        public string Image { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
     
        public string muc { get; set; }


        public IQQuestion()
        {
        }

        public IQQuestion(int id, string question, string image, string answerA, string answerB, string answerC, string answerD, string correctAnswer, string muc)
        {
            Id = id;
            Question = question;
            Image = image;
            AnswerA = answerA;
            AnswerB = answerB;
            AnswerC = answerC;
            AnswerD = answerD;
            CorrectAnswer = correctAnswer;
       
            this.muc = muc;
        }

      
    }
}