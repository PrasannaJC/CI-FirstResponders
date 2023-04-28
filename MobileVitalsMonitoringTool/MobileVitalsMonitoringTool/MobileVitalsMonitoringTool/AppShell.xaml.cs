using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            Routing.RegisterRoute(nameof(AlertPage), typeof(AlertPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Task.CompletedTask;
            var vm = new LogoutViewModel();
        }


    }
}

