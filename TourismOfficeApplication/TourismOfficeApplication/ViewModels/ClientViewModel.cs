using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Models;

namespace TourismOfficeApplication.ViewModels
{
    public class ClientViewModel : ValidatedErrorViewModelBase
    {

        public ClientViewModel(Client client)
        {
            ID = client.ID;
            FirstName = client.FirstName;
            LastName = client.LastName;
            Gender = client.Gender;
            NationalNumber = client.NationalNumber;
            IdentityPath = client.Identitypath;

            ErrorsChanged += ClientViewModel_ErrorsChanged;
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
                else
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
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
                else
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
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

        private long? _nationalNumber;
        public long? NationalNumber
        {
            get => _nationalNumber;
            set
            {
                ClearErrors(nameof(NationalNumber));

                bool is_valid = false;
                if (value.ToString().Length != 10)
                    AddError(nameof(NationalNumber), "الرقم الوطني يجب ان يتكون من عشرة ارقام");
                else
                    is_valid = true;
                if (is_valid)
                {
                    _nationalNumber = value;
                    OnPropertyChanged(nameof(NationalNumber));
                }
            }
        }
        
        private void ClientViewModel_ErrorsChanged(object? sender, DataErrorsChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CanConfirm));
        }
        public bool CanConfirm => !HasErrors;

    }
}
