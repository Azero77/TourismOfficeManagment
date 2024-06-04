using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismOfficeApplication.Virtualization
{
    public class VirtualizationCollection<T> : IList<T>, IList
    {

        #region Constructors
        public VirtualizationCollection(IItemsProvider<T> itemsProvider)
        {
            _itemsProvider = itemsProvider;
        }
        public VirtualizationCollection(IItemsProvider<T> itemsProvider, int pageSize, int pageTimeOut)
        {
            _itemsProvider = itemsProvider;
            _pageSize = pageSize;
            _pageTimeOut = pageTimeOut;
        }

        public VirtualizationCollection(IItemsProvider<T> itemsProvider, int pageSize)
        {
            _itemsProvider = itemsProvider;
            _pageSize = pageSize;
        }
        #endregion
        #region ItemsProvider        
        IItemsProvider<T> _itemsProvider;
        public IItemsProvider<T> ItemsProvider => _itemsProvider;
        #endregion
        #region PageSize
        int _pageSize;
        public int PageSize => _pageSize;
        #endregion

        #region PageTimeOut
        int _pageTimeOut;
        public int PageTimeOut => _pageTimeOut;
        #endregion
        #region Count
        private int _count = -1;
        public virtual int Count 
        {
            get 
            {
                if (_count == -1)
                    LoadCount();
                return _count;
            }
            protected set 
            {
                _count = value;
            }
        }

        protected virtual void LoadCount() 
        {
            Count = FetchCount();
        }

        protected int FetchCount()
        {
            return _itemsProvider.FetchCount();
        }
        #endregion
        #region Indexer
        public T this[int index]
        { get 
            {
                int pageIndex = Count / index;
                int pageOffset = Count % index;

                if (pageOffset < PageSize / 2 && pageIndex != 0)
                    RequestPage(pageIndex - 1);
                if (pageIndex > PageSize / 2 && pageIndex != Count / PageSize)
                    RequestPage(pageIndex + 1);

                CleanUpPages();
                if (_pages[pageIndex] == null)
                    return default;
                return _pages[pageIndex][pageOffset];
            } 
        set => throw new NotImplementedException();
        }
        object IList.this[int index]
        {
            get => this[index];
            set { throw new NotImplementedException(); }
        }

        #endregion

        #region RenderPages
        private readonly Dictionary<int, IList<T>> _pages = new();
        private readonly Dictionary<int, DateTime> _pageTouchTimes = new();

        
        protected virtual void RequestPage(int pageIndex)
        {
            if (!_pages.ContainsKey(pageIndex))
            {
                _pages.Add(pageIndex, null);
                _pageTouchTimes.Add(pageIndex, DateTime.Now);
                LoadPage(pageIndex);
            }
            else
            {
                _pageTouchTimes[pageIndex] = DateTime.Now;
            }
        }

        protected virtual void LoadPage(int pageIndex) 
        {
            PopulatePage(pageIndex, FetchPage(pageIndex));
        }

        protected IList<T> FetchPage(int pageIndex)
        {
            return _itemsProvider.FetchRange(pageIndex * _pageSize, _pageSize);
        }

        protected virtual void PopulatePage(int pageIndex, IList<T> page) 
        {
            if (_pages.ContainsKey(pageIndex))
                _pages[pageIndex] = page;
        }
        #endregion

        public void CleanUpPages()
        {
            List<int> Keys = new List<int>(_pages.Keys);

            foreach (int Key in Keys)
            {
                if (Key != 0
                    &&
                        (DateTime.Now - _pageTouchTimes[Key]).TotalMilliseconds > _pageTimeOut
                    )
                {
                    _pages.Remove(Key);
                    _pageTouchTimes.Remove(Key);
                }
            }
        }
        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsFixedSize => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public int Add(object? value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object? value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object? value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object? value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object? value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

    }
}
