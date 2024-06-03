using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismOfficeApplication.ViewModels
{
    public class ValidatedErrorViewModelBase : ViewModelBase , INotifyDataErrorInfo
    {
        public bool HasErrors => Errors.Any();
        public IEnumerable GetErrors(string? propertyName)
        {
            return Errors.GetValueOrDefault(propertyName, null)!;
        }

        public void AddError(string PropertyName, string error)
        {
            if (!Errors.ContainsKey(PropertyName))
                Errors.Add(PropertyName, new List<string>() { error });
            else
                Errors[PropertyName].Add(error);
            OnErrorsChanged(PropertyName);
        }

        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            
        }
        public void ClearErrors(string propertyName)
        {
            if (Errors.ContainsKey(propertyName))
                Errors.Remove(propertyName);
        }
        public Dictionary<string, List<string>> Errors = new();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    }
}
