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
using MobileVitalsMonitoringTool.Views;
using MonitoringSuiteLibrary.MachineLearning;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;

namespace MobileVitalsMonitoringTool.ViewModels
{
    /// <summary>
    /// A class that represents the AboutViewModel. This is the main page of the application
    /// and only logged in users can see it.
    /// </summary>
    public class AboutViewModel : BaseViewModel
    {

        /// <summary>
        /// Creates a <see cref="AboutViewModel"/>.
        /// </summary>
        public AboutViewModel()
        {
            Title = "Home";

            SOSCommand = new Command(OnSOS);

            // get FirstResponder info
            OnNavigatedTo();

            // subscribe to messaging center and start location and vitals service (only set for Android)
            if (Device.RuntimePlatform == Device.Android)
            {
                // get location message from GetLocationVitalsService
                MessagingCenter.Subscribe<LocationMessage>(this, "Location", message => {
                    Device.BeginInvokeOnMainThread(() => {
                        Location = $"{Environment.NewLine}{message.Latitude}, {message.Longitude}, {DateTime.Now.ToLongTimeString()}";

                        Console.WriteLine($"{message.Latitude}, {message.Longitude}, {DateTime.Now.ToLongTimeString()}");

                        UpdateDBLocation((decimal)message.Longitude, (decimal)message.Latitude, 0); //Altitude is always 0
                    });
                });

                // get Vitals message GetLocationVitalsService
                MessagingCenter.Subscribe<VitalsMessage>(this, "Vitals", message => {
                    Device.BeginInvokeOnMainThread(() => {

                        UpdateDBVitals(message.Vitals);

                        // checkDistressFlag prevents multiple alert pages to open
                        if (Preferences.Get("checkDistressFlag", true) && CheckDistressONNX.GetDistressStatus(FirstResponder.Age, FirstResponder.Sex, message.Vitals))
                        {
                            OnSOS();
                        }
                    });
                });

                // get message when service has been stopped
                MessagingCenter.Subscribe<StopServiceMessage>(this, "ServiceStopped", message => {
                    Device.BeginInvokeOnMainThread(() => {
                        Location = "Location Service has been stopped!";
                    });
                });

                // get message when there is an error getting the location or vitals
                MessagingCenter.Subscribe<ErrorMessage>(this, "LocationVitalsError", message => {
                    Device.BeginInvokeOnMainThread(() => {
                        Location = "There was an error updating location and/or vitals!";
                    });
                });

                if (Preferences.Get("LocationVitalsServiceRunning", false) == true && Preferences.Get("isLogin", false) == true)
                {
                    StartService();
                }
            }

        }

        /// <summary>
        /// Gets the SOSCommand.
        /// </summary>
        public Command SOSCommand { get; }

        /// <summary>
        /// Navigates user to AlertPage.
        /// </summary>
        private async void OnSOS()
        {
            Preferences.Set("checkDistressFlag", false);
            await Shell.Current.GoToAsync(nameof(AlertPage));
        }

        /// <summary>
        /// Pulls first responder information from the database.
        /// </summary>
        public async void OnNavigatedTo()
        {
            FirstResponder = await dataService.GetFirstResponderAsync(Preferences.Get("w_id", -1));
        }

        /// <summary>
        /// Updates the location entry of the first responder in the database.
        /// </summary>
        public async void UpdateDBLocation(decimal x, decimal y, decimal z)
        {
            MonitoringSuiteLibrary.Models.Location location = new MonitoringSuiteLibrary.Models.Location(x, y, z);

            if (await dataService.GetFirstResponderLocationAsync(Preferences.Get("w_id", -1)) == null)
            {
                await dataService.CreateFirstResponderLocationAsync(Preferences.Get("w_id", -1), location);
            }
            else
            {
                await dataService.UpdateFirstResponderLocationAsync(Preferences.Get("w_id", -1), location);
            }

            //update FirstResponder object with new location entry
            FirstResponder.Location = await dataService.GetFirstResponderLocationAsync(Preferences.Get("w_id", -1));
        }

        /// <summary>
        /// Updates the vitals entry of the first responder in the database.
        /// </summary>
        public async void UpdateDBVitals(Vitals vitals)
        {
            if (await dataService.GetFirstResponderVitalsAsync(Preferences.Get("w_id", -1)) == null)
            {
                await dataService.CreateFirstResponderVitalsAsync(Preferences.Get("w_id", -1), vitals);
            }
            else
            {
                await dataService.UpdateFirstResponderVitalsAsync(Preferences.Get("w_id", -1), vitals);
            }

            //update FirstResponder object with new vitals entry
            FirstResponder.Vitals = await dataService.GetFirstResponderVitalsAsync(Preferences.Get("w_id", -1));
        }
    }
}
