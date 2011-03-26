using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;

namespace IHome.SLClient.InfoManagement
{
    public class TestViewModel : INotifyPropertyChanged
	{
        public IHome.Models.CmdWin TestWin {
            get {
                return new Models.CmdWin()
                {
                    name = "测试",
                    type_name = "IHome.SLClient.InfoManagement.TestView",
                    xap_name = "IHome.SLClient.InfoManagement.zip",
                    Win = Models.CmdWin.WinType.modal,
                VeiwModel=new TestViewModel(){XXX="Lucky"}};
            }
        }
		public TestViewModel()
		{
            XXX = "text Button";
		}
        public string XXX { get; set; }

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}
		#endregion
	}
}