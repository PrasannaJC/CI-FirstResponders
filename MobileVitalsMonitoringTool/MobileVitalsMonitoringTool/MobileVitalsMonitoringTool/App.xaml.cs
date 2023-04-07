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

            //var secretsConfig = new ConfigurationBuilder().AddUserSecrets<App>().Build();

            //DataServiceConfiguration dataServiceConfiguration = new DataServiceConfiguration();
            //dataServiceConfiguration.ConnectionString = secretsConfig["ConnectionString"];

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

            //MainPage = new AppShell();
            //MainPage = new Views.LoginPage();
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

