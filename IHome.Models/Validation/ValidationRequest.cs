using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace IHome.Models.Validation
{
    public class ValidationRequest
    {
        public string ModelName { get; set; }
        public string Property { get; set; }
        public object Value { get; set; }
    }
}
