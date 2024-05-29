using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourismOfficeApplication.Commands;
using TourismOfficeApplication.Models;
using TourismOfficeApplication.Models.DataAccess;
using TourismOfficeApplication.Services;
using TourismOfficeApplication.Store;

namespace TourismOfficeApplication.ViewModels
{
    public class ClientListViewModel : ViewModelBase
    {
        public ICommand SearchCommand { get; set; }
        public ICommand ShowDetails { get; set; }
        public ICommand EditClientCommand { get; set; }
        public ObservableCollection<Client> Clients { 
            get => clients;
            set 
            {
                clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        private ObservableCollection<Client> clients;

        public ClientListViewModel(DataAccess dataAccess)
        {
            dataAccess.GetClients().ContinueWith((t) => Clients = 
            new ObservableCollection<Client>(t.Result));
        }
    }
}
