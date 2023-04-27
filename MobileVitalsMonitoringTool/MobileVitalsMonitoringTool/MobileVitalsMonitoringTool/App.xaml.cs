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
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            bool isLogin = Preferences.Get("isLogin", false);

            if (isLogin)
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new LoginPage();
            }

        }

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

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

