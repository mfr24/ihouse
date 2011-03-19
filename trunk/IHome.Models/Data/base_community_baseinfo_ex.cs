using System;
using System.ComponentModel;
using System.Collections.Generic;
namespace IHome.Data
{
    public partial class base_community_baseinfo_ex : base_community_baseinfo, IDataErrorInfo
    {


        override public string community_name
        {
            get { return base.community_name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                { _errors["community_name"] = "小区名不能为空"; return; }

                base.community_name = value;
                if (_errors.ContainsKey("community_name"))
                {
                    _errors.Remove("community_name");
                }

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
                        _errors["complete_year_ex"] = "必须为数字";
                        return;
                    }
                    base.complete_year = int.Parse(value);
                }
                else
                {
                    base.complete_year = null;
                }
                if (_errors.ContainsKey("complete_year_ex"))
                {
                    _errors.Remove("complete_year_ex");
                }

            }
        }
        private string _error = string.Empty;
        public string Error
        {
            get { return _error; }
        }

        private Dictionary<string, string> _errors = new Dictionary<string, string>();
        public string this[string columnName]
        {
            get
            {
                if (_errors.ContainsKey(columnName)) return _errors[columnName];
                else return null;
            }
        }
        public bool HasErrors
        {
            get
            {
                return _errors.Count > 0;
            }
        }
    }
}
