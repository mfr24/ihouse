using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;

namespace IHome.SLClient.InfoManagement
{
	public class ConmmunityViewModel : INotifyPropertyChanged
	{
        public ICommand AddConmmunity {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    System.Windows.Controls.ChildWindow childWin = new System.Windows.Controls.ChildWindow();
                    childWin.Content =new ConmmunityAddView();
                    childWin.Show();
                });
            
            }
        }
		public ConmmunityViewModel()
		{
			
		}

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