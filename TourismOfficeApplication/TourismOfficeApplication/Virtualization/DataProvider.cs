using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TourismOfficeApplication.Models;
using TourismOfficeApplication.Models.DataAccess;

namespace TourismOfficeApplication.Virtualization
{
    public class DataProvider<T> : IItemsProvider<T>
    {
        private readonly DataAccess _dataAccess;
        private readonly string _tableName;
        public IEnumerable<T> Collection { get; set; } = Enumerable.Empty<T>();
        private int _count;

        /// <summary>
        /// Fetch total count of a tablename given by constructors
        /// </summary>
        /// <returns></returns>
        public DataProvider(DataAccess dataAccess,string tableName)
        {
            _dataAccess = dataAccess;
            _tableName = tableName;
            _dataAccess.RunQuery<T>(_tableName)
                .ContinueWith(
                t => Collection = t.Result);
        }

        public DataProvider(DataAccess dataAccess, string tableName, Func<T,bool> predicate)
        {
            _dataAccess = dataAccess;
            _tableName = tableName;
            _dataAccess.RunQuery<T>(_tableName, predicate)
                .ContinueWith(
                t => Collection = t.Result);
        }
        public int FetchCount()
        {
            _count = _dataAccess.GetCount(_tableName);
            return _count;
        }

        public IList<T> FetchRange(int start, int count)
        {
            var result = _dataAccess.FetchRange<T>(_tableName,start,start + count).GetAwaiter().GetResult();
            return result.ToList();
        }

        public async void ChangeCollection(Func<T, bool> predicate) 
        {
            Collection = await _dataAccess.RunQuery<T>(_tableName, predicate);
        }

    }
}
