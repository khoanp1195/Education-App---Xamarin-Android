using Android.App;
using Android.Content;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Java.Security;
using Javax.Crypto;
using Android.Hardware.Fingerprints;
using Android.Support.V4.App;
using Android;
using System;
using Android.Security.Keystore;
using Android.Views;
using Project1.EventListener;

namespace Project1.Fragment
{
    [Obsolete]
    public class dialog_finger : Android.App.DialogFragment
    {
        private KeyStore keyStore;
        private Cipher cipher;
        private string KEY_NAME = "Ahsan";
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.finger, container, false);
            //Init Firebase

            KeyguardManager keyguardManager = (KeyguardManager)Context.GetSystemService(Context.KeyguardService);
            FingerprintManager fingerprintManager = (FingerprintManager)Context.GetSystemService(Context.FingerprintService);
            if (ActivityCompat.CheckSelfPermission(Context, Manifest.Permission.UseFingerprint)
                != (int)Android.Content.PM.Permission.Granted)
                return view;
            if (!fingerprintManager.IsHardwareDetected)
                Toast.MakeText(Context, "FingerPrint authentication permission not enable", ToastLength.Short).Show();
            else
            {
                if (!fingerprintManager.HasEnrolledFingerprints)
                    Toast.MakeText(Context, "Register at least one fingerprint in Settings", ToastLength.Short).Show();
                else
                {
                    if (!keyguardManager.IsKeyguardSecure)
                        Toast.MakeText(Context, "Lock screen security not enable in Settings", ToastLength.Short).Show();
                    else
                        GenKey();
                    if (CipherInit())
                    {
                        FingerprintManager.CryptoObject cryptoObject = new FingerprintManager.CryptoObject(cipher);
                        FingerprintHandler handler = new FingerprintHandler(Context);
                        handler.StartAuthentication(fingerprintManager, cryptoObject);
                    }
                }
            }


            return view;
        }
        private bool CipherInit()
        {
            try
            {
                cipher = Cipher.GetInstance(KeyProperties.KeyAlgorithmAes
                    + "/"
                    + KeyProperties.BlockModeCbc
                    + "/"
                    + KeyProperties.EncryptionPaddingPkcs7);
                keyStore.Load(null);
                IKey key = (IKey)keyStore.GetKey(KEY_NAME, null);
                cipher.Init(CipherMode.EncryptMode, key);
                return true;
            }
            catch (Exception ex) { return false; }
        }
        private void GenKey()
        {
            keyStore = KeyStore.GetInstance("AndroidKeyStore");
            KeyGenerator keyGenerator = null;
            keyGenerator = KeyGenerator.GetInstance(KeyProperties.KeyAlgorithmAes, "AndroidKeyStore");
            keyStore.Load(null);
            keyGenerator.Init(new KeyGenParameterSpec.Builder(KEY_NAME, KeyStorePurpose.Encrypt | KeyStorePurpose.Decrypt)
                .SetBlockModes(KeyProperties.BlockModeCbc)
                .SetUserAuthenticationRequired(true)
                .SetEncryptionPaddings(KeyProperties
                .EncryptionPaddingPkcs7).Build());
            keyGenerator.GenerateKey();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            Dialog.Window.SetLayout(500, 500);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }

  



    }
}