using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourismOfficeApplication.Commands;
using TourismOfficeApplication.Models;
using TourismOfficeApplication.Models.DataAccess;
using TourismOfficeApplication.Services;
using TourismOfficeApplication.Stores;
using TourismOfficeApplication.Virtualization;


namespace TourismOfficeApplication.ViewModels
{
    public class ClientListViewModel : ViewModelBase
    {
        #region Paging
        int _currentPage = 0;
        public int CurrentPage {
            get => _currentPage;
            set 
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }
        int _pagesCount;
        public int PagesCount 
        {
            get => _pagesCount;
            set
            {
                _pagesCount = value;
                OnPropertyChanged(nameof(PagesCount));

                MoveNextCommand.OnCanExecuteChanged();
                MovePrevoiusCommand.OnCanExecuteChanged();
            }
        }
        int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = value;
                OnPropertyChanged(nameof(PageSize));
            }
        }

        int _pageTimeout = 1000;
        public int PageTimeOut 
        {
            get => _pageTimeout;
            set 
            {
                _pageTimeout = value;
                OnPropertyChanged(nameof(PageTimeOut));
            }
        }
        public CommandBase MoveNextCommand { get; set; }
        public CommandBase MovePrevoiusCommand { get; set; }


        #endregion
        public ICommand SearchCommand { get; set; }
        public ICommand ShowDetailsCommand { get; set; }
        public ICommand EditClientCommand { get; set; }
        
        private VirtualizationCollection<Client> clients;
        public VirtualizationCollection<Client> Clients { 
            get => clients;
            set 
            {
                clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        //For Checking The List is loaded to change the loading spinner
        bool isLoading = true;
        public bool IsLoading
        {
            get => isLoading;
            set 
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ClientListViewModel(DataAccess dataAccess,
                                    NavigationStore navigationStore)
        {
            /*dataAccess.GetClients().ContinueWith((t) => Clients = 
            new ObservableCollection<Client>(t.Result));*/

            Clients = new(new ItemProvider<Client>(dataAccess), PageSize, PageTimeOut);
            Clients.PropertyChanged += Clients_PropertyChanged;
            Clients.LoadingChanged += OnLoadingChanged;
            EditClientCommand = new NavigationCommand<ClientViewModel>(
                new NavigationService<ClientViewModel>(navigationStore,(client) => 
                new((Client) client!, dataAccess,new NavigationService<ViewModelBase>(navigationStore,
                (tmp)=> new ClientListViewModel(dataAccess,navigationStore)), EditCategory.Update)));
            ShowDetailsCommand = new ShowDetailsCommand();
            SearchCommand = new SearchCommand(this,dataAccess, Clients);

            GetPropertiesNames = typeof(Client).GetProperties()
                                                .Select(p => p.Name);
            ErrorMessageViewModel = new();
            StatusMessageViewModel = new();
            MoveNextCommand = new MoveCommand<Client>(MoveState.MoveNext,CurrentPageChanged);
            MovePrevoiusCommand = new MoveCommand<Client>(MoveState.MovePrevoius,CurrentPageChanged);
            
            
        }

        private void Clients_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Count")
            {
                int qoutinet = Clients.Count % PageSize == 0 ? 0 : 1;
                PagesCount = Clients.Count / PageSize + qoutinet;
            }
        }

        private void OnLoadingChanged(bool val)
        {
            IsLoading = val;
        }
        private void CurrentPageChanged(int newPageIndex) 
        {
            CurrentPage = newPageIndex;
            MoveNextCommand.OnCanExecuteChanged();
            MovePrevoiusCommand.OnCanExecuteChanged();
        }
        

        //method for updating collection when search is invoked

        public IEnumerable<string> GetPropertiesNames { get; set; }


        //Message Indicators Failing or Success
        public MessageViewModel ErrorMessageViewModel { get; set; }
        public string ErrorMessage
        { 
            set
            {
                ErrorMessageViewModel.Message = value;
                StatusMessageViewModel.Message = string.Empty;
            }
        }
        public MessageViewModel StatusMessageViewModel { get; set; }
        //Added setter only property to facilite and encapsulate reaching ViewModels
        public string StatusMessage 
        {
            set
            {
                StatusMessageViewModel.Message = value;
                ErrorMessageViewModel.Message = string.Empty;
            }
        }
    }
}
