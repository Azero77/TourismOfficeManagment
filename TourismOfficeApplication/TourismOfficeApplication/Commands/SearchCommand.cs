using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Extensions;
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
        public override void Execute(object? parameter)
        {
            object[]? values = (object[]?)parameter;
            string? SearchQuery = values?[0] as string;
            string? propertyName = values?[1] as string;
            IEnumerable<Client> result;
            try
            {
                Func<Client, bool> predicate = (client) =>
                {
                    PropertyInfo? property = typeof(Client).GetProperty(propertyName);
                    if (property!.PropertyType == typeof(string))
                    {
                        return property.GetValue(client)!.ToString().StartsWith(SearchQuery);
                    }
                    //it will be a number
                    decimal SearchValue = 0;
                    if (
                    decimal.TryParse(SearchQuery, out SearchValue)
                        )
                    {
                        return (decimal)property.GetValue(client) == SearchValue;
                    }
                    else
                    {
                        throw new InvalidDataException();
                    }

                };

                _collection?.ChangeProviderCollection(predicate);


                /*result = await _dataAccess.GetClients(SearchQuery, propertyName!);
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
