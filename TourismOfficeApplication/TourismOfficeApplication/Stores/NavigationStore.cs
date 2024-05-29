using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Models.DataAccess;
using TourismOfficeApplication.ViewModels;

namespace TourismOfficeApplication.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        public event Action ModelChanged;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnModelChanged();
            }
        }
        public NavigationStore(DataAccess dataAccess) 
        {
            CurrentViewModel = new ClientListViewModel(dataAccess,this);
        }
        private void OnModelChanged()
        {
            ModelChanged?.Invoke();
        }
    }
}
