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
    /// <summary>
    /// A class for the AppShell.
    /// </summary>
    public partial class AppShell : Xamarin.Forms.Shell
    {
        /// <summary>
        /// Creates an <see cref="AppShell"/>.
        /// </summary>
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AlertPage), typeof(AlertPage));
        }

        /// <summary>
        /// Creates a new <see cref="LogoutViewModel"/> to log user out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Task.CompletedTask;
            var vm = new LogoutViewModel();
        }


    }
}

