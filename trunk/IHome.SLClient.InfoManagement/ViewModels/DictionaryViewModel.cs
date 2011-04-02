using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using IHome.Models.Data;
using IHome.Models;
using ILight.Core.Net.WebRequest;
namespace IHome.SLClient.InfoManagement
{
	public class DictionaryViewModel : INotifyPropertyChanged
	{
        public void GetRoot()
        {
            List<object> requestList = new List<object>();
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestList.Add(requestParams);
            this.Request("IHome.Server.Facade.MainFacade.GetRoot",
            requestList,
            (result) =>
            {
                Dict = result.GetData<base_datadic_tree_ex>().data;
            });
        }
		public DictionaryViewModel()
		{
            GetRoot();
		}
        private base_datadic_tree_ex _dict;

        public base_datadic_tree_ex Dict
        {
            get { return _dict; }
            set { _dict = value;
            NotifyPropertyChanged("Dict");
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