using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Models;
using TourismOfficeApplication.Models.DataAccess;

namespace TourismOfficeApplication.Commands
{
    public class SearchCommand : CommandBase
    {
        private readonly DataAccess _dataAccess;
        private ObservableCollection<Client> _observableCollection;

        public SearchCommand(DataAccess dataAccess, ObservableCollection<Client> ObservableCollection) 
        {
            _dataAccess = dataAccess;
            _observableCollection = ObservableCollection;
        }
        public override async void Execute(object? parameter)
        {
            string SearchQuery = (parameter as string)!;
            IEnumerable<Client> result = await _dataAccess.GetClients(SearchQuery);
            _observableCollection?.Clear();
            foreach (Client client in result)
            {
                _observableCollection.Add(client);
            }

        }
    }
}
