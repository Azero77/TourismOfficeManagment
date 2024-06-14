using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismOfficeApplication.Virtualization
{
    public class VirtualizationCollection<T> : INotifyCollectionChanged, INotifyPropertyChanged, IEnumerable<T>
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        #region Constructors
        public VirtualizationCollection(IItemsProvider<T> itemsProvider, int pageSize, int pageTimeOut)
        {
            _itemsProvider = itemsProvider;
            PageSize = pageSize;
            PageTimeOut = pageTimeOut;
            RenderPage(0).ConfigureAwait(false) ;
        }
        public VirtualizationCollection(IItemsProvider<T> itemsProvider, int pageSize)
        {
            _itemsProvider = itemsProvider;
            PageSize = pageSize;
            Initialize().ConfigureAwait(false);

        }
        private async Task Initialize()
        {
            await RenderPage(0);
        }

        #endregion
        #region fields
        #region dictionaries
        //_pages => list for each pageIndex
        //_pagesTimeOut => deleting page when navigating to another 
        Dictionary<int, IList<T>?> _pages = new();
        Dictionary<int, DateTime> _pagesTimeOut = new();

        #endregion
        #region itemProvider
        IItemsProvider<T> _itemsProvider;
        public IItemsProvider<T> ItemsProvider { set => _itemsProvider = value; }
        #region ChangeProvider
        public void ChangeProvider(IItemsProvider<T> provider)
        {
            ItemsProvider = provider;
            _pages = new();
            _pagesTimeOut = new();
            RenderPage(0).ConfigureAwait(false);
        }
        #endregion
        #endregion
        #region Collection
        IList<T> _collection = new List<T>();
        public IList<T> Collection 
        {
            get => _collection;
            set 
            {
                _collection = value;
                OnCollectionReset();
            }
        }
        #endregion
        #endregion
        #region Properties
        #region PageSize
        int _pageSize = 20;
        public int PageSize { get => _pageSize; set => _pageSize = value; }
        #endregion
        #region PageTimeOut
        int _pageTimeOut = 1000;
        public int PageTimeOut { get => _pageTimeOut; set => _pageTimeOut = value; }
        #endregion
        #region Count
        int _count;
        public int Count
            { get
                {
                    if (_count == -1)
                        LoadCount().Wait();
                    return _count;
                }
            private set { _count = value; }
        }

        private async Task LoadCount()
        {
            IsLoading = true;   
            Count = await _itemsProvider.FetchCount();
            IsLoading = false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            
            return Collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        #endregion
        #region IsLoading
        private bool _isLoading;
        public bool IsLoading 
        {
            get => _isLoading; 
            set 
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            } 
        }
        #endregion

        #region EventHandlers
        public void OnPropertyChanged(string PropertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public void OnCollectionChanged(NotifyCollectionChangedAction action)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action));
        }
        public void OnCollectionReset() 
        {
            OnCollectionChanged(NotifyCollectionChangedAction.Reset);
        }
        #endregion

        #region LoadingRenderingPages
        #region RenderPages
        public async Task RenderPage(int pageIndex) 
        {
            if (!_pages.ContainsKey(pageIndex))
            {
                _pages.Add(pageIndex,null);
                _pagesTimeOut.Add(pageIndex, DateTime.Now);
                IsLoading = true;
                await LoadPage(pageIndex);
                IsLoading = false;

                Collection = _pages[pageIndex]!;
                /*if(pageIndex != Count -1)                
                    LoadPage(pageIndex + 1);
                if(pageIndex != 0)
                    LoadPage(pageIndex - 1);*/
            }
            else
            {
                _pagesTimeOut[pageIndex] = DateTime.Now;
            }
            CleanUpPages();
        }
        #endregion
        #region LoadingCertainPage

        

        public async Task LoadPage(int pageIndex) 
        {
            PopulatePage(pageIndex, await FetchPage(pageIndex));
        }

        public async Task<IList<T>> FetchPage(int pageIndex)
        {
            IList<T> result = await _itemsProvider.FetchRange(pageIndex * PageSize, PageSize);
            return result;
        }


        public void CleanUpPages() 
        {
            foreach (int pageIndex in _pagesTimeOut.Keys)
            {
                if (
                    pageIndex != 0 &&
                    (DateTime.Now - _pagesTimeOut[pageIndex]).TotalMilliseconds
                    > PageTimeOut)
                {
                    _pages.Remove(pageIndex);
                    _pagesTimeOut.Remove(pageIndex);
                }
            }
        }

        public void PopulatePage(int pageIndex, IList<T> page) 
        {
            if(_pages.ContainsKey(pageIndex))
                _pages[pageIndex] = page;
        }
        #endregion
        #endregion

        public void Add(T item) 
        {
            _collection.Add(item);
        }
    }
}
