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

namespace IHome.Models
{
    public class DLLModel
    {
        public string name { get; set; }
        public string type_name { get; set; }
        public string xap_name { get; set; }
        private string _version = "1.0.0.0";

        public string version
        {
            get { return _version; }
            set { _version = value; }
        }
    }
}
