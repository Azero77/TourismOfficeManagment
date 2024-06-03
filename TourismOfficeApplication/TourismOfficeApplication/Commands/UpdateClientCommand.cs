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
    public class UpdateClientCommand : EditClientCommand
    {
        public UpdateClientCommand(DataAccess sqlDataAccess,
            NavigationService<ClientListViewModel> navigationCommandClientListViewModel)
            : base(sqlDataAccess, navigationCommandClientListViewModel)
        {
            query = "UPDATE Clients " +
                "SET FirstName = @firstname," +
                "LastName = @lastname," +
                "Gender = @gender," +
                "IdentityPath = @identitypath," +
                "NationalNumber = @nationalnumber " +
                "WHERE ID = @id";
        }

        
    }
}
