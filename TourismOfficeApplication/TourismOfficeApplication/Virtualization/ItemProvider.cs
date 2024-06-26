﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Models.DataAccess;

namespace TourismOfficeApplication.Virtualization
{
    public class ItemProvider<T> : IItemsProvider<T>
    {
        public ItemProvider(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public ItemProvider(DataAccess dataAccess, string searchQuery, string propertyName) 
        {
            _dataAccess = dataAccess;
            _searchQuery = searchQuery;
            _propertyName = propertyName;
        }
        readonly DataAccess _dataAccess;
        private readonly string? _searchQuery = null;
        private readonly string? _propertyName = null;
        private int _count = -1;

        public int Count { 
            get => _count; set => _count = value; }

        public async Task<int> FetchCount()
        {
            if (Count == -1)
                await LoadCount(_searchQuery,_propertyName);
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
            if (start + count > Count)
            {
                count = Count - start;
            }
            IList<T> result = (List<T>) await _dataAccess.GetClients(_searchQuery,count,start,_propertyName ?? "FirstName");
            return result;
        }
    }
}
