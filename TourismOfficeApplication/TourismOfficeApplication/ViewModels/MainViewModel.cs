using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Commands;
using TourismOfficeApplication.Stores;
namespace TourismOfficeApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public NavigationCommand<ClientViewModel> NavigationCommandClientViewModel { get; set; }

        public MainViewModel(NavigationStore navigationStore,
                            NavigationCommand<ClientViewModel> navigationCommandClientViewModel)
        {
            _navigationStore = navigationStore;
            _navigationStore.ModelChanged += OnModelChanged;

            NavigationCommandClientViewModel = navigationCommandClientViewModel;
        }

        private void OnModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
