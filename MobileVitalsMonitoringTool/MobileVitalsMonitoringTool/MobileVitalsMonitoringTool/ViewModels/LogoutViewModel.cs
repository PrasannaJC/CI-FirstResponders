﻿using MobileVitalsMonitoringTool.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using MobileVitalsMonitoringTool.Services;
using Xamarin.Essentials;

namespace MobileVitalsMonitoringTool.ViewModels
{
    /// <summary>
    /// The viewmodel to log out of the app.
    /// </summary>
    public class LogoutViewModel : BaseViewModel
    {
        /// <summary>
        /// Creates a <see cref="LogoutViewModel"/>.
        /// </summary>
        public LogoutViewModel()
        {
            Preferences.Set("isLogin", false);
            Preferences.Set("checkDistressFlag", false);
            WorkerId = Preferences.Get("w_id", -1);

            // stop getting the location and vitals
            StopService();

            dataService.SetFirstResponderInactiveAsync(WorkerId);
            Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}

