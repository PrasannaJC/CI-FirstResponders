using System;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;
using MobileVitalsMonitoringTool.Services;
using System.Threading.Tasks;

namespace MobileVitalsMonitoringTool.ViewModels
{
    /// <summary>
    /// A class that represent the AlertViewModel. User is navigated here when they choose to
    /// send an SOS alert, or the machine learning component decides to send an alert.
    /// </summary>
    public class AlertViewModel : BaseViewModel
	{
        private Timer _timer;
        private bool timerStarted = false;

        /// <summary>
        /// Creates a <see cref="AlertViewModel"/> and starts the countdown timer.
        /// </summary>
        public AlertViewModel()
        {
            SendAlertCommand = new Command(OnSendAlert);
            CancelAlertCommand = new Command(OnCancelAlert);

            if (Preferences.Get("hasAlert", false))
            {
                AlertMessage = "You have an active alert!";
                TotalSeconds = new TimeSpan(0, 0, 0, 0);
                SendAlertAllowed = false;
            }
            else
            {
                _timer = new Timer(TimeSpan.FromSeconds(1), CountDown);
                _timer.Start();
                timerStarted = true;
            }
        }

        /// <summary>
        /// Gets the SendAlertCommand.
        /// </summary>
        public Command SendAlertCommand { get; }

        /// <summary>
        /// Gets the CancelAlertCommand.
        /// </summary>
        public Command CancelAlertCommand { get; }

        /// <summary>
        /// Sets the alert status of a first responder to false and navigates them
        /// back to the About page.
        /// </summary>
        private async void OnCancelAlert()
        {
            if (await dataService.SetFirstResponderAlertFalseAsync(Preferences.Get("w_id", -1)))
            {
                if (timerStarted)
                {
                    _timer.Stop();
                }
                Preferences.Set("checkDistressFlag", true);
                Preferences.Set("hasAlert", false);
                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                AlertMessage = "Error: unable to cancel alert.";
            }
        }

        /// <summary>
        /// Sets the alert status of a first responder to true and stops the countdown timer.
        /// </summary>
        private async void OnSendAlert()
        {
            if (await dataService.SetFirstResponderAlertTrueAsync(Preferences.Get("w_id", -1)))
            {
                AlertMessage = "Alert Sent!";
                TotalSeconds = new TimeSpan(0, 0, 0, 0);
                _timer.Stop();
                SendAlertAllowed = false;
                Preferences.Set("hasAlert", true);
            }
            else
            {
                AlertMessage = "Error: unable to send alert.";
                TotalSeconds = new TimeSpan(0, 0, 0, 10);
            }
        }

        /// <summary>
        /// Keeps track of remaining time of the countdown timer and sets the alert status of a
        /// first responder to true if it reaches 0.
        /// </summary>
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

