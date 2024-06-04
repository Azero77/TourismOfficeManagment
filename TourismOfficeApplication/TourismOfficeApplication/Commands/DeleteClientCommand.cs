using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using TourismOfficeApplication.Models;
using TourismOfficeApplication.Models.DataAccess;
using TourismOfficeApplication.Services;
using TourismOfficeApplication.ViewModels;

namespace TourismOfficeApplication.Commands
{
    public class DeleteClientCommand : CommandBase
    {
        private DataAccess _dataAccess;
        private readonly NavigationService<ViewModelBase> navigationService;

        public DeleteClientCommand(DataAccess dataAccess, NavigationService<ViewModelBase> navigationService)
        {
            _dataAccess = dataAccess;
            this.navigationService = navigationService;
        }

        public override async void Execute(object? parameter)
        {
            ClientViewModel client = (ClientViewModel)parameter!;
            string query = "DELETE FROM Clients WHERE ID = @id";
            object param = new { id = client.ID };
            await _dataAccess.RunQuery<int>(query,param);
            MessageBox.Show("Item Deleted Successfully");
            navigationService.Navigate(null);

        }
    }
}
