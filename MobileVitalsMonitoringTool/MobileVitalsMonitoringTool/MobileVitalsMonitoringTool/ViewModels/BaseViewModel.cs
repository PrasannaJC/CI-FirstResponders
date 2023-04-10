using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using MobileVitalsMonitoringTool.Models;
using MobileVitalsMonitoringTool.Services;
using MonitoringSuiteLibrary.Models;

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

        /// <summary>
        /// Sets a property value.
        /// </summary>
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
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

