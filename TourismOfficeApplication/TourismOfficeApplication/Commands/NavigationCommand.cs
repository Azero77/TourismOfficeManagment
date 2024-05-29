using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Services;
using TourismOfficeApplication.ViewModels;

namespace TourismOfficeApplication.Commands
{
    public class NavigationCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        private NavigationService<TViewModel> _navigationService;

        public NavigationCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate(parameter);
        }
    }
}
