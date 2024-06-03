using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourismOfficeApplication.Models;
using TourismOfficeApplication.Windows;

namespace TourismOfficeApplication.Commands
{
    public class ShowDetailsCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            Window DetailsWindow = new DetailsWindow(parameter);
            DetailsWindow.Show();
        }
    }
}
