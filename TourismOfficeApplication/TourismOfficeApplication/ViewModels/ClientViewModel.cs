using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismOfficeApplication.Models;

namespace TourismOfficeApplication.ViewModels
{
    public class ClientViewModel : ViewModelBase
    {
        public ClientViewModel(Client client)
        {
            ID = client.ID;
            FirstName = client.FirstName;
            LastName = client.LastName;
            Gender = client.Gender;
            NationalNumber = client.NationalNumber;
            IdentityPath = client.Identitypath;
        }

        public int ID { get; set; }

        private string? _firstName;
        public string? FirstName
        {
            get => _firstName;
            set
            {
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

        private long? _nationalNumber;
        public long? NationalNumber
        {
            get => _nationalNumber;
            set
            {
                _nationalNumber = value;
                OnPropertyChanged(nameof(NationalNumber));
            }
        }
    }
}
