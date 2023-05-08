using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using MobileVitalsMonitoringTool.Services;
using MonitoringSuiteLibrary.Models;
using Xamarin.Essentials;
using MonitoringSuiteLibrary.Services;
using Microsoft.Extensions.Options;

namespace MobileVitalsMonitoringTool.ViewModels
{
    /// <summary>
    /// The base view model. This sets data that will be used in the app.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public DataService dataService;
        private DataServiceConfiguration dataServiceConfiguration;

        /// <summary>
        /// BaseViewModel constructor that sets configuration for dataService
        /// </summary>
        public BaseViewModel()
        {
            dataServiceConfiguration = new DataServiceConfiguration();
            dataServiceConfiguration.ConnectionString = "PUT CONNECTION STRING HERE";

            dataService = new DataService(Options.Create<DataServiceConfiguration>(dataServiceConfiguration));
        }

        string title = string.Empty;

        /// <summary>
        /// Gets or sets the Title of the page.
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        FirstResponder firstResponder;

        /// <summary>
        /// Gets or sets the FirstResponder object.
        /// </summary>
        public FirstResponder FirstResponder
        {
            get { return firstResponder; }
            set { SetProperty(ref firstResponder, value); }
        }

        public int workerId;

        /// <summary>
        /// Gets or sets the worker ID of a first responder.
        /// </summary>
        public int WorkerId
        {
            get { return workerId; }
            set { SetProperty(ref workerId, value); }
        }

        string location;

        /// <summary>
        /// Gets or sets the location of a first responder.
        /// </summary>
        public string Location
        {
            get { return location; }
            set { SetProperty(ref location, value); }
        }

        string alertMessage;

        /// <summary>
        /// Gets or sets the alert message.
        /// </summary>
        public string AlertMessage
        {
            get { return alertMessage; }
            set { SetProperty(ref alertMessage, value); }
        }

        TimeSpan totalSeconds = new TimeSpan(0, 0, 0, 10);

        /// <summary>
        /// Gets or sets the alert countdown total seconds.
        /// </summary>
        public TimeSpan TotalSeconds
        {
            get { return totalSeconds; }
            set { SetProperty(ref totalSeconds, value); }
        }

        bool sendAlertAllowed = true;

        /// <summary>
        /// Gets or sets the sendAlertAllowed flag.
        /// </summary>
        public bool SendAlertAllowed
        {
            get { return sendAlertAllowed; }
            set { SetProperty(ref sendAlertAllowed, value); }
        }

        /// <summary>
        /// Starts the location background service.
        /// </summary>
        public void StartService()
        {
            var startServiceMessage = new StartServiceMessage();
            MessagingCenter.Send(startServiceMessage, "ServiceStarted");
            Preferences.Set("LocationVitalsServiceRunning", true);
            Location = "Location and Vitals Service has been started!";
        }

        /// <summary>
        /// Stops the location background service.
        /// </summary>
        public void StopService()
        {
            var stopServiceMessage = new StopServiceMessage();
            MessagingCenter.Send(stopServiceMessage, "ServiceStopped");
            Preferences.Set("LocationVitalsServiceRunning", false);
        }

        /// <summary>
        /// Sets a property value.
        /// </summary>
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Lets view know that a property has changed.
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

