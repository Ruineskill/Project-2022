using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels.Bases
{
    public class ValidatedViewModelBase : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _propertyErrors = new();

        public bool HasErrors => _propertyErrors.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            if(propertyName == null) return new List<string>();
            return _propertyErrors.GetValueOrDefault(propertyName, new List<string>());
        }

        public void AddError(string propertyName, string errorMsg)
        {
            if(!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }

            _propertyErrors[propertyName].Add(errorMsg);

            ErrorChanged(propertyName);
        }

        public void ClearErrors(string propertyName)
        {
                _propertyErrors[propertyName].Clear();
                ErrorChanged(propertyName);         
        }

        public bool ContainsErrorFor(string propertyName)
        {
            if(!_propertyErrors.ContainsKey(propertyName)) return false;

            if(!_propertyErrors[propertyName].Any()) return false;

            return true;
        }

        private void ErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public void ChangedProperty(string? property)
        {
            if(property !=null) OnPropertyChanged(property);
        }
    }
}
