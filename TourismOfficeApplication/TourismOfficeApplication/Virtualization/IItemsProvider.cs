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
        /// Return The number of items in the query that we are doing virtaulization with
        /// </summary>
        /// <returns></returns>
        Task<int> FetchCount();

        /// <summary>
        /// Return a subQuery start from <paramref name="start"/> and continue to <paramref name="count"/>
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<IList<T>> FetchRange(int start, int count);
    }
}
