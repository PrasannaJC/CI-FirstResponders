using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileVitalsMonitoringTool.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileVitalsMonitoringTool.Views
{
    /// <summary>
    /// A class for the LoginPage
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            vm.DisplayAlreadyLoggedInPrompt += () => DisplayAlert("Error", "This user is already logged in", "OK");
            InitializeComponent();

            WorkerId.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }
    }
}
