﻿using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

using DispatchersMontioringTool.Constants;
using DispatchersMontioringTool.Contracts.Services;
using DispatchersMontioringTool.Core.Contracts.Services;
using DispatchersMontioringTool.Core.Services;
using DispatchersMontioringTool.Models;
using DispatchersMontioringTool.Services;
using DispatchersMontioringTool.ViewModels;
using DispatchersMontioringTool.Views;
using MonitoringSuiteLibrary.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using MonitoringSuiteLibrary.Services;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Windows.Documents;
using System.Net.Http.Headers;

namespace DispatchersMontioringTool
{
    // For more inforation about application lifecyle events see https://docs.microsoft.com/dotnet/framework/wpf/app-development/application-management-overview
    // For docs about using Prism in WPF see https://prismlibrary.com/docs/wpf/introduction.html

    // WPF UI elements use language en-US by default.
    // If you need to support other cultures make sure you add converters and review dates and numbers in your UI to ensure everything adapts correctly.
    // Tracking issue for improving this is https://github.com/dotnet/wpf/issues/1946
    public partial class App : PrismApplication
    {
        private string[] _startUpArgs;

        public App()
        {
        }

        protected override Window CreateShell()
            => Container.Resolve<ShellWindow>();

        protected override async void OnInitialized()
        {
            var persistAndRestoreService = Container.Resolve<IPersistAndRestoreService>();
            persistAndRestoreService.RestoreData();

            var themeSelectorService = Container.Resolve<IThemeSelectorService>();
            themeSelectorService.InitializeTheme();

            base.OnInitialized();
            await Task.CompletedTask;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _startUpArgs = e.Args;
            base.OnStartup(e);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Core Services
            containerRegistry.Register<IFileService, FileService>();

            // App Services
            containerRegistry.Register<IApplicationInfoService, ApplicationInfoService>();
            containerRegistry.Register<ISystemService, SystemService>();
            containerRegistry.Register<IPersistAndRestoreService, PersistAndRestoreService>();
            containerRegistry.Register<IThemeSelectorService, ThemeSelectorService>();
            containerRegistry.Register<ISampleDataService, SampleDataService>();

            // Views
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsViewModel>(PageKeys.Settings);
            containerRegistry.RegisterForNavigation<ListDetailsPage, ListDetailsViewModel>(PageKeys.ListDetails);
            containerRegistry.RegisterForNavigation<ContentGridDetailPage, ContentGridDetailViewModel>(PageKeys.ContentGridDetail);
            containerRegistry.RegisterForNavigation<ContentGridPage, ContentGridViewModel>(PageKeys.ContentGrid);
            containerRegistry.RegisterForNavigation<DataGridPage, DataGridViewModel>(PageKeys.DataGrid);
            containerRegistry.RegisterForNavigation<BlankPage, BlankViewModel>(PageKeys.Blank);
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>(PageKeys.Main);
            containerRegistry.RegisterForNavigation<ShellWindow, ShellViewModel>();

            // Configuration
            var configuration = BuildConfiguration();
            var appConfig = configuration
                .GetSection(nameof(AppConfig))
                .Get<AppConfig>();

            var secretsConfig = new ConfigurationBuilder().AddUserSecrets<App>().Build();

            DataServiceConfiguration dataServiceConfiguration = new DataServiceConfiguration();
            dataServiceConfiguration.ConnectionString = secretsConfig["ConnectionString"];

            // Register configurations to IoC
            containerRegistry.RegisterInstance<IConfiguration>(configuration);
            containerRegistry.RegisterInstance<AppConfig>(appConfig);
            containerRegistry.RegisterInstance<DataService>(new DataService(Options.Create<DataServiceConfiguration>(dataServiceConfiguration)));
        }

        private IConfiguration BuildConfiguration()
        {
            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return new ConfigurationBuilder()
                .SetBasePath(appLocation)
                .AddJsonFile("appsettings.json")
                .AddCommandLine(_startUpArgs)
                .Build();
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            var persistAndRestoreService = Container.Resolve<IPersistAndRestoreService>();
            persistAndRestoreService.PersistData();
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/dotnet/api/system.windows.application.dispatcherunhandledexception?view=netcore-3.0
        }
    }
}
