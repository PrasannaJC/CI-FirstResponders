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
            var exists = await dataService.FirstResponderExistsAsync(workerId);

            if (!exists)
            {
                DisplayInvalidLoginPrompt();
            }
            else
            {
                Preferences.Set("isLogin", true);
                Preferences.Set("w_id", workerId);
                Preferences.Set("LocationVitalsServiceRunning", true);
                Preferences.Set("checkDistressFlag", true);

                await dataService.SetFirstResponderActiveAsync(workerId);

                var permission = await Xamarin.Essentials.Permissions.RequestAsync<Xamarin.Essentials.Permissions.LocationAlways>();

                if (permission == Xamarin.Essentials.PermissionStatus.Denied)
                {
                    // TODO Let the user know they need to accept
                    return;
                }

                if (Device.RuntimePlatform == Device.Android)
                {
                    StartService(); //location service
                }

                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
        }
    }
}

