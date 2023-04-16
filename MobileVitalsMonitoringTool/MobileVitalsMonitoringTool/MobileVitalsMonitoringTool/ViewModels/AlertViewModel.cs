using System;
using System.Runtime.CompilerServices;
using MobileVitalsMonitoringTool.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using MobileVitalsMonitoringTool.Services;
using System.Threading.Tasks;
//using static System.Net.Mime.MediaTypeNames;

namespace MobileVitalsMonitoringTool.ViewModels
{
	public class AlertViewModel : BaseViewModel
	{
        private Timer _timer;

        public AlertViewModel()
        {
            Title = "Alert";

            SendAlertCommand = new Command(OnSendAlert);
            CancelAlertCommand = new Command(OnCancelAlert);

            _timer = new Timer(TimeSpan.FromSeconds(1), CountDown);
            _timer.Start();
        }

        public Command SendAlertCommand { get; }
        public Command CancelAlertCommand { get; }

        private async void OnCancelAlert()
        {
            if (await dataService.SetFirstResponderAlertFalseAsync(Preferences.Get("w_id", -1)))
            {
                _timer.Stop();
                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                AlertMessage = "Error: unable to cancel alert.";
            }


        }

        private async void OnSendAlert()
        {
            if (await dataService.SetFirstResponderAlertTrueAsync(Preferences.Get("w_id", -1)))
            {
                AlertMessage = "Alert Sent!";
                TotalSeconds = new TimeSpan(0, 0, 0, 0);
                _timer.Stop();
                SendAlertAllowed = false;
            }
            else
            {
                AlertMessage = "Error: unable to send alert.";
                TotalSeconds = new TimeSpan(0, 0, 0, 10);
            }


        }

        private void CountDown()
        {
            if (TotalSeconds.TotalSeconds == 0)

            {
                _timer.Stop();
                OnSendAlert(); // send alert when timer hits 0
            }

            else
            {
                TotalSeconds = TotalSeconds.Subtract(new TimeSpan(0, 0, 0, 1));
            }
        }
    }
}

