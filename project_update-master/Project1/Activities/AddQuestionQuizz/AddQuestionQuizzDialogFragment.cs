using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Firebase;
using Firebase.Database;
using Android.Views;
using Android.Gms.Maps;
using AndroidX.CardView.Widget;
using Android.Support.V7.Widget;
using Android.Content;
using Project1.Activities;
using Project1.Activities.Intro;
using System.Timers;
using System;
using Firebase.Auth;
using Android.Gms.Common;
using Android.Util;
using SupportV7 = Android.Support.V7.App;

using Project1.Model;
using Project1.Common;
using System.Collections.Generic;
using AndroidX.RecyclerView.Widget;
using Project1.EventListeners;
using Project1.Adapter;
using Project1.Fragment;
using System.Linq;
using Project1.Acitivties.Study;
using Android.Support.Design.Widget;
using FR.Ganfra.Materialspinner;
using Xamarin.Essentials;
using Android.Graphics;
using Java.Util;
using Project1.Helpers;
using Android.Gms.Vision;
using Android.Content.PM;
using Android;
using Android.Gms.Vision.Texts;
using Plugin.Media;
using System.Text;
using Android.Support.V4.Widget;

namespace Project1.Activities.AddQuestionQuizz
{
    [Activity(Label = "AddQuestionQuizz")]
    public class AddQuestionQuizzDialogFragment : Android.Support.V4.App.DialogFragment
    {
        EditText question, image, answera, answerb, answerc, answerd, correctAnswer, muc;
        Button submit;
        private TextView txtView;
        private ImageView imageview, camera1, process1, camera2, process2, camera3, process3, camera4, process4, camera5, process5,
            camera6, process6, camera7, process7;
        Android.Support.V7.Widget.CardView btnProcess;
        private CameraSource cameraSource;
        private const int RequestCameraPermissionID = 1001;

        Android.Support.V7.Widget.CardView captureButton;
        Button uploadButton;
        ImageView thisImageView;
        private SurfaceView cameraView;


        NestedScrollView nestedScrollView1;




        readonly string[] permissionGroup =
        {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera
        };

        List<IQQuestion> lstIqQuestion = new List<IQQuestion>();
       

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

         
            // Create your application here
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            View view = inflater.Inflate(Resource.Layout.AddQuestionQuizz, container, false);

           
         //   txtView = view.FindViewById<TextView>(Resource.Id.txtView);
            imageview = view.FindViewById<ImageView>(Resource.Id.thisImageView);
            btnProcess = view.FindViewById<Android.Support.V7.Widget.CardView>(Resource.Id.processBtn);

         

            btnProcess.Click += BtnProcess_Click;


            captureButton = (Android.Support.V7.Widget.CardView)view.FindViewById(Resource.Id.captureButton);
            
            thisImageView = (ImageView)view.FindViewById(Resource.Id.thisImageView);

            captureButton.Click += CaptureButton_Click;
        
            RequestPermissions(permissionGroup, 0);


            camera1 = (ImageView)view.FindViewById(Resource.Id.camera1);
            camera1.Click += Camera1_Click;
            camera2 = (ImageView)view.FindViewById(Resource.Id.camera2);
            camera2.Click += Camera2_Click;
            camera3 = (ImageView)view.FindViewById(Resource.Id.camera3);
            camera3.Click += Camera3_Click;
            camera4 = (ImageView)view.FindViewById(Resource.Id.camera4);
            camera4.Click += Camera4_Click;
            camera5 = (ImageView)view.FindViewById(Resource.Id.camera5);
            camera5.Click += Camera5_Click;
            camera6 = (ImageView)view.FindViewById(Resource.Id.camera6);
            camera6.Click += Camera6_Click;
            camera7 = (ImageView)view.FindViewById(Resource.Id.camera7);
            camera7.Click += Camera7_Click;

            process1 = (ImageView)view.FindViewById(Resource.Id.process1);
            process1.Click += Process1_Click;
            process2 = (ImageView)view.FindViewById(Resource.Id.process2);
            process2.Click += Process2_Click;
            process3 = (ImageView)view.FindViewById(Resource.Id.process3);
            process3.Click += Process3_Click;
            process4 = (ImageView)view.FindViewById(Resource.Id.process4);
            process4.Click += Process4_Click;
            process5 = (ImageView)view.FindViewById(Resource.Id.process5);
            process5.Click += Process5_Click;
            process6 = (ImageView)view.FindViewById(Resource.Id.process6);
            process6.Click += Process6_Click;
            process7 = (ImageView)view.FindViewById(Resource.Id.process7);
            process7.Click += Process7_Click;




            DbHelper.DbHelper db = new DbHelper.DbHelper(Context);
            question = (EditText)view.FindViewById(Resource.Id.edtQuestion);
            image = (EditText)view.FindViewById(Resource.Id.edtImage);
            answera = (EditText)view.FindViewById(Resource.Id.edtAsnwerA);
            answerb = (EditText)view.FindViewById(Resource.Id.edtAsnwerB);
            answerc = (EditText)view.FindViewById(Resource.Id.edtAsnwerC);
            answerd = (EditText)view.FindViewById(Resource.Id.edtAsnwerD);
            correctAnswer = (EditText)view.FindViewById(Resource.Id.edtCorrectAnswer);
            muc = (EditText)view.FindViewById(Resource.Id.edtmuc);


            submit = (Button)view.FindViewById(Resource.Id.submitbtn);
            submit.Click += delegate
            {
                string questionn = question.Text;
                string imagee = image.Text;
                string answeraa = answera.Text;
                string answerbb = answerb.Text;
                string answercc = answerc.Text;
                string answerdd = answerd.Text;
                string correctAnswerr = correctAnswer.Text;
                string mucc = muc.Text;


             if(questionn.Length <= 0)
                {
                    Snackbar snackbar1 = Snackbar.Make(nestedScrollView1, "Please enter text", Snackbar.LengthShort);
                    View snackbarView1 = snackbar1.View;
                    snackbarView1.SetBackgroundColor(Color.Red);
                    snackbar1.Show();
                    Vibrate();
                    return;
                }
                else if (imagee.Length <= 0)
                {
                    Snackbar snackbar1 = Snackbar.Make(nestedScrollView1, "Please enter text", Snackbar.LengthShort);
                    View snackbarView1 = snackbar1.View;
                    snackbarView1.SetBackgroundColor(Color.Red);
                    snackbar1.Show();
                    Vibrate();
                    return;
                }
                else if (answeraa.Length <= 0)
                {
                    Snackbar snackbar1 = Snackbar.Make(nestedScrollView1, "Please enter text", Snackbar.LengthShort);
                    View snackbarView1 = snackbar1.View;
                    snackbarView1.SetBackgroundColor(Color.Red);
                    snackbar1.Show();
                    Vibrate();
                    return;
                }
                else if (answerbb.Length <= 0)
                {
                    Snackbar snackbar1 = Snackbar.Make(nestedScrollView1, "Please enter text", Snackbar.LengthShort);
                    View snackbarView1 = snackbar1.View;
                    snackbarView1.SetBackgroundColor(Color.Red);
                    snackbar1.Show();
                    Vibrate();
                    return;
                }
                else if (answercc.Length <= 0)
                {
                    Snackbar snackbar1 = Snackbar.Make(nestedScrollView1, "Please enter text", Snackbar.LengthShort);
                    View snackbarView1 = snackbar1.View;
                    snackbarView1.SetBackgroundColor(Color.Red);
                    snackbar1.Show();
                    Vibrate();
                    return;
                }

                else if (answerdd.Length <= 0)
                {
                    Snackbar snackbar1 = Snackbar.Make(nestedScrollView1, "Please enter text", Snackbar.LengthShort);
                    View snackbarView1 = snackbar1.View;
                    snackbarView1.SetBackgroundColor(Color.Red);
                    snackbar1.Show();
                    Vibrate();
                    return;
                }

                else if (correctAnswerr.Length <= 0)
                {
                    Snackbar snackbar1 = Snackbar.Make(nestedScrollView1, "Please enter text", Snackbar.LengthShort);
                    View snackbarView1 = snackbar1.View;
                    snackbarView1.SetBackgroundColor(Color.Red);
                    snackbar1.Show();
                    Vibrate();
                    return;
                }

                else if (mucc.Length <= 0)
                {
                    Snackbar snackbar1 = Snackbar.Make(nestedScrollView1, "Please enter text", Snackbar.LengthShort);
                    View snackbarView1 = snackbar1.View;
                    snackbarView1.SetBackgroundColor(Color.Red);
                    snackbar1.Show();
                    Vibrate();
                    return;
                }
             else
                {
                    IQQuestion iQQuestion = new IQQuestion()
                    {
                        Question = question.Text,
                        Image = image.Text,
                        AnswerA = answera.Text,
                        AnswerB = answerb.Text,
                        AnswerC = answerc.Text,
                        AnswerD = answerd.Text,
                        CorrectAnswer = correctAnswer.Text,
                        muc = muc.Text,

                    };
                    db.InsertQuestionIQ(iQQuestion);
                    Snackbar snackbar = Snackbar.Make(nestedScrollView1, "Add Success", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Red);
                    snackbar.Show();
                }
              
            };

            return view;
        }

        public void Vibrate()
        {
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }


        async void Process7_Click(object sender, EventArgs e)
        {
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {


                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                    CompressionQuality = 40

                });

                // Convert file to byre array, to bitmap and set it to our ImageView

                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                muc.Text = strBuilder.ToString();

            }
        }

        async void Process6_Click(object sender, EventArgs e)
        {
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {


                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                    CompressionQuality = 40

                });

                // Convert file to byre array, to bitmap and set it to our ImageView

                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                correctAnswer.Text = strBuilder.ToString();

            }
        }

        async void Process5_Click(object sender, EventArgs e)
        {
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {


                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                    CompressionQuality = 40

                });

                // Convert file to byre array, to bitmap and set it to our ImageView

                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                image.Text = strBuilder.ToString();

            }
        }

        async void Process4_Click(object sender, EventArgs e)
        {
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {


                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                    CompressionQuality = 40

                });

                // Convert file to byre array, to bitmap and set it to our ImageView

                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                answerd.Text = strBuilder.ToString();

            }
        }

        async void Process3_Click(object sender, EventArgs e)
        {
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {


                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                    CompressionQuality = 40

                });

                // Convert file to byre array, to bitmap and set it to our ImageView

                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                answerc.Text = strBuilder.ToString();

            }
        }

        async void Process2_Click(object sender, EventArgs e)
        {

            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {


                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                    CompressionQuality = 40

                });

                // Convert file to byre array, to bitmap and set it to our ImageView

                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                answerb.Text = strBuilder.ToString();

            }


        }

        async void Process1_Click(object sender, EventArgs e)
        {

            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {


                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                    CompressionQuality = 40

                });

                // Convert file to byre array, to bitmap and set it to our ImageView

                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                answera.Text = strBuilder.ToString();

            }


        }

        private void Camera7_Click(object sender, EventArgs e)
        {
            TakePhoto7();
        }

        private void Camera6_Click(object sender, EventArgs e)
        {
            TakePhoto6();
        }

        private void Camera5_Click(object sender, EventArgs e)
        {
            TakePhoto5();
        }

        private void Camera4_Click(object sender, EventArgs e)
        {
            TakePhoto4();
        }

        private void Camera3_Click(object sender, EventArgs e)
        {
            TakePhoto3();
        }

        private void Camera2_Click(object sender, EventArgs e)
        {
            TakePhoto2();
        }

        private void Camera1_Click(object sender, EventArgs e)
        {
            TakePhoto1();
        }

        async void BtnProcess_Click(object sender, System.EventArgs e)
        {
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {


                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                    CompressionQuality = 40

                });

                // Convert file to byre array, to bitmap and set it to our ImageView

                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                question.Text = strBuilder.ToString();

            }
        }

        private void UploadButton_Click(object sender, System.EventArgs e)
        {
            UploadPhoto();
        }

        private void CaptureButton_Click(object sender, System.EventArgs e)
        {
            TakePhoto();
        }

        async void TakePhoto()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                question.Text = strBuilder.ToString();

            }
          

        }


        async void TakePhoto1()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                answera.Text = strBuilder.ToString();

            }


        }


        async void TakePhoto2()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                answerb.Text = strBuilder.ToString();

            }


        }
        async void TakePhoto3()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                answerc.Text = strBuilder.ToString();

            }


        }

        async void TakePhoto4()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                answerd.Text = strBuilder.ToString();

            }


        }

        async void TakePhoto5()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                image.Text = strBuilder.ToString();

            }


        }

        async void TakePhoto6()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                correctAnswer.Text = strBuilder.ToString();

            }


        }
        async void TakePhoto7()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(Context).Build();
            if (!txtRecognizer.IsOperational)
            {
                Log.Error("Error", "Detector dependencies are not yet available");
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    CompressionQuality = 40,
                    Name = "myimage.jpg",
                    Directory = "sample"

                });

                if (file == null)
                {
                    return;
                }

                // Convert file to byte array and set the resulting bitmap to imageview
                byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
                thisImageView.SetImageBitmap(bitmap);


                Frame frame = new Frame.Builder().SetBitmap(bitmap).Build();
                SparseArray items = txtRecognizer.Detect(frame);



                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                muc.Text = strBuilder.ToString();

            }


        }










        async void UploadPhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                Toast.MakeText(Context, "Upload not supported on this device", ToastLength.Short).Show();
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                CompressionQuality = 40

            });

            // Convert file to byre array, to bitmap and set it to our ImageView

            byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
            Bitmap bitmap = BitmapFactory.DecodeByteArray(imageArray, 0, imageArray.Length);
            thisImageView.SetImageBitmap(bitmap);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {

            switch (requestCode)
            {
                case RequestCameraPermissionID:
                    {
                        if (grantResults[0] == Permission.Granted)
                        {
                            cameraSource.Start(cameraView.Holder);
                        }
                    }
                    break;
            }
         //  Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }


    }

}