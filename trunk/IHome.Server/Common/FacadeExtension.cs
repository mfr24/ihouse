using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IHome.Server.Facade
{
    /// <summary>
    /// IHome.Server.Facade Extension Class
    /// </summary>
    public static class FacadeExtension
    {
        public static T JsonToModel<T>(this object json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json.ToString());
        }

        public static T As<T>(this Dictionary<string, object> dict)
        {
            if(dict.ContainsKey(typeof(T).Name))
            {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(dict[typeof(T).Name].ToString());
            }
            throw (new Exception("找不到参数" + typeof(T).Name));
        }

        public static string GetSelectIn(this List<string> list)
        {
            if (list==null||list.Count==0)return "";
            StringBuilder sb=new StringBuilder();
                            foreach (var item in list)
                {
                    sb.Append(item);
                    sb.Append("','");
                }
                sb.Remove(sb.Length - 3, 3);
                return sb.ToString();
        }

        public static Models.Pager<T> Page<T>(this IQueryable<T> query,Models.Pager<T> pager)
        {
            pager.data_list = query.Skip((pager.page_index) * pager.page_size).Take(pager.page_size).ToList();
            pager.total = query.Count();
            return pager;
        }
    }
}
