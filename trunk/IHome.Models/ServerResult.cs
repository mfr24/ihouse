using System;
using System.Collections.Generic;

namespace IHome.Models
{
    public class ServerResult<T>
    {
        public bool succeed { get; set; }
        public T data { get; set; }
        public string message { get; set; }
    }
    public static class ServerResultEx
    {
        public static ServerResult<T> GetData<T>(this ILight.Core.Net.WebRequest.RequestCompletedEventArgs result)
        {
            List<ServerResult<T>> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerResult<T>>>(result.JsonData);
            return list[0];
        }
    }
}
