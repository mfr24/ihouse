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
    /// <summary>
    /// view status
    /// </summary>
    public enum CmdType
    {
        Add=1,
        Update=2,
        Select=4,
        Delete=8
    }
}
