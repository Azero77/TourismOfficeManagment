using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TourismOfficeApplication.Converters
{
    public class AddNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int num = (int)value;
            int param = int.Parse(parameter.ToString());
            return num + param;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int num = (int)value;
            int param = (int)parameter;
            return num - param;
        }
    }
}
