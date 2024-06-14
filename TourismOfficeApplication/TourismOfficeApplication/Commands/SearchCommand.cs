using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Models;
using TourismOfficeApplication.Models.DataAccess;
using TourismOfficeApplication.ViewModels;
using TourismOfficeApplication.Virtualization;

namespace TourismOfficeApplication.Commands
{
    public class SearchCommand : CommandBase
    {
        private readonly ClientListViewModel _viewModel;
        private readonly DataAccess _dataAccess;
        private VirtualizationCollection<Client> _collection;

        public SearchCommand(ClientListViewModel viewModel,DataAccess dataAccess, VirtualizationCollection<Client> collection) 
        {
            _viewModel = viewModel;
            _dataAccess = dataAccess;
            _collection = collection;
        }
        public override async void Execute(object? parameter)
        {
            object[]? values = (object[]?)parameter;
            string? SearchQuery = values?[0] as string;
            string? propertyName = values?[1] as string;
            try
            {
                int prev = _collection.Count;
                IItemsProvider<Client> provider = new ItemProvider<Client>(_dataAccess,SearchQuery,propertyName);
                await _collection.ChangeProvider(provider);

                //will add some object to be transfered to get to know what the limit and offset of the user
                /*result = await _dataAccess.GetClients(SearchQuery, 10,0,propertyName!);
                foreach (Client client in result)
                {
                    _collection?.Add(client);
                }*/
                
                _viewModel.StatusMessage = "عدد النتائج:" + (_collection?.Count.ToString() ?? "0");
            }
            catch (InvalidDataException)
            {
                _viewModel.ErrorMessage = "من فضلك أدخل معلومات صحيحة";
            }
            

        }
    }
}
