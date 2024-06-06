using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TourismOfficeApplication.Virtualization
{
    public class AsyncVirtualizationCollection<T> : VirtualizationCollection<T>, INotifyCollectionChanged,INotifyPropertyChanged
    {
        #region Constructors
        public AsyncVirtualizationCollection(IItemsProvider<T> itemsProvider) : base(itemsProvider)
        {
            _synchronizationContext = SynchronizationContext.Current;
        }

        public AsyncVirtualizationCollection(IItemsProvider<T> itemsProvider, int pageSize) : base(itemsProvider, pageSize)
        {
            _synchronizationContext = SynchronizationContext.Current;

        }

        public AsyncVirtualizationCollection(IItemsProvider<T> itemsProvider, int pageSize, int pageTimeOut) : base(itemsProvider, pageSize, pageTimeOut)
        {
            _synchronizationContext = SynchronizationContext.Current;

        }

        #endregion
        #region SyncroniztionContext
        private readonly SynchronizationContext? _synchronizationContext;

        protected SynchronizationContext SynchronizationContext { get => _synchronizationContext; }
        #endregion
        #region IsLoading
        bool _isLoading;
        public bool IsLoading 
        {
            get => _isLoading;
            set
            {
                if (value != _isLoading)
                {
                    _isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }
        }
        #endregion
        #region Events&EventsHandlers
        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        private void OnCollectionChanged(NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs) 
        {
            CollectionChanged?.Invoke(this, notifyCollectionChangedEventArgs);
        }

        private void FireCollectionReset() 
        {
            NotifyCollectionChangedEventArgs e = new(NotifyCollectionChangedAction.Reset);
            OnCollectionChanged(e);
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region overriding LoadCount
        protected override void LoadCount()
        {
            IsLoading = true;
            ThreadPool.QueueUserWorkItem(LoadCountWork);
        }

        private void LoadCountWork(object? args)
        {
            int count = FetchCount();
            _synchronizationContext?.Send(LoadCountCompeleted, count);
        }

        private void LoadCountCompeleted(object? args)
        {
            Count = (int)args!;
            IsLoading = false;
            FireCollectionReset();
        }
        #endregion

        #region override LoadPage
        protected override void LoadPage(int pageIndex)
        {
            IsLoading = true;
            ThreadPool.QueueUserWorkItem(LoadPageWork,pageIndex);
        }

        private void LoadPageWork(object? args)
        {
            int pageIndex = (int)args;
            IList<T> page = FetchPage(pageIndex);
            _synchronizationContext?.Send(LoadPageCompleted,
                new object[] {pageIndex,page });
            
        }

        private void LoadPageCompleted(object? args)
        {
            int pageIndex = (int) ((object[]) args!)[0];
            IList<T> page = (IList<T>) ((object[]) args)[1];

            PopulatePage(pageIndex, page);
            IsLoading = false;
            FireCollectionReset();

        }
        #endregion
    }
}
