using System;
using System.Collections.Generic;
using MobileVitalsMonitoringTool.Services;
using MobileVitalsMonitoringTool.ViewModels;
using MobileVitalsMonitoringTool.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileVitalsMonitoringTool
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Preferences.Set("isLogin", false);
            StopService();
            await Shell.Current.GoToAsync("//LoginPage");
        }

        /// <summary>
        /// Stops the location background service.
        /// </summary>
        private void StopService()
        {
            var stopServiceMessage = new StopServiceMessage();
            MessagingCenter.Send(stopServiceMessage, "ServiceStopped");
            Preferences.Set("LocationServiceRunning", false);
        }
    }
}

