using System.Windows.Controls;

using DispatchersMonitoringTool.ViewModels;

namespace DispatchersMonitoringTool.Views;

public partial class SettingsPage : Page
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
