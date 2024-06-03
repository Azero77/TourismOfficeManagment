using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TourismOfficeApplication.ViewModels;

namespace TourismOfficeApplication.Validators
{
    internal class NotEmptyValidator : ValidationRule
    {
        private ViewModelBase ViewModel;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is null || string.IsNullOrEmpty(value as string))
                return new ValidationResult(false, "الحقل مطلوب");
            return ValidationResult.ValidResult;
        }
    }
}
