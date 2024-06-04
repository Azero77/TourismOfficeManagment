using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismOfficeApplication.Virtualization
{
    public interface IItemsProvider<T>
    {
        /// <summary>
        /// Get the Total number of available items
        /// </summary>
        /// <returns></returns>
        int FetchCount();

        /// <summary>
        /// Fetch  <paramref name="count"/> number items starting from <paramref name="start"/>
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        IList<T> FetchRange(int start, int count);
    }
}
