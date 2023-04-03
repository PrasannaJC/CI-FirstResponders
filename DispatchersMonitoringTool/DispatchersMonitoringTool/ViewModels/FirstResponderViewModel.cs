using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

using MonitoringSuiteLibrary.Services;
using MonitoringSuiteLibrary.Models;

using MonitoringSuiteLibrary.Contracts.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using DispatchersMonitoringTool.Contracts.ViewModels;

namespace DispatchersMonitoringTool.ViewModels
{
    /// <summary>
    /// The viewmodel that represents a <see cref="FirstResponder"/>.
    /// </summary>
    public class FirstResponderViewModel : ObservableObject, INavigationAware
    {
        #region Private Fields

        private readonly IDataService _dataService;

        #endregion

        #region Public Properties

        /// <summary>
        /// Stores the given <see cref="ObservableCollection{FirstResponder}"/>.
        /// </summary>
        public ObservableCollection<FirstResponder> FirstResponders { get; private set; } = new ObservableCollection<FirstResponder>();

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a <see cref="FirstResponderViewModel"/>.
        /// </summary>
        /// <param name="dataService">The <see cref="IDataService"/> used to supply data.</param>
        public FirstResponderViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Occurs when the viemodel is navigated to.
        /// </summary>
        /// <param name="navigationContext">The <see cref="NavigationContext"/>.</param>
        public async void OnNavigatedTo(object parameter)
        {
            FirstResponders.Clear();

            // Replace this with your actual data
            var data = await _dataService.GetFirstRespondersAsync();

            foreach (var item in data)
            {
                FirstResponders.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }

        #endregion
    }
}
