using MobileVitalsMonitoringTool.Views;
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
    /// The viewmodel to log into the app.
    /// </summary>
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private int workerId;

        /// <summary>
        /// Gets or sets the worker ID of a first responder.
        /// </summary>
        public int WorkerId
        {
            get { return workerId; }
            set
            {
                workerId = value;
                PropertyChanged(this, new PropertyChangedEventArgs("WorkerId"));
            }
        }

        /// <summary>
        /// Gets or sets the SubmitCommand.
        /// </summary>
        public ICommand SubmitCommand { protected set; get; }

        /// <summary>
        /// Creates a <see cref="LoginViewModel"/>.
        /// </summary>
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        /// <summary>
        /// Checks whether the specified worker ID exists in the database and logs in user if it does. Otherwise an error message is displayed.
        /// </summary>
        public async void OnSubmit()
        {
            MobileVitalsMonitoringTool.Services.DataService dataService = new MobileVitalsMonitoringTool.Services.DataService(); // temporary

            var exists = await dataService.FirstResponderExistsAsync(workerId);

            if (!exists)
            {
                DisplayInvalidLoginPrompt();
            }
            else
            {
                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");

                Preferences.Set("isLogin", true);
                Preferences.Set("w_id", workerId);
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
        }
    }
}

