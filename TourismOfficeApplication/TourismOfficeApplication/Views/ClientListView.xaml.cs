using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TourismOfficeApplication.Models;
using TourismOfficeApplication.Virtualization;

namespace TourismOfficeApplication.Views
{
    /// <summary>
    /// Interaction logic for ClientListView.xaml
    /// </summary>
    public partial class ClientListView : UserControl
    {
        public ClientListView()
        {
            InitializeComponent();
            
        }

        private void OnPageRenderd(int pageIndex,int countItems,int pageSize)
        {
            
        }

        private void DataGridContainer_Loaded(object sender, RoutedEventArgs e)
        {
            var item = (VirtualizationCollection<Client>)DataGridContainer.ItemsSource;
            item.PageRendered += OnPageRenderd ;
        }
    }
}
