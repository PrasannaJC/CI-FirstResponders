using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.ComponentModel;

using DispatchersMonitoringTool.Models;

using MonitoringSuiteLibrary.Services;
using MonitoringSuiteLibrary.Models;

using MonitoringSuiteLibrary.Contracts.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using DispatchersMonitoringTool.Contracts.ViewModels;
using Syncfusion.UI.Xaml.Maps;
using Windows.ApplicationModel.Background;

namespace DispatchersMonitoringTool.ViewModels
{
    /// <summary>
    /// The viewmodel that represents a <see cref="FirstResponder"/>.
    /// </summary>
    public class FirstResponderViewModel : ObservableObject, INavigationAware
    {
        #region Private Fields

        private readonly IDataService _dataService;
        private FirstResponder _selectedFirstResponder;
        private string _centerPoint;
        private PeriodicTimer _timer;
        private double _updateInterval = 10;

        // This magic number is the coordinates for baxter arena.
        private static string _baxterArenaLocation = "41.23617672942098, -96.01298567694602";

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the given <see cref="ObservableCollection{FirstResponder}"/>.
        /// </summary>
        public ObservableCollection<FirstResponder> FirstResponders { get; private set; } = new ObservableCollection<FirstResponder>();

        /// <summary>
        /// Gets or sets the collection of MapMarkers representing first responders.
        /// </summary>
        public ObservableCollection<MapMarker> MapMarkers { get; private set; } = new ObservableCollection<MapMarker>();

        /// <summary>
        /// Gets or sets the selected first responder.
        /// </summary>
        public FirstResponder SelectedFirstResponder
        {
            get
            {
                return _selectedFirstResponder;
            }
            set
            {
                _selectedFirstResponder = value;

                if (_selectedFirstResponder != null)
                {
                    if (_selectedFirstResponder.Location != null)
                    {
                        CenterPoint = _selectedFirstResponder.Location.Value.YCoord + ", " + _selectedFirstResponder.Location.Value.XCoord;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the current center point of the map.
        /// </summary>
        public string CenterPoint 
        {
            get => _centerPoint;
            set => SetProperty(ref _centerPoint, value);
        } 

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a <see cref="FirstResponderViewModel"/>.
        /// </summary>
        /// <param name="dataService">The <see cref="IDataService"/> used to supply data.</param>
        public FirstResponderViewModel(IDataService dataService)
        {
            _dataService = dataService;

            // We center on baxter arena.
            CenterPoint = _baxterArenaLocation;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Occurs when the viewmodel is navigated to.
        /// </summary>
        /// <param name="navigationContext">The <see cref="NavigationContext"/>.</param>
        public async void OnNavigatedTo(object parameter)
        {
            // Initialize first responder lists.
            UpdateFirstResponders(await _dataService.GetActiveFirstRespondersAsync());

            _timer = new PeriodicTimer(TimeSpan.FromSeconds(_updateInterval));

            MaintainUpdatedFirstResponderData(_timer);
        }

        /// <summary>
        /// Occurs when the viewmodel is navigated from.
        /// </summary>
        public void OnNavigatedFrom()
        {
            _timer.Dispose();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Maintains updated first responder data on a timer.
        /// </summary>
        /// <param name="timer">The timer the updates are based on.</param>
        private async void MaintainUpdatedFirstResponderData(PeriodicTimer timer)
        {
            while(await timer.WaitForNextTickAsync())
            {
                UpdateFirstResponders(await _dataService.GetActiveFirstRespondersAsync());
            }
        }

        /// <summary>
        /// Builds the string that represents a <see cref="FirstResponder"/>s vitals.
        /// </summary>
        /// <param name="firstResponder"></param>
        /// <returns></returns>
        private string BuildFirstResponderVitalsString(FirstResponder firstResponder)
        {
            string result = "NAME: " + firstResponder.FName + " " + firstResponder.LName;

            if (firstResponder.Vitals != null)
            {
                return result + '\n'
                    + "Time: " + firstResponder.Vitals.Value.Timestamp + "\n"
                    + "DiaBP: " + firstResponder.Vitals.Value.DiaBP + '\n'
                    + "SysBP: " + firstResponder.Vitals.Value.SysBP + "\n"
                    + "HR: " + firstResponder.Vitals.Value.HeartRate + "\n"
                    + "RespRate: " + firstResponder.Vitals.Value.RespRate + "\n"
                    + "TempF: " + firstResponder.Vitals.Value.TempF
                    ;
            }
            else
            {
                return result + "\n"
                    + "No Vitals Available";
            }
        }

        /// <summary>
        /// Updates the list of first responders, and properties that are dependent on this list.
        /// </summary>
        /// <param name="firstResponders">An enumerable of first responders.</param>
        private void UpdateFirstResponders(IEnumerable<FirstResponder> firstResponders)
        {
            if (firstResponders == null)
            {
                return;
            }

            FirstResponders.Clear();
            MapMarkers.Clear();

            foreach (var firstResponder in firstResponders)
            {
                FirstResponders.Add(firstResponder);

                if (firstResponder.Location != null)
                {
                    MapMarkers.Add(new MapMarker(BuildFirstResponderVitalsString(firstResponder), longitude: firstResponder.Location.Value.XCoord, latitude: firstResponder.Location.Value.YCoord));
                }
            }
        }

        #endregion
    }
}
