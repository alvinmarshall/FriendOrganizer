using FriendOrganizer.UI.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FriendOrganizer.UI.Wrapper
{
    public abstract class BaseNotifyDataError : BaseViewModel, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _errorProperName = new Dictionary<string, List<string>>();
        public bool HasErrors => _errorProperName.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorProperName.ContainsKey(propertyName) ? _errorProperName[propertyName] : null;
        }

        protected void OnErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            base.OnPropertyChanged(nameof(HasErrors));
        }

        protected void AddError(string propertyName, string error)
        {
            if (!_errorProperName.ContainsKey(propertyName))
            {
                _errorProperName[propertyName] = new List<string>();
            }
            if (!_errorProperName[propertyName].Contains(error))
            {
                _errorProperName[propertyName].Add(error);
                OnErrorChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertyName)
        {
            if (_errorProperName.ContainsKey(propertyName))
            {
                _errorProperName.Remove(propertyName);
                OnErrorChanged(propertyName);
            }
        }
    }
}
