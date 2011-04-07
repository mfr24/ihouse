using System;
using System.Collections.Generic;

namespace IHome.Models
{
    /// <summary>
    /// base model of server returned
    /// </summary>
    /// <typeparam name="T">type of ServerResult.data</typeparam>
    public class ServerResult<T>
    {
        public bool succeed { get; set; }
        public T data { get; set; }
        public string message { get; set; }
    }
    public static class ServerResultEx
    {
        /// <summary>
        /// Serialization result to ServerResult
        /// </summary>
        /// <typeparam name="T">type of ServerResult.data</typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ServerResult<T> GetData<T>(this ILight.Core.Net.WebRequest.RequestCompletedEventArgs result)
        {
            List<ServerResult<T>> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ServerResult<T>>>(result.JsonData);
            return list[0];
        }
    }
}
