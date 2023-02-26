using System.ComponentModel;
using Xamarin.Forms;
using MobileVitalsMonitoringTool.ViewModels;

namespace MobileVitalsMonitoringTool.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
