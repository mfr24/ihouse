using System;
using System.Net;

namespace IHome.Models
{
    public class ValidationRequest
    {
        public string ModelName { get; set; }
        public string Property { get; set; }
        public object Value { get; set; }
    }
}
