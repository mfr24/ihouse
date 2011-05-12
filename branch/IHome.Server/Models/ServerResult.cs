using System;
using System.Net;


namespace IHome.Models
{
    public class ServerResult
    {
        public bool succeed { get; set; }
        public object data { get; set; }
        public string message { get; set; }
    }
}
