using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismOfficeApplication.Models
{
    public class Client
    {
        public Client(
           int id,
           string firstName,
           string lastName,
           char gender,
           string identitypath,
           decimal nationalNumber)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Identitypath = identitypath;
            NationalNumber = nationalNumber;
        }
        public Client()
        {

        }

        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public char? Gender { get; set; }
        public string? Identitypath { get; set; }
        public decimal? NationalNumber { get; set; }
    }
}
