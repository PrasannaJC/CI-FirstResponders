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
            var vm = new LogoutViewModel();
            await Shell.Current.GoToAsync("//LoginPage");
        }


    }
}

