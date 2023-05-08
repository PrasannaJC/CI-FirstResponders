using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileVitalsMonitoringTool.Services;
using MobileVitalsMonitoringTool.Views;
using Microsoft.Extensions.Configuration;
using MonitoringSuiteLibrary.Models;
using Xamarin.Essentials;
using System.IO;
using System.Reflection;

namespace MobileVitalsMonitoringTool
{
    /// <summary>
    /// A class for the App
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Creates an <see cref="App"/>. Navigates user to LoginPage if not logged in,
        /// or to the AboutPage if already logged in.
        /// </summary>
        public App ()
        {
            InitializeComponent();

            bool isLogin = Preferences.Get("isLogin", false);
            Application.Current.MainPage = new AppShell();

            if (!isLogin)
            {
                Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }

        }

        /// <summary>
        /// Instructions to complete when App starts; copies DistressONNXModel.onnx, a file used by the machine learning component, into the mobile device.
        /// </summary>
        protected override void OnStart ()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DistressONNXModel.onnx");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("MobileVitalsMonitoringTool.Services.DistressONNXModel.onnx"))
            using (var file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                resource.CopyTo(file);
            }

        }

        /// <summary>
        /// Instructions to complete when App sleeps.
        /// </summary>
        protected override void OnSleep ()
        {
        }

        /// <summary>
        /// Instructions to complete when App resumes.
        /// </summary>
        protected override void OnResume ()
        {
        }
    }
}

