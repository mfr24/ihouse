using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IHome.Models.Validation;
using ILight.Core.Model;
namespace IHome.Data
{
    public partial class base_community_baseinfo_ex : base_community_baseinfo,IValidateable
    {

        public base_community_baseinfo_ex()
        {
            _validationContext = new ValidationContext(this, null, null);
        }


        [Required(ErrorMessage = "小区名不能为空")]
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
        public string pinyin
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


        //属性为int时,无法捕获前端输入字符串引发的异常;
        public string complete_year_ex
        {
            get
            {
                if (base.complete_year == null) return null;
                return base.complete_year.ToString();
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    int year = 0;
                    if (!int.TryParse(value, out year))
                    {

                        return;
                    }
                    base.complete_year = int.Parse(value);
                }
                else
                {
                    base.complete_year = null;
                }

            }
        }


        #region validation
        private ICollection<ValidationResult> _validationResults = new List<ValidationResult>();
        private string _error = string.Empty;
        private Dictionary<string, List<string>> _errorDict = new Dictionary<string, List<string>>();
        private ValidationContext _validationContext;
        public string Error
        {
            get { return _error; }
        }
        public string this[string columnName]
        {
            get
            {

                if (_errorDict.ContainsKey(columnName))
                {
                    string str = "|";
                    foreach (var item in _errorDict[columnName])
                    {
                        str += item + "|";
                    }
                    return str;
                }
                return null;
            }
        }
        public bool ValidatePro(string columnName, object value)
        {
            return this.ValidatePro(columnName, value, ref _errorDict, ErrorsChanged);
        }

        public bool Validate()
        {
            return this.Validate(ref _errorDict, ErrorsChanged);
        }
        #endregion
        #region INotifyDataErrorInfo
        private List<ValidationResult> _errorsContainer;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (_errorDict.ContainsKey(propertyName))
            {
                return _errorDict[propertyName];
            }
            return null;
        }

        public bool HasErrors
        {
            get
            {
                return _errorDict.Count > 0;
            }
        }
        #endregion
    }
}
