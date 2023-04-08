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
    public class AboutViewModel : BaseViewModel
    {
        //private readonly DataService _dataService;

        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));

            SOSCommand = new Command(OnSOS);

            OnNavigatedTo();

            GetCurrentLocation();
        }

        public ICommand OpenWebCommand { get; }

        public Command SOSCommand { get; }

        private async void OnSOS()
        {
            MobileVitalsMonitoringTool.Services.DataService dataService = new MobileVitalsMonitoringTool.Services.DataService(); //temporary

            await dataService.SetFirstResponderAlertTrueAsync(Preferences.Get("w_id", -1));
        }

        public async void OnNavigatedTo()
        {
            MobileVitalsMonitoringTool.Services.DataService dataService = new MobileVitalsMonitoringTool.Services.DataService(); //temporary
            FirstResponder = await dataService.GetFirstResponderAsync(Preferences.Get("w_id", -1));
        }

        // temporary function to test geolocation. Will be replaced with service that runs in the backgroun
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
