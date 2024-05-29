using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Stores;
namespace TourismOfficeApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.ModelChanged += OnModelChanged;
        }

        private void OnModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
