using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

using MonitoringSuiteLibrary.Services;
using MonitoringSuiteLibrary.Models;
using System.Collections.ObjectModel;
using MobileVitalsMonitoringTool.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MobileVitalsMonitoringTool.ViewModels
{
    /// <summary>
    /// The viewmodel that represents that main page of app. Only logged in users can access it.
    /// </summary>
    public class AboutViewModel : BaseViewModel
    {
        //private readonly DataService _dataService;

        /// <summary>
        /// Creates a <see cref="AboutViewModel"/>.
        /// </summary>
        public AboutViewModel()
        {
            Title = "About";

            SOSCommand = new Command(OnSOS);

            OnNavigatedTo();

            // subscribe to messaging center and start location service
            if (Device.RuntimePlatform == Device.Android)
            {
                MessagingCenter.Subscribe<LocationMessage>(this, "Location", message => {
                    Device.BeginInvokeOnMainThread(() => {
                        Location = $"{Environment.NewLine}{message.Latitude}, {message.Longitude}, {DateTime.Now.ToLongTimeString()}";

                        Console.WriteLine($"{message.Latitude}, {message.Longitude}, {DateTime.Now.ToLongTimeString()}");

                        UpdateDBLocation((decimal)message.Longitude, (decimal)message.Latitude, 0); //Altitude is always 0
                    });
                });

                MessagingCenter.Subscribe<StopServiceMessage>(this, "ServiceStopped", message => {
                    Device.BeginInvokeOnMainThread(() => {
                        Location = "Location Service has been stopped!";
                    });
                });

                MessagingCenter.Subscribe<LocationErrorMessage>(this, "LocationError", message => {
                    Device.BeginInvokeOnMainThread(() => {
                        Location = "There was an error updating location!";
                    });
                });

                if (Preferences.Get("LocationServiceRunning", false) == true && Preferences.Get("isLogin", false) == true)
                {
                    StartService();
                }
            }

        }

        /// <summary>
        /// Gets the SOSCommand to selt the alert status to true of a first responder.
        /// </summary>
        public Command SOSCommand { get; }

        /// <summary>
        /// Sets the alert status of a first responder to true in the database.
        /// </summary>
        private async void OnSOS()
        {
            await dataService.SetFirstResponderAlertTrueAsync(Preferences.Get("w_id", -1));
        }

        /// <summary>
        /// Pulls first responder information from the database.
        /// </summary>
        public async void OnNavigatedTo()
        {
            FirstResponder = await dataService.GetFirstResponderAsync(Preferences.Get("w_id", -1));
        }

        /// <summary>
        /// Updates the location entry of the first responder.
        /// </summary>
        public async void UpdateDBLocation(decimal x, decimal y, decimal z)
        {
            await dataService.UpdateFirstResponderLocationAsync(Preferences.Get("w_id", -1), x, y, z);
        }
    }
}
