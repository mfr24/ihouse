using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ILight.Core.Model;
using ILight.Core.Net.WebRequest;
using Newtonsoft.Json;

namespace IHome.Models.Data
{
    public partial class sys_user_baseinfo_ex : sys_user_baseinfo, IValidateable, INotifyPropertyChanged
    {
        bool _canValidate = false;
        public sys_user_baseinfo_ex()
        {
            Errors = new Dictionary<string, List<string>>();
            //_check_status_ex = false;
        }
        public bool CanValidate
        {
            get { return _canValidate; }
            set { _canValidate = value; }
        }

        public bool check_status_ex { get; set; }
        #region validation
        private string _error = string.Empty;
        public bool ValidatePro(string columnName, object value)
        {
            if (!_canValidate) return true;
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
