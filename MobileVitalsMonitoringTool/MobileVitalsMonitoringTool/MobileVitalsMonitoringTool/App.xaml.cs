using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileVitalsMonitoringTool.Services;
using MobileVitalsMonitoringTool.Views;
using Microsoft.Extensions.Configuration;
using MonitoringSuiteLibrary.Models;
using Xamarin.Essentials;

namespace MobileVitalsMonitoringTool
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

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
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

