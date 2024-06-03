using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using TourismOfficeApplication.ViewModels;

namespace TourismOfficeApplication.Converters
{
    class GenderPropertyConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            char Gender = (char)value;
            if (Gender == 'F')
                return "Female";
            else
                return "Male";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string Gender = (string)value;
            if (Gender == "Female")
                return 'F';
            else
                return 'M';
        }
    }
}
