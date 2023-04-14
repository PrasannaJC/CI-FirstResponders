using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using MobileVitalsMonitoringTool.Models;
using MobileVitalsMonitoringTool.Services;
using MonitoringSuiteLibrary.Models;
using Xamarin.Essentials;

namespace MobileVitalsMonitoringTool.ViewModels
{
    /// <summary>
    /// The base view model. This sets data that will be used in the app.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the DataStore. (Not necessary)
        /// </summary>
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;

        /// <summary>
        /// Gets or sets the IsBusy variable.
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
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

        /// <summary>
        /// Starts the location background service.
        /// </summary>
        public void StartService()
        {
            var startServiceMessage = new StartServiceMessage();
            MessagingCenter.Send(startServiceMessage, "ServiceStarted");
            Preferences.Set("LocationServiceRunning", true);
            Location = "Location Service has been started!";
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

