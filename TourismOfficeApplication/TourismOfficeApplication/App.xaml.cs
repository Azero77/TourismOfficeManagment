using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TourismOfficeApplication.Commands;
using TourismOfficeApplication.Models;
using TourismOfficeApplication.Models.DataAccess;
using TourismOfficeApplication.Services;
using TourismOfficeApplication.Stores;
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
                @"Data Source= Database\Mock.accdb;" +
                "Persist Security Info=False;";
        IServiceProvider serviceProvider;
        public App()
        {
            IServiceCollection _collection = new ServiceCollection();
            ConfigureServices(_collection);
            serviceProvider = _collection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
        }

        private void ConfigureServices(IServiceCollection collection) 
        {
            collection.AddScoped<NavigationStore>();
            collection.AddScoped<MainViewModel>();
            collection.AddScoped<MainWindow>(
                (sp) => new() { DataContext = sp.GetRequiredService<MainViewModel>()});
            collection.AddScoped<DataAccess>(sp => new(ConnectionString));

            collection.AddScoped<NavigationCommand<ClientViewModel>>();
            collection.AddScoped<NavigationService<ClientViewModel>>(
                sp => new(
                    sp.GetRequiredService<NavigationStore>(),
                    (tmp) => new ClientViewModel
                                (new Client(),
                                  sp.GetRequiredService<DataAccess>(),
                                  sp.GetRequiredService<NavigationService<ViewModelBase>>(),
                                  EditCategory.Insert
                    )));
            collection.AddTransient<ViewModelBase>();
            collection.AddScoped<NavigationService<ViewModelBase>>(
                sp => new(
                    sp.GetRequiredService<NavigationStore>(),
                    (t) => sp.GetRequiredService<ViewModelBase>()
                    ));
            collection.AddScoped<NavigationCommand<ViewModelBase>>();
            collection.AddScoped<NavigationCommand<ClientViewModel>>();
        }

       
    }
}
