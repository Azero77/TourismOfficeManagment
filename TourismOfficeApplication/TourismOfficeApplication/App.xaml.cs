using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TourismOfficeApplication.Commands;
using TourismOfficeApplication.Models;
using TourismOfficeApplication.Models.DataAccess;
using TourismOfficeApplication.Services;
using TourismOfficeApplication.Store;
using TourismOfficeApplication.ViewModels;

namespace TourismOfficeApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        string ConnectionString = 
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source= Database\TourismOfficeDatabase.accdb;" +
                "Persist Security Info=False;";
        public App()
        {
            

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            
        }

       
    }
}
