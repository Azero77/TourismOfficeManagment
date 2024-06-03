using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourismOfficeApplication.Models.DataAccess;
using TourismOfficeApplication.Services;
using TourismOfficeApplication.ViewModels;

namespace TourismOfficeApplication.Commands
{
    public abstract class EditClientCommand : CommandBase
    {
        protected DataAccess _sqlDataAccess;
        private readonly NavigationService<ClientListViewModel> _navigationService;
        protected string query = string.Empty;

        protected EditClientCommand(DataAccess sqlDataAccess,NavigationService<ClientListViewModel> navigationService)
        {
            _sqlDataAccess = sqlDataAccess;
            _navigationService = navigationService;
        }

        public override async void Execute(object? parameter)
        {
            ClientViewModel viewModel = (ClientViewModel)parameter!;
            object param = new
            {
                firstname = viewModel.FirstName,
                lastname = viewModel.LastName,
                gender = viewModel.Gender.ToString(),
                identitypath = viewModel.IdentityPath,
                nationalnumber = viewModel.NationalNumber,
                id = viewModel.ID,
            };

            int result = (int)await _sqlDataAccess.RunQuery<int>(query, param) ;
            if (result > 0)
                MessageBox.Show("Updated Successfully");
            else
                MessageBox.Show(result.ToString());
            _navigationService.Navigate(null);

        }
    }
}
