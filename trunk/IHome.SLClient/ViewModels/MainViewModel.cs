using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using ILight.Core.Model;
using System.Windows;

namespace IHome.SLClient
{
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
                        new Newtonsoft.Json.JsonConverter().ReadJson(parameter);
                        string[] parameters = ((string)parameter).Split('&');
                        string name = string.Empty;
                        string typeName = string.Empty;
                        string xapName = string.Empty;
                        string version = "1.0.0.0";
                        foreach (string p in parameters)
                        {
                            switch (p.Split('=')[0].Trim().ToLower())
                            {
                                case "frm":
                                    typeName = p.Split('=')[1].Trim();
                                    break;
                                case "name":
                                    name = p.Split('=')[1].Trim();
                                    break;
                                case "xap":
                                    xapName = p.Split('=')[1].Trim();
                                    break;
                                case "version":
                                    version = p.Split('=')[1].Trim();
                                    break;
                            }

                        }
                        ILight.Core.Reflection.AssemblyProvider.GetInstanceAsync(typeName, xapName, version, (frm) =>
                        {
                            foreach (ILight.Controls.RadControls.RadTabItemCloseable item in ((Telerik.Windows.Controls.RadTabControl)((FrameworkElement)Application.Current.RootVisual).FindName("MainTab")).Items)
                            {
                                if (item.Content.GetType().FullName == typeName)
                                {
                                    item.IsSelected = true;
                                    return;
                                }
                            }
                            ILight.Controls.RadControls.RadTabItemCloseable tab = new ILight.Controls.RadControls.RadTabItemCloseable() { Header = name, Content = frm, IsSelected = true };
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