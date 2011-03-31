using System.ComponentModel;
using ILight.Core.Model;
using System.Collections.Generic;
using System;

namespace IHome.Models.Data
{
    public partial class base_datadic_tree_ex : base_datadic_tree, IValidateable, INotifyPropertyChanged
    {
        bool _isValidate = false;
        public base_datadic_tree_ex()
        {
            Errors = new Dictionary<string, List<string>>();
            //_check_status_ex = false;
        }
        public bool IsValidate
        {
            get { return _isValidate; }
            set { _isValidate = value; }
        }
        #region validation
        private string _error = string.Empty;
        public bool ValidatePro(string columnName, object value)
        {
            if (!_isValidate) return true;
            return this.ValidateProEx(columnName, value);
        }

        public bool Validate()
        {
            return this.ValidateEx();
        }

        public bool HasErrors
        {
            get
            {
                return Errors.Count > 0;
            }
        }

        public Dictionary<string, List<string>> Errors
        {
            get;
            set;
        }

        public void RaiseErrorsChanged(string propertyName)
        {
            this.RaiseErrorsChangedEx(propertyName, ErrorsChanged);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            return this.GetErrorsEx(propertyName);
        }
        #endregion
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
