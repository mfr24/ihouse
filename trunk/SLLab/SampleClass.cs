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
using System.Collections.Generic;

namespace SLLab
{
    public class SampleClass
    {
        private int _intPro;

        public int IntPro
        {
            get { return _intPro; }
            set { _intPro = value; }
        }

        private string _stringPro;

        public string StringPro
        {
            get { return _stringPro; }
            set { _stringPro = value; }
        }

        private List<string> _listPro=new List<string>();

        public List<string> ListPro
        {
            get { return _listPro; }
            set { _listPro = value; }
        }

    }
}
