using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using Project1.Activities;
using Project1.Model;
using Xamarin.Essentials;
using static Android.Views.View;

namespace Project1.Acitivties
{
    [Activity(Label = "Playing",Theme ="@style/AppTheme")]
    public class Flag : Activity,IOnClickListener
    {
        const int INTERVAL = 1000;
        const int TIMEOUT = 60000;
        public int progressValue = 0;



        Button quizBtn;


        //Media
        MediaPlayer incorrect, correct, music;


        static CountDown mCountdown;
        List<FlagQuestion> questionPlay = new List<FlagQuestion>();
        DbHelper.DbHelper db;
        int score, thisQuestion, totalQuestion, correctAnswer;
        static int index;
        String mode = String.Empty;

        ConstraintLayout constraintLayout;


        //Control
        public ProgressBar progressBar;
        ImageView imageView;
        Button btnA, btnB, btnC, btnD;
        TextView txtScore, txtQuestion, question, trueans;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.playing);

            //Get Data from MainActivity
            Bundle extra = Intent.Extras;
            if (extra != null)
                mode = extra.GetString("MODE");

            db = new DbHelper.DbHelper(this);
            Control();

            incorrect = MediaPlayer.Create(this, Resource.Raw.incorrect);
            correct = MediaPlayer.Create(this, Resource.Raw.correct);

        }

        public void Control()
        {


            quizBtn = FindViewById<Button>(Resource.Id.quizBtn);

            quizBtn.Click += QuizBtn_Click;

             //  question = FindViewById<TextView>(Resource.Id.question_txt);
            txtScore = FindViewById<TextView>(Resource.Id.txtScore);
            txtQuestion = FindViewById<TextView>(Resource.Id.txtQuestion);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            imageView = FindViewById<ImageView>(Resource.Id.question_flag);
            trueans = FindViewById<TextView>(Resource.Id.txtTrueAnswer);

            constraintLayout = (ConstraintLayout)FindViewById(Resource.Id.constraintLayout1);

            //Sound
            music = MediaPlayer.Create(this, Resource.Raw.showtimer);
            music.Start();
            music.Looping = true;


            question = FindViewById<TextView>(Resource.Id.question);
            btnA = FindViewById<Button>(Resource.Id.option_1);
            btnB = FindViewById<Button>(Resource.Id.option_2);
            btnC = FindViewById<Button>(Resource.Id.option_3);
            btnD = FindViewById<Button>(Resource.Id.option_4);

            btnA.SetOnClickListener(this);
            btnB.SetOnClickListener(this);
            btnC.SetOnClickListener(this);
            btnD.SetOnClickListener(this);
        }

        private void QuizBtn_Click(object sender, EventArgs e)
        {
            Android.Support.V7.App.AlertDialog.Builder deleteAlumini = new Android.Support.V7.App.AlertDialog.Builder(this);
            deleteAlumini.SetTitle("Comback Home");
            deleteAlumini.SetMessage("Are you sure?");
            deleteAlumini.SetPositiveButton("Continue", (deleteAlert, args) =>
            {
                // Deletes Alumini From the Database
                ///  aluminListener.DeleteNormal(key);

                Intent intent = new Intent(this, typeof(MainActivity2));
                StartActivity(intent);
                Finish();

            });

            deleteAlumini.SetNegativeButton("Cancel", (deleteAlert, args) =>
            {
                deleteAlumini.Dispose();
                Snackbar snackbar = Snackbar.Make(constraintLayout, "Delete Failed !!", Snackbar.LengthShort);
                View snackbarView = snackbar.View;
                snackbarView.SetBackgroundColor(Color.Red);
                snackbar.Show();
            });

           deleteAlumini.Show();
        }

        //Vibrate
        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }

        public void OnClick(View v)
        {
            mCountdown.Cancel();
            if(index < totalQuestion)
            {
                Button btnClicked = (Button)v;
                if (btnClicked.Text.Equals(questionPlay[index].CorrectAnswer))
                {
                    score += 10;
                    correctAnswer++;
                    Snackbar snackbar = Snackbar.Make(constraintLayout, "Good Job Bro!!!!! ", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Green);
                 
                    snackbar.Show();
                    correct.Start();
                    ShowQuestion(++index);
                }
                else
                {
                    Snackbar snackbar = Snackbar.Make(constraintLayout, "Correct Answer is " + questionPlay[index].CorrectAnswer, Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Red);
                    snackbar.Show();
                    Vibrate();
                    incorrect.Start();
                    ShowQuestion(++index);
                }
                   
            }
            txtScore.Text = $"{score}";
        }

        public void ShowQuestion(int index)
        {
          if(index < totalQuestion)
            {
                thisQuestion++;
                txtQuestion.Text = $"{thisQuestion}/{totalQuestion}";
                progressBar.Progress = progressValue = 0;

                int ImageID = this.Resources.GetIdentifier(questionPlay[index].Image.ToLower(), "drawable", PackageName);
                imageView.SetBackgroundResource(ImageID);
                btnA.Text = questionPlay[index].AnswerA;
                btnB.Text = questionPlay[index].AnswerB;
                btnC.Text = questionPlay[index].AnswerC;
                btnD.Text = questionPlay[index].AnswerD;
                 
            //    question.Text = questionPlay[index].Question;

                mCountdown.Start();

            }
          else
            {
                //{
                Intent intent = new Intent(this, typeof(DoneFlag));
                Bundle dataSend = new Bundle();
                dataSend.PutInt("SCORE", score);
                dataSend.PutInt("TOTAL", totalQuestion);
                dataSend.PutInt("CORRECT", correctAnswer);

                intent.PutExtras(dataSend);
                StartActivity(intent);
                music.Stop();
                Finish();
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            index = 0;
            questionPlay = db.GetQuestionMode(mode);
            totalQuestion = questionPlay.Count;
            mCountdown = new CountDown(this, TIMEOUT, INTERVAL);
            ShowQuestion(index);
        }


        class CountDown : CountDownTimer
        {
            Flag playing;

            public CountDown(Flag playing, long totalTime, long interval) : base(totalTime, interval)
            {
                this.playing = playing;
            }

            public override void OnFinish()
            {
                Cancel();
                
               playing.ShowQuestion(++index);
            }

            public override void OnTick(long millisUntilFinished)
            {
                playing.progressValue++;
                playing.progressBar.Progress = playing.progressValue;

            }
        }
    }


}