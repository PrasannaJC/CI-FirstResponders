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

            GetCurrentLocation();
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
            MobileVitalsMonitoringTool.Services.DataService dataService = new MobileVitalsMonitoringTool.Services.DataService(); //temporary

            await dataService.SetFirstResponderAlertTrueAsync(Preferences.Get("w_id", -1));
        }

        /// <summary>
        /// Pulls first responder information from the database.
        /// </summary>
        public async void OnNavigatedTo()
        {
            MobileVitalsMonitoringTool.Services.DataService dataService = new MobileVitalsMonitoringTool.Services.DataService(); //temporary
            FirstResponder = await dataService.GetFirstResponderAsync(Preferences.Get("w_id", -1));
        }

        /// <summary>
        /// Gets the location of the first responder and writes it out to the database. This is a temporary function which will
        /// eventually be replaced by a background service
        /// </summary>
        private async void GetCurrentLocation()
        {
            MobileVitalsMonitoringTool.Services.DataService dataService = new MobileVitalsMonitoringTool.Services.DataService(); //temporary
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                location = null;
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });

                }
                if (location != null)
                {
                    decimal x = (decimal)location.Longitude;
                    decimal y = (decimal)location.Latitude;
                    decimal z = (decimal)location.Altitude;

                    await dataService.UpdateFirstResponderLocationAsync(Preferences.Get("w_id", -1), x, y, z);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Something is wrong: {ex.Message}");
            }
        }

    }
}
