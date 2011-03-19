using System;

namespace IHome.Models
{
    public class ServerResult<T>
    {
        public bool succeed { get; set; }
        public T data { get; set; }
        public string message { get; set; }
    }
}
