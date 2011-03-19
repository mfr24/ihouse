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
            set {
                if (string.IsNullOrWhiteSpace(value))
                _errors.Add("community_name", "小区名不能为空");
                base.community_name = value; 
            }
        }

        //属性为int时,无法捕获前端输入字符串引发的异常;
        new public string complete_year
        {
            get
            {
                if (base.complete_year == null) return null;
                return base.complete_year.ToString();
            }
            set
            {
                if (value != null)
                {
                    int year=0;
                    if (!int.TryParse(value,out year))
                    {
                        _errors.Add("complete_year", "必须为数字");
                        return;
                    }
                }
                base.complete_year = int.Parse(value);
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
    }
}
