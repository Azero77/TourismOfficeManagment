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
using TourismOfficeApplication.Stores;


namespace TourismOfficeApplication.ViewModels
{
    public class ClientListViewModel : ViewModelBase
    {
        
        public ICommand SearchCommand { get; set; }
        public ICommand ShowDetailsCommand { get; set; }
        public ICommand EditClientCommand { get; set; }
        private ObservableCollection<Client> clients = new();
        public ObservableCollection<Client> Clients { 
            get => clients;
            set 
            {
                clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        //For Checking The List is loaded to change the loading spinner
        bool isLoading = true;
        public bool IsLoading
        {
            get => isLoading;
            set 
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ClientListViewModel(DataAccess dataAccess,
                                    NavigationStore navigationStore)
        {
            /*dataAccess.GetClients().ContinueWith((t) => Clients = 
            new ObservableCollection<Client>(t.Result));*/
            LoadClients(dataAccess).ContinueWith(r => IsLoading = false);
            EditClientCommand = new NavigationCommand<ClientViewModel>(
                new NavigationService<ClientViewModel>(navigationStore,(client) => 
                new((Client) client!, dataAccess,new NavigationService<ViewModelBase>(navigationStore,
                (tmp)=> new ClientListViewModel(dataAccess,navigationStore)), EditCategory.Update)));
            ShowDetailsCommand = new ShowDetailsCommand();
            SearchCommand = new SearchCommand(this,dataAccess, Clients);

            GetPropertiesNames = typeof(Client).GetProperties()
                                                .Select(p => p.Name);
            ErrorMessageViewModel = new();
            StatusMessageViewModel = new();
        }

        private async Task LoadClients(DataAccess dataAccess) 
        {
            var clients = await dataAccess.GetClients();
            UpdateClients(clients);
        }

        private void UpdateClients(IEnumerable<Client> clients)
        {
            foreach (var client in clients)
            {
                Clients.Add(client);
            }
        }

        //method for updating collection when search is invoked

        public IEnumerable<string> GetPropertiesNames { get; set; }


        //Message Indicators Failing or Success
        public MessageViewModel ErrorMessageViewModel { get; set; }
        public string ErrorMessage
        { 
            set
            {
                ErrorMessageViewModel.Message = value;
                StatusMessageViewModel.Message = string.Empty;
            }
        }
        public MessageViewModel StatusMessageViewModel { get; set; }
        //Added setter only property to facilite and encapsulate reaching ViewModels
        public string StatusMessage 
        {
            set
            {
                StatusMessageViewModel.Message = value;
                ErrorMessageViewModel.Message = string.Empty;
            }
        }
    }
}
