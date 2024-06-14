using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using TourismOfficeApplication.Commands;
using TourismOfficeApplication.Models;
using TourismOfficeApplication.Models.DataAccess;
using TourismOfficeApplication.Services;

namespace TourismOfficeApplication.ViewModels
{
    public class ClientViewModel : ValidatedErrorViewModelBase
    {
        public bool IsUpdateCommand { get; }
        public ClientViewModel(Client client, 
            DataAccess dataAccess,
            NavigationService<ViewModelBase> navigationService,
            EditCategory editCategory)
        {
            ID = client.ID;
            FirstName = client.FirstName;
            LastName = client.LastName;
            Gender = client.Gender;
            NationalNumber = client.NationalNumber;
            IdentityPath = client.Identitypath;

            ErrorsChanged += ClientViewModel_ErrorsChanged;
            IsUpdateCommand = editCategory == EditCategory.Update;
            if (editCategory == EditCategory.Insert)
            {
                EditClientCommand = new InsertClientCommand(dataAccess,navigationService);
            }
            else
            {
                //edit category is Update
                EditClientCommand = new UpdateClientCommand(dataAccess,navigationService);
            }
            CancelCommand = new NavigationCommand<ViewModelBase>(navigationService);
            DeleteClientCommand = new DeleteClientCommand(dataAccess, navigationService);
        }

        

        public int ID { get; set; }

        private string? _firstName;
        public string? FirstName
        {
            get => _firstName;
            set
            {
                ClearErrors(nameof(FirstName));
                if (string.IsNullOrEmpty(value))
                    AddError(nameof(FirstName), "الاسم الأول مطلوب");
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                
            }
        }

        private string? _lastName;
        public string? LastName
        {
            get => _lastName;
            set
            {
                ClearErrors(nameof(LastName));

                if (string.IsNullOrEmpty(value))
                    AddError(nameof(LastName), "الاسم الأخير مطلوب");
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                
            }
        }

        private char? _gender;
        public char? Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }
        private string? _identityPath;
        public string? IdentityPath
        {
            get => _identityPath;
            set
            {
                _identityPath = value;
                OnPropertyChanged(nameof(IdentityPath));
            }
        }

        private decimal? _nationalNumber;
        public decimal? NationalNumber
        {
            get => _nationalNumber;
            set
            {
                ClearErrors(nameof(NationalNumber));


                if (value.ToString()!.Length != 10)
                    AddError(nameof(NationalNumber), "الرقم الوطني يجب ان يتكون من عشرة ارقام");
                    _nationalNumber = value;
                    OnPropertyChanged(nameof(NationalNumber));
                
            }
        }

        //Commands
        public ICommand EditClientCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand DeleteClientCommand { get; set; }
        
        private void ClientViewModel_ErrorsChanged(object? sender, DataErrorsChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CanConfirm));
        }
        public bool CanConfirm => !HasErrors;
        public override void Dispose()
        {
            ErrorsChanged -= ClientViewModel_ErrorsChanged;
            base.Dispose();
        }
        ~ClientViewModel()
        {

        }
    }
}
