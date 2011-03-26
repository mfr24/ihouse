using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;

namespace IHome.SLClient.InfoManagement
{
    public class TestViewModel : INotifyPropertyChanged
	{
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