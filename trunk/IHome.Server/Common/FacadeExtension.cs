using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IHome.Server.Facade
{
    public static class FacadeExtension
    {
        public static T JsonToModel<T>(this object json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json.ToString());
        }

        public static T GetModel<T>(this Dictionary<string, object> dict)
        {
            if(dict.ContainsKey(typeof(T).Name))
            {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(dict[typeof(T).Name].ToString());
            }
            throw (new Exception("找不到参数" + typeof(T).Name));
        }
    }
}
