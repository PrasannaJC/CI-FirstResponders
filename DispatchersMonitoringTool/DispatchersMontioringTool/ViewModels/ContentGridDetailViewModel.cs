﻿using System;
using System.Linq;

using DispatchersMontioringTool.Core.Contracts.Services;
using DispatchersMontioringTool.Core.Models;

using Prism.Mvvm;
using Prism.Regions;

namespace DispatchersMontioringTool.ViewModels
{
    public class ContentGridDetailViewModel : BindableBase, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public ContentGridDetailViewModel(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var parameter = navigationContext.Parameters["DetailID"];
            if (parameter is long orderID)
            {
                var data = await _sampleDataService.GetContentGridDataAsync();
                Item = data.First(i => i.OrderID == orderID);
            }
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
            => true;
    }
}
