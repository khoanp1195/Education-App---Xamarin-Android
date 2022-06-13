using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Vision;
using Android.Gms.Vision.Texts;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Plugin.Media;
using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using static Android.Hardware.Camera;
using Android.Hardware;
using Java.Lang;
using Xamarin.Essentials;
using System.IO;

namespace Project1.Activities.ScanText
{
    [Activity(Label = "ScanTextActivity")]
    public class ScanTextActivity : AppCompatActivity
    {





        private Android.Hardware.Camera camera;
        private Parameters mParams;
        private bool isFlashLight;
        private ImageView btnFlash;
        private MediaPlayer player;

        EditText edtText;
        Button btnAdd;
        ImageView thisImageView, backButton, img_copy;
        CardView processBtn, captureButton, sharefile, shareTxt;
        NestedScrollView nestedScrollView1;


        //TIMER
        TextView timer1;
        System.Timers.Timer timer;


        //Clip Board
        ClipboardManager clipBoardManager;
        ClipData clipData;


        TextView txtContent;


        private SurfaceView cameraView;
        readonly string[] permissionGroup =
   {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera
        };
        private CameraSource cameraSource;
        private const int RequestCameraPermissionID = 1001;

        List<ContentScanText> lstIqQuestion = new List<ContentScanText>();



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ScanText);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here


            img_copy = FindViewById<ImageView>(Resource.Id.img_copy);
            img_copy.Click += Img_copy_Click;

            //FindView

            btnFlash = FindViewById<ImageView>(Resource.Id.imageView);
            player = MediaPlayer.Create(this, Resource.Raw.sound_click);
            btnFlash.Click += delegate
            {
                FlashLight();
            };


            bool hasflash = ApplicationContext.PackageManager.HasSystemFeature
         (Android.Content.PM.PackageManager.FeatureCameraFlash);

            if (!hasflash)
            {
                Android.App.AlertDialog alert = new Android.App.AlertDialog.Builder(this).Create();
                alert.SetTitle("Error!");
                alert.SetMessage("Sorry, your device doesn't support flash light");
                alert.SetButton("OK", (s, e) => { return; });
                alert.Show();
            }

            getCamera();



            txtContent = (TextView)FindViewById(Resource.Id.txtContent);
            
          


            nestedScrollView1 = (NestedScrollView)FindViewById(Resource.Id.nestedScrollView1);

            edtText = (EditText)FindViewById(Resource.Id.edtText);

            DbHelper.DbHelper db = new DbHelper.DbHelper(this);
            btnAdd = (Button)FindViewById(Resource.Id.btnAdd);
            btnAdd.Click += delegate
            {
                DateTime dt = DateTime.Now;
                txtContent.Text = dt.ToString();
           
                try
                {
                    ContentScanText contentScanText = new ContentScanText()
                    {
                        Content = edtText.Text,
                        Timer = txtContent.Text,
                    };
                    db.InsertScanText(contentScanText);


                    Snackbar snackbar = Snackbar.Make(nestedScrollView1, "Add Success", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Green);
                    snackbar.Show();

                }
                catch
                {
                    Snackbar snackbar = Snackbar.Make(nestedScrollView1, "Sorry Add failed", Snackbar.LengthShort);
                    View snackbarView = snackbar.View;
                    snackbarView.SetBackgroundColor(Color.Red);
                    snackbar.Show();
                }
             
            };


            

            processBtn = (CardView)FindViewById(Resource.Id.processBtn);
            captureButton = (CardView)FindViewById(Resource.Id.captureButton);
            shareTxt = (CardView)FindViewById(Resource.Id.shareTxt);
            shareTxt.Click += ShareTxt_Click;


            sharefile = (CardView)FindViewById(Resource.Id.sharefile);
            sharefile.Click += Sharefile_Click;

            thisImageView = (ImageView)FindViewById(Resource.Id.thisImageView);
            backButton = (ImageView)FindViewById<ImageView>(Resource.Id.backButton);

            clipBoardManager = (ClipboardManager)GetSystemService(ClipboardService);

            RequestPermissions(permissionGroup, 0);

            processBtn.Click += ProcessBtn_Click;

            captureButton.Click += CaptureButton_Click;

            backButton.Click += BackButton_Click;
        }

        private void Img_copy_Click(object sender, EventArgs e)
        {
            System.String text = edtText.Text;
            clipData = ClipData.NewPlainText("text", text);
            clipBoardManager.PrimaryClip = clipData;

            Toast.MakeText(this, "Text Copied", ToastLength.Short).Show();
        }

        private async void Sharefile_Click(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest

            {
                Text = edtText.Text,
                Title = "Share"
            }

                 );
        }

        private async void ShareTxt_Click(object sender, EventArgs e)
        {
            var info = edtText.Text;
            if (string.IsNullOrWhiteSpace(info))
                return;
            var path = string.Empty;
            path = System.IO.Path.Combine(FileSystem.CacheDirectory, "ContentScanText.txt");
            File.WriteAllText(path, info);

            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Content Scan Text",
                File = new ShareFile(path)
            }
                );
        }

        private void getCamera()
        {
            if (camera == null)
            {
                try
                {
                    camera = Android.Hardware.Camera.Open();
                    mParams = camera.GetParameters();
                }
                catch (RuntimeException ex)
                {
                    Log.Info("Error", ex.Message);
                }
            }
        }

        //FlashLight Function
        private void FlashLight()
        {
            if (camera == null || mParams == null)
                return;
            if (!isFlashLight)
            {
                player.Start();
                mParams = camera.GetParameters();
                mParams.FlashMode = Parameters.FlashModeTorch;
                camera.SetParameters(mParams);
                camera.StartPreview();
                isFlashLight = true;
                btnFlash.SetImageResource(Resource.Drawable.power_on);
            }
            else
            {
                player.Start();
                mParams = camera.GetParameters();
                mParams.FlashMode = Parameters.FlashModeOff;
                camera.SetParameters(mParams);
                camera.StartPreview();
                isFlashLight = false;
                btnFlash.SetImageResource(Resource.Drawable.power_off);
            }
        }



        async void CaptureButton_Click(object sender, EventArgs e)
        {
            TakePhoto();
        }
        async void TakePhoto()
        {

            await CrossMedia.Current.Initialize();
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
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



                Java.Lang.StringBuilder strBuilder = new Java.Lang.StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                edtText.Text = strBuilder.ToString();

            }


        }

        async void ProcessBtn_Click(object sender, EventArgs e)
        {
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(this).Build();
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



                Java.Lang.StringBuilder strBuilder = new Java.Lang.StringBuilder();
                for (int i = 0; i < items.Size(); i++)
                {
                    TextBlock item = (TextBlock)items.ValueAt(i);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                }
                edtText.Text = strBuilder.ToString();
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(MainActivity2)));
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

  

        protected override void OnStart()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            base.OnStart();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            RunOnUiThread(() => { txtContent.Text = dt.ToString(); });
        }
    }
}

       
