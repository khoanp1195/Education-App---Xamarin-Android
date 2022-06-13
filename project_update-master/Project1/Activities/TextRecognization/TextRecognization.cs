using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Gms.Vision;
using Android.Graphics;
using Android.Runtime;
using static Android.Gms.Vision.Detector;
using Android.Util;
using Android.Gms.Vision.Texts;
using Android;
using Android.Support.V4.App;
using System.Text;
using Android.Content.PM;
using Plugin.Media;

namespace Project1
{
    [Activity(Label = "TextRecognitionbyCamera", MainLauncher = false, Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class TextRecognization : AppCompatActivity
    {
        private SurfaceView cameraView;
        private TextView txtView, txtView1, txtView2, txtView3, txtView4;
        private ImageView imageview;
        private Button btnProcess;
        private CameraSource cameraSource;
        private const int RequestCameraPermissionID = 1001;
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
        }



        Button captureButton;
        Button uploadButton;
        ImageView thisImageView;


        readonly string[] permissionGroup =
        {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera
        };



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.cameraText);
            cameraView = FindViewById<SurfaceView>(Resource.Id.surface_view);
            txtView = FindViewById<TextView>(Resource.Id.txtView);
            txtView1 = FindViewById<TextView>(Resource.Id.txtView1);
            txtView2= FindViewById<TextView>(Resource.Id.txtView2);
            txtView3 = FindViewById<TextView>(Resource.Id.txtView3);
            txtView4 = FindViewById<TextView>(Resource.Id.txtView4);

            imageview = FindViewById<ImageView>(Resource.Id.thisImageView);
            btnProcess = FindViewById<Button>(Resource.Id.btnProcess);
            //  Bitmap bitmap = BitmapFactory.DecodeResource(ApplicationContext.Resources, (int)thisImageView);





            //     imageview.SetImageBitmap(bitmap);

            //TextRecognizer txtRecognizer = new TextRecognizer.Builder(ApplicationContext).Build();
            //if (!txtRecognizer.IsOperational)
            //{
            //    Log.Error("Main Activity", "Detector dependencies are not yet available");
            //}
            //else
            //{
            //    cameraSource = new CameraSource.Builder(ApplicationContext, txtRecognizer)
            //        .SetFacing(CameraFacing.Back)
            //        .SetRequestedPreviewSize(1280, 1024)
            //        .SetRequestedFps(2.0f)
            //        .SetAutoFocusEnabled(true)
            //        .Build();

            //    cameraView.Holder.AddCallback(this);
            //    txtRecognizer.SetProcessor(this);
            //}

            btnProcess.Click += BtnProcess_Click;
          

            captureButton = (Button)FindViewById(Resource.Id.captureButton);
            uploadButton = (Button)FindViewById(Resource.Id.uploadButton);
            thisImageView = (ImageView)FindViewById(Resource.Id.thisImageView);

            captureButton.Click += CaptureButton_Click;
            uploadButton.Click += UploadButton_Click;
            RequestPermissions(permissionGroup, 0);

        }

        async void BtnProcess_Click(object sender, System.EventArgs e)
        {
            TextRecognizer txtRecognizer = new TextRecognizer.Builder(ApplicationContext).Build();
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
                //for (int i = 0; i < items.Size(); i++)
                //{
                    TextBlock item = (TextBlock)items.ValueAt(0);
                    strBuilder.Append(item.Value);
                    strBuilder.Append("\n");
                
                txtView.Text = strBuilder.ToString();
          
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

        }

        async void UploadPhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                Toast.MakeText(this, "Upload not supported on this device", ToastLength.Short).Show();
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

        //public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
        //{
            
        //}

        //public void SurfaceCreated(ISurfaceHolder holder)
        //{

        //    if (ActivityCompat.CheckSelfPermission(ApplicationContext, Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
        //    {
        //        //Request permission
        //        ActivityCompat.RequestPermissions(this, new string[] {
        //            Android.Manifest.Permission.Camera
        //        }, RequestCameraPermissionID);
        //        return;
        //    }

        //    cameraSource.Start(cameraView.Holder);
        //}

        //public void SurfaceDestroyed(ISurfaceHolder holder)
        //{
        //    cameraSource.Stop();
        //}

        //public void ReceiveDetections(Detections detections)
        //{
        //    SparseArray items = detections.DetectedItems;
        //    if (items.Size() != 0)
        //    {
        //        txtView.Post(() => {
        //            StringBuilder strBuilder = new StringBuilder();
        //            for (int i = 0; i < items.Size(); ++i)
        //            {
        //                strBuilder.Append(((TextBlock)items.ValueAt(i)).Value);
        //                strBuilder.Append("\n");
        //            }
        //            txtView.Text = strBuilder.ToString();
        //        });
        //    }
        //}

        //public void Release()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}

