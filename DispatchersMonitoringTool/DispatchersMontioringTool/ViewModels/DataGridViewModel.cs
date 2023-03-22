using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using MonitoringSuiteLibrary.Services;
using MonitoringSuiteLibrary.Models;

using DispatchersMontioringTool.Core.Contracts.Services;
using DispatchersMontioringTool.Core.Models;

using Prism.Mvvm;
using Prism.Regions;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DispatchersMontioringTool.ViewModels
{
    public class DataGridViewModel : BindableBase, INavigationAware
    {
        private readonly DataService _dataService;

        public ObservableCollection<FirstResponder> FirstResponders { get; private set; } = new ObservableCollection<FirstResponder>();

        public DataGridViewModel(DataService dataService)
        {
            _dataService = dataService;
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            FirstResponders.Clear();

            // Replace this with your actual data
            var data = await _dataService.GetFirstRespondersAsync();

            foreach (var item in data)
            {
                FirstResponders.Add(item);
            }
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
            => true;
    }
}
