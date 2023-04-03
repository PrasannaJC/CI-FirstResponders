using System.Windows.Controls;

using DispatchersMonitoringTool.ViewModels;

namespace DispatchersMonitoringTool.Views;

public partial class MainPage : Page
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
