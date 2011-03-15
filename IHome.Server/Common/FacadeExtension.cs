using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IHome.Server.Common
{
    public static class FacadeExtension
    {
        public static T JsonToModel<T>(this string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}
