using DispatchersMontioringTool.Constants;

using MahApps.Metro.Controls;

using Prism.Regions;

namespace DispatchersMontioringTool.Views
{
    public partial class ShellWindow : MetroWindow
    {
        public ShellWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            RegionManager.SetRegionName(hamburgerMenuContentControl, Regions.Main);
            RegionManager.SetRegionManager(hamburgerMenuContentControl, regionManager);
        }
    }
}
