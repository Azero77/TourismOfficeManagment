using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Models.DataAccess;
using TourismOfficeApplication.Services;
using TourismOfficeApplication.ViewModels;

namespace TourismOfficeApplication.Commands
{
    public class InsertClientCommand : EditClientCommand
    {
        public InsertClientCommand(DataAccess sqlDataAccess,
            NavigationService<ViewModelBase> navigationCommandClientListViewModel) 
            : base(sqlDataAccess, navigationCommandClientListViewModel)
        {

            query = "INSERT INTO Clients (FirstName,LastName,Gender,IdentityPath,NationalNumber) " +
                "Values " +
                "(@firstname,@lastname,@gender,@identitypath,@nationalnumber)";

        }

        
    }
}
