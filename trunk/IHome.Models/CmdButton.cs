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
    public class CmdButton
    {
        public string text { get; set; }
        public ICommand cmd { get; set; }
        public object param { get; set; }
    }
}
