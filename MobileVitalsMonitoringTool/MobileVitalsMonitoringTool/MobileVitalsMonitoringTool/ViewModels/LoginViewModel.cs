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
    public class LoginViewModel : BaseViewModel
    {
        public Action DisplayInvalidLoginPrompt;
        public Action DisplayAlreadyLoggedInPrompt;

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
            var exists = await dataService.FirstResponderExistsAsync(WorkerId);

            if (!exists)
            {
                DisplayInvalidLoginPrompt();
            }
            else if (await dataService.FirstResponderIsActiveAsync(WorkerId))
            {
                DisplayAlreadyLoggedInPrompt();
            }
            else
            {
                Preferences.Set("isLogin", true);
                Preferences.Set("w_id", WorkerId);
                Preferences.Set("LocationVitalsServiceRunning", true);
                Preferences.Set("checkDistressFlag", true);
                Preferences.Set("hasAlert", false);

                await dataService.SetFirstResponderActiveAsync(WorkerId);

                var permission = await Xamarin.Essentials.Permissions.RequestAsync<Xamarin.Essentials.Permissions.LocationAlways>();

                if (permission == Xamarin.Essentials.PermissionStatus.Denied)
                {
                    // Let the user know they need to accept
                    return;
                }

                // background service to get location and vitals is only configured for Android
                if (Device.RuntimePlatform == Device.Android)
                {
                    StartService(); //location service
                }
                
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
        }
    }
}