using System.Windows.Controls;

namespace DispatchersMonitoringTool.Contracts.Views;

public interface IShellWindow
{
    Frame GetNavigationFrame();

    void ShowWindow();

    void CloseWindow();
}
