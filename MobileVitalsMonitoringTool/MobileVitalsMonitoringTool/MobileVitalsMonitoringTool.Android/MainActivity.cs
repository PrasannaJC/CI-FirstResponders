using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content;
using MobileVitalsMonitoringTool.Services;
using Xamarin.Forms;

namespace MobileVitalsMonitoringTool.Droid
{
    /// <summary>
    /// MainActivity class
    /// </summary>
    [Activity(Label = "MobileVitalsMonitoringTool", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        Intent serviceIntent;
        private const int RequestCode = 5469;

        /// <summary>
        /// Instructions to execute when Android app created.
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            serviceIntent = new Intent(this, typeof(AndroidLocationService));
            SetServiceMethods();

            if (Build.VERSION.SdkInt >= BuildVersionCodes.M && !Android.Provider.Settings.CanDrawOverlays(this))
            {
                var intent = new Intent(Android.Provider.Settings.ActionManageOverlayPermission);
                intent.SetFlags(ActivityFlags.NewTask);
                this.StartActivity(intent);
            }

            LoadApplication(new App());
        }

        /// <summary>
        /// Manages permissions needed for the app,
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="permissions"></param>
        /// <param name="grantResults"></param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// Sets service methods.
        /// </summary>
        void SetServiceMethods()
        {
            MessagingCenter.Subscribe<StartServiceMessage>(this, "ServiceStarted", message => {
                if (!IsServiceRunning(typeof(AndroidLocationService)))
                {
                    if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
                    {
                        StartForegroundService(serviceIntent);
                    }
                    else
                    {
                        StartService(serviceIntent);
                    }
                }
            });

            MessagingCenter.Subscribe<StopServiceMessage>(this, "ServiceStopped", message => {
                if (IsServiceRunning(typeof(AndroidLocationService)))
                    StopService(serviceIntent);
            });
        }

        /// <summary>
        /// Checks if background service is running
        /// </summary>
        /// <param name="cls"></param>
        /// <returns>Whether or not the background service is running</returns>
        private bool IsServiceRunning(System.Type cls)
        {
            ActivityManager manager = (ActivityManager)GetSystemService(Context.ActivityService);
            foreach (var service in manager.GetRunningServices(int.MaxValue))
            {
                if (service.Service.ClassName.Equals(Java.Lang.Class.FromType(cls).CanonicalName))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns data corresponding to an activity
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="resultCode"></param>
        /// <param name="data"></param>
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == RequestCode)
            {
                if (Android.Provider.Settings.CanDrawOverlays(this))
                {

                }
            }

            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}
