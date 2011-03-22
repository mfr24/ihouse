using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IHome.Models.Data
{
    public class base_community_baseinfo_ex : base_community_baseinfo
    {
        const int ToYear = 2011;
        public base_community_baseinfo_ex()
        {
        }


        [Required(ErrorMessage = "小区名不能为空")]
        override public string community_name
        {
            get { return base.community_name; }
            set
            {
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
                base.pinyin = value;
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
                base.complete_year = value;

            }
        }
    }
}
