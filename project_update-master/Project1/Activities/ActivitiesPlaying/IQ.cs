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
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using Project1.Activities;

using Project1.Fragment;
using Project1.Model;
using Xamarin.Essentials;
using static Android.Views.View;

namespace Project1.Acitivties.ActivitiesPlaying
{
    [Activity(Label = "Playing", Theme = "@style/AppTheme")]
    public class IQ : Activity, IOnClickListener
    {
        const int INTERVAL = 10000;
        const int TIMEOUT = 60000;
        public int progressValue = 0;



        Button quizBtn;

        MediaPlayer incorrect, correct, music;

        NestedScrollView constraintLayout;

        static CountDown mCountdown;
        List<IQQuestion> questionPlay = new List<IQQuestion>();
        DbHelper.DbHelper db;
        //DbHelper1 db;
        int score, thisQuestion, totalQuestion, correctAnswer;
        static int index;
        String mode = String.Empty;

        //Control
        public ProgressBar progressBar;

        ImageView imageview5;
        TextView questionCounter, question, option_1, option_2, option_3, option_4, txtScore, timer;


        //OnResume
        protected override void OnResume()
        {
            base.OnResume();
            index = 0;
            questionPlay = db.GetIQQuestionMode(mode);
            totalQuestion = questionPlay.Count;
            mCountdown = new CountDown(this, TIMEOUT, INTERVAL);
            ShowQuestion(index);
        }

        //OnCreate
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activityquiz);
            Control();
            //Get Data from MainActivity
            Bundle extra = Intent.Extras;
            if (extra != null)
                mode = extra.GetString("MODE");

            db = new DbHelper.DbHelper(this);

           incorrect = MediaPlayer.Create(this, Resource.Raw.incorrect);
            correct = MediaPlayer.Create(this, Resource.Raw.correct);

         
            



        }

        public void Control()
        {


            quizBtn = (Button)FindViewById(Resource.Id.quizBtn);
            quizBtn.Click += QuizBtn_Click;
            imageview5 = (ImageView)FindViewById(Resource.Id.view5);

            constraintLayout = (NestedScrollView)FindViewById(Resource.Id.constraintLayout1);

            questionCounter = (TextView)FindViewById(Resource.Id.questionCounter);
            questionCounter.Click += delegate
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_support dialog_Support = new dialog_support();
                dialog_Support.Show(transaction, "Support Here");


            };


            //Sound
            music = MediaPlayer.Create(this, Resource.Raw.showtimer);
            music.Start();
            music.Looping = true;


            //Controlbox
            timer = (TextView)FindViewById(Resource.Id.timer);
            txtScore = (TextView)FindViewById(Resource.Id.txtScore);
            question = (TextView)FindViewById(Resource.Id.question);
            option_1 = (TextView)FindViewById(Resource.Id.option_1);
            option_2 = (TextView)FindViewById(Resource.Id.option_2);
            option_3 = (TextView)FindViewById(Resource.Id.option_3);
            option_4 = (TextView)FindViewById(Resource.Id.option_4);
            progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);

            option_1.SetOnClickListener(this);
            option_2.SetOnClickListener(this);
            option_3.SetOnClickListener(this);
            option_4.SetOnClickListener(this);

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

        public void OnClick(View v)
        {
            mCountdown.Cancel();
            if (index < totalQuestion)
            {
                TextView btnClicked = (TextView)v;
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
                    Snackbar snackbar  = Snackbar.Make(constraintLayout, "Correct Answer is " + questionPlay[index].CorrectAnswer, Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Red);
                    snackbar.Show();

                    incorrect.Start();
                    Vibrate();
                    ShowQuestion(++index);
                    //  
                }
              
            }
            txtScore.Text = $"{score}";
        }

        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }


        public void ShowQuestion(int index)
        {
            if (index < totalQuestion)
            {
                thisQuestion++;
                questionCounter.Text = $"{thisQuestion}/{totalQuestion}";
                progressBar.Progress = progressValue = 0;
              
                int ImageID = this.Resources.GetIdentifier(questionPlay[index].Image.ToLower(), "drawable", PackageName);
                imageview5.SetBackgroundResource(ImageID);
                option_1.Text = questionPlay[index].AnswerA;
                option_2.Text = questionPlay[index].AnswerB;
                option_3.Text = questionPlay[index].AnswerC;
                option_4.Text = questionPlay[index].AnswerD;

                question.Text = questionPlay[index].Question;

                mCountdown.Start();

            }
            else
            {
                //{
                Intent intent = new Intent(this, typeof(Done));
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
     

       public class CountDown : CountDownTimer
        {
            IQ playing;
            

            public CountDown(IQ playing, long totalTime, long interval) : base(totalTime, interval)
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