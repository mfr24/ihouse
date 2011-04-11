﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace SLLab
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JsonTest();
        }
        #region 试验方法
        /// <summary>
        /// 反序列化Json反序列化时,如果属性为List类型,会首先调用此属性的get方法;
        /// </summary>
        private void JsonTest()
        {

            SampleClass sample = new SampleClass();
            sample.IntPro = 1;
            sample.StringPro = "String";
            sample.ListPro = new List<string>();

            string json = JsonConvert.SerializeObject(sample);

            var samlpe2 = JsonConvert.DeserializeObject<SampleClass>(json);
        }
        #endregion
        
    }
}