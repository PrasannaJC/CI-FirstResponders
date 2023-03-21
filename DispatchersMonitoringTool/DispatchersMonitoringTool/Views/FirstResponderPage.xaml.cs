using System.Windows.Controls;

using DispatchersMonitoringTool.ViewModels;

namespace DispatchersMonitoringTool.Views;

public partial class FirstResponderPage : Page
{
    public FirstResponderPage(FirstResponderViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
