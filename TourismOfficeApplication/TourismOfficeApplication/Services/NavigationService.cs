using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Stores;
using TourismOfficeApplication.ViewModels;

namespace TourismOfficeApplication.Services
{
    public class NavigationService<TViewModel>
        where TViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        private readonly Func<object?,TViewModel> View;

        public NavigationService(NavigationStore navigationStore, Func<object?,TViewModel> view)
        {
            _navigationStore = navigationStore;
            View = view;
        }

        public void Navigate(object? parameter) 
        {
            _navigationStore.CurrentViewModel = View(parameter);
        }
    }
}
