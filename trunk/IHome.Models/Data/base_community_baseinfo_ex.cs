using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IHome.Models.Validation;
using ILight.Core.Model;
namespace IHome.Models.Data
{
    public partial class base_community_baseinfo_ex : base_community_baseinfo, IValidateable, INotifyPropertyChanged
    {
        const int ToYear = 2011;
        public base_community_baseinfo_ex()
        {
            Errors = new Dictionary<string, List<string>>();
            _check_status_ex = false;
            
        }
        private bool _check_status_ex;

        public bool check_status_ex
        {
            get { return _check_status_ex; }
            set { _check_status_ex = value;
            NotifyPropertyChanged("check_status_ex");
            }
        }

        //[Required(ErrorMessage = "小区名不能为空")]
        [Server]
        override public string community_name
        {
            get { return base.community_name; }
            set
            {
                ValidatePro("community_name", value);
                base.community_name = value;


            }
        }
        [Required(ErrorMessage = "小区拼音不能为空")]
        [RegularExpressionAttribute(@"^[A-Za-z]+$", ErrorMessage = "请输入拼音首字母")]
        override public string pinyin
        {
            get
            {
                return base.pinyin;
            }
            set
            {
                if (ValidatePro("pinyin", value)) base.pinyin = value;
            }
        }
        [Range(1940, ToYear, ErrorMessage = "请输入合法的年份")]
        override public int? complete_year
        {
            get
            {
                
                return base.complete_year;
            }
            set
            {
                if (ValidatePro("complete_year", value)) base.complete_year = value;
            }
        }


        #region validation
        private string _error = string.Empty;
        public bool ValidatePro(string columnName, object value)
        {
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
            this.RaiseErrorsChangedEx(propertyName,ErrorsChanged);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            return this.GetErrorsEx(propertyName);
        }
        #endregion
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
