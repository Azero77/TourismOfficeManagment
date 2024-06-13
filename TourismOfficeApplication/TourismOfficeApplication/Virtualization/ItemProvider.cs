using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Models.DataAccess;

namespace TourismOfficeApplication.Virtualization
{
    public class ClientsProvider<T> : IItemsProvider<T>
    {
        public ClientsProvider(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        readonly DataAccess _dataAccess;
        private int _count = -1;

        public int Count { 
            get => _count; set => _count = value; }

        public async Task<int> FetchCount()
        {
            if (Count == -1)
                await LoadCount(null,null);
            return Count;
        }

        async Task LoadCount(string? searchQuery, string? propertyName)
        {
            if (propertyName is null)
                Count = await _dataAccess.GetCountClient(searchQuery);
            else
                Count = await _dataAccess.GetCountClient(searchQuery, propertyName);            
        }

        public async Task<IList<T>> FetchRange(int start, int count)
        {
            IList<T> result = (List<T>) await _dataAccess.GetClients(null, start, start + count);
            return result;
        }
    }
}
