using System.IO;
using System.Reflection;

using DispatchersMontioringTool.Contracts.Services;
using DispatchersMontioringTool.Core.Contracts.Services;
using DispatchersMontioringTool.Core.Services;
using DispatchersMontioringTool.Models;
using DispatchersMontioringTool.Services;
using DispatchersMontioringTool.ViewModels;

using Microsoft.Extensions.Configuration;

using Prism.Regions;

using Unity;

using Xunit;

namespace DispatchersMontioringTool.Tests.XUnit
{
    public class PagesTests
    {
        private readonly IUnityContainer _container;

        public PagesTests()
        {
            _container = new UnityContainer();
            _container.RegisterType<IRegionManager, RegionManager>();

            // Core Services
            _container.RegisterType<IFileService, FileService>();

            // App Services
            _container.RegisterType<IThemeSelectorService, ThemeSelectorService>();
            _container.RegisterType<ISystemService, SystemService>();
            _container.RegisterType<ISampleDataService, SampleDataService>();
            _container.RegisterType<IPersistAndRestoreService, PersistAndRestoreService>();
            _container.RegisterType<IApplicationInfoService, ApplicationInfoService>();

            // Configuration
            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
            var configuration = new ConfigurationBuilder()
                .SetBasePath(appLocation)
                .AddJsonFile("appsettings.json")
                .Build();
            var appConfig = configuration
                .GetSection(nameof(AppConfig))
                .Get<AppConfig>();

            // Register configurations to IoC
            _container.RegisterInstance(configuration);
            _container.RegisterInstance(appConfig);
        }

        // TODO WTS: Add tests for functionality you add to BlankViewModel.
        [Fact]
        public void TestBlankViewModelCreation()
        {
            var vm = _container.Resolve<BlankViewModel>();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to ContentGridViewModel.
        [Fact]
        public void TestContentGridViewModelCreation()
        {
            var vm = _container.Resolve<ContentGridViewModel>();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to DataGridViewModel.
        [Fact]
        public void TestDataGridViewModelCreation()
        {
            var vm = _container.Resolve<DataGridViewModel>();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to ListDetailsViewModel.
        [Fact]
        public void TestListDetailsViewModelCreation()
        {
            var vm = _container.Resolve<ListDetailsViewModel>();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to MainViewModel.
        [Fact]
        public void TestMainViewModelCreation()
        {
            var vm = _container.Resolve<MainViewModel>();
            Assert.NotNull(vm);
        }

        // TODO WTS: Add tests for functionality you add to SettingsViewModel.
        [Fact]
        public void TestSettingsViewModelCreation()
        {
            var vm = _container.Resolve<SettingsViewModel>();
            Assert.NotNull(vm);
        }
    }
}
