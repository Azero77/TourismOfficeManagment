using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Models.DataAccess;

namespace TourismOfficeApplication.Virtualization
{
    public class DataProvider<T> : IItemsProvider<T>
    {
        private readonly DataAccess _dataAccess;
        private int _count;
        public int Count { get => _count; set => _count = value; }


        public DataProvider(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }


        public int FetchCount()
        {
            throw new Exception();
        }

        public IList<T> FetchRange(int start, int count)
        {
            throw new NotImplementedException();
        }
    }
}
