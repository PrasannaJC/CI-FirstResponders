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

namespace DispatchersMonitoringTool.ViewModels
{
    /// <summary>
    /// The viewmodel that represents a <see cref="FirstResponder"/>.
    /// </summary>
    public class FirstResponderViewModel : ObservableObject, INavigationAware
    {
        #region Private Fields

        private readonly IDataService _dataService;
        private FirstResponder selectedFirstResponder;
        private string centerPoint;

        // This magic number is the coordinates for baxter arena.
        private static string _baxterArenaLocation = "41.23617672942098, -96.01298567694602";

        #endregion

        #region Public Properties

        /// <summary>
        /// Stores the given <see cref="ObservableCollection{FirstResponder}"/>.
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
                return selectedFirstResponder;
            }
            set
            {
                selectedFirstResponder = value;

                if (selectedFirstResponder != null)
                {
                    if (selectedFirstResponder.Location != null)
                    {
                        CenterPoint = selectedFirstResponder.Location.Value.YCoord + ", " + selectedFirstResponder.Location.Value.XCoord;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the current center point of the map.
        /// </summary>
        public string CenterPoint 
        {
            get => centerPoint;
            set => SetProperty(ref centerPoint, value);
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
        /// Occurs when the viemodel is navigated to.
        /// </summary>
        /// <param name="navigationContext">The <see cref="NavigationContext"/>.</param>
        public async void OnNavigatedTo(object parameter)
        {
            FirstResponders.Clear();
            MapMarkers.Clear();

            // Replace this with your actual data
            var data = await _dataService.GetFirstRespondersAsync();

            foreach (var item in data)
            {
                FirstResponders.Add(item);

                if (item.Location != null)
                {
                    MapMarkers.Add(new MapMarker(BuildFirstResponderVitalsString(item), longitude: item.Location.Value.XCoord, latitude: item.Location.Value.YCoord)) ;
                }
            }
        }

        public void OnNavigatedFrom()
        {
        }

        #endregion

        #region Private Methods

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

        #endregion
    }
}
