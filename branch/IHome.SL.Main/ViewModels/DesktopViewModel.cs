using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using IHome.Models;

namespace IHome.SL.Main
{
	public class DesktopViewModel : INotifyPropertyChanged
	{
        
		public DesktopViewModel()
		{
            IHomeAppIcons = new List<AppIcon>();
            IHomeAppIcons.Add(new AppIcon());
            IHomeAppIcons.Add(new AppIcon());
            IHomeAppIcons.Add(new AppIcon());
            IHomeAppIcons.Add(new AppIcon());
            IHomeAppIcons.Add(new AppIcon());
		}
        public IList<AppIcon> IHomeAppIcons { get; set; }
           
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