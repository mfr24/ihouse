﻿using System.ComponentModel;
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
    public class CmdWin : DLLModel
    {

        public enum WinType { child = 1, tab = 2, info = 4, erro = 8 }
        public WinType Win { get; set; }
        public INotifyPropertyChanged VeiwModel { get; set; }
    }
}
