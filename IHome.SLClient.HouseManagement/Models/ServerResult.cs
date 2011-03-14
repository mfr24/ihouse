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

namespace IHome.SLClient.HouseManagement.Models
{
    public class ServerResult
    {
        public bool succeed { get; set; }
        public object data { get; set; }
        public string message { get; set; }
    }
}
