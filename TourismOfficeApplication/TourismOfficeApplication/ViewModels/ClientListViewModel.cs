﻿using System;
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


        public ClientListViewModel(DataAccess dataAccess,
                                    NavigationStore navigationStore)
        {
            /*dataAccess.GetClients().ContinueWith((t) => Clients = 
            new ObservableCollection<Client>(t.Result));*/
            LoadClients(dataAccess);
            EditClientCommand = new NavigationCommand<ClientViewModel>(
                new NavigationService<ClientViewModel>(navigationStore,(client) => 
                new((Client) client!, dataAccess,new NavigationService<ClientListViewModel>(navigationStore,
                (tmp)=> new ClientListViewModel(dataAccess,navigationStore)), EditCategory.Update)));
            ShowDetailsCommand = new ShowDetailsCommand();
            SearchCommand = new SearchCommand(dataAccess, Clients);
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


    }
}
