using System.ComponentModel;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using ILight.Core.Net.WebRequest;
using ILight.Core.Model;
namespace IHome.Models.Data
{
    public partial class base_datadic_tree_ex : base_datadic_tree, IValidateable, INotifyPropertyChanged
    {
        private ObservableCollection<base_datadic_tree_ex> _children_ex;
        public ObservableCollection<base_datadic_tree_ex> children_ex
        {
            get
            {
                if (_children_ex == null && leaf.HasValue && !leaf.Value)
                {
                    List<object> requestList = new List<object>();
                    Dictionary<string, object> requestParams = new Dictionary<string, object>();
                    requestParams["item_id"] = this.item_id;
                    requestList.Add(requestParams);
                    this.Request("IHome.Server.Facade.MainFacade.GetChildren",
                    requestList,
                    (result) =>
                    {
                        _children_ex = result.GetData<ObservableCollection<base_datadic_tree_ex>>().data;
                        NotifyPropertyChanged("children_ex");
                    });
                }
                return _children_ex;
            }
            set
            {
                _children_ex = value;
                NotifyPropertyChanged("children_ex");
            }
        }

        public base_datadic_tree_ex parent_ex { get; set; }

        private bool _expanded_ex;
        public bool expanded_ex
        {
            get { return _expanded_ex; }
            set
            {
                if (_expanded_ex != value)
                {
                    _expanded_ex = value;
                    NotifyPropertyChanged("expanded_ex");
                }
            }
        }
       
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
