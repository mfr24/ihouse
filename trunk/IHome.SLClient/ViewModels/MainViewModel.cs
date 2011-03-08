using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using ILight.Core.Model;
using System.Windows;
using Newtonsoft.Json;

namespace IHome.SLClient
{
    public class DLLModel {
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
	public class MainViewModel : INotifyPropertyChanged
	{
		public MainViewModel()
		{
			
		}
        public ICommand MenuCommand {
            get
            {
                return new ILight.Core.Model.CommandBase(
                    (parameter) =>
                    {
                        DLLModel dll= JsonConvert.DeserializeObject<DLLModel>((string)parameter);
                        
                        ILight.Core.Reflection.AssemblyProvider.GetInstanceAsync(dll.type_name, dll.xap_name, dll.version, (frm) =>
                        {
                            foreach (ILight.Controls.RadControls.RadTabItemCloseable item in ((Telerik.Windows.Controls.RadTabControl)((FrameworkElement)Application.Current.RootVisual).FindName("MainTab")).Items)
                            {
                                if (item.Content.GetType().FullName == dll.type_name)
                                {
                                    item.IsSelected = true;
                                    return;
                                }
                            }
                            ILight.Controls.RadControls.RadTabItemCloseable tab = new ILight.Controls.RadControls.RadTabItemCloseable() { Header = dll.name, Content = frm, IsSelected = true };
                            ((Telerik.Windows.Controls.RadTabControl)((FrameworkElement)Application.Current.RootVisual).FindName("MainTab")).Items.Add(tab);
                            //((Telerik.Windows.Controls.RadTabControl)((FrameworkElement)Application.Current.RootVisual).FindName("MainTab")).se
                        });
                    }
                    );
            }
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