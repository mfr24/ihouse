using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using IHome.Models.Data;
using IHome.Models;
using ILight.Core.Net.WebRequest;
using System.Windows.Input;
using System.Collections.ObjectModel;
namespace IHome.SLClient.InfoManagement
{
	public class DictionaryViewModel : INotifyPropertyChanged
	{
        public ICommand AddChild
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    List<object> requestList = new List<object>();
                    Dictionary<string, object> requestParams = new Dictionary<string, object>();
                    requestParams["dic"] = NewDict;
                    requestList.Add(requestParams);
                    this.Request("IHome.Server.Facade.MainFacade.AddChild",
                    requestList,
                    (result) =>
                    {
                        if (result.GetData<base_datadic_tree_ex>().succeed) {
                            NewDict.parent_ex.children_ex.Add(NewDict);
                        }
                    });
                });
            }
        }
        public ICommand DeleteChildren
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    List<object> requestList = new List<object>();
                    Dictionary<string, object> requestParams = new Dictionary<string, object>();
                    List<string> dic_list = new List<string>();
                    var item = SelectedItem;
                    requestParams["dic_list"] = dic_list;
                    requestList.Add(requestParams);
                    this.Request("IHome.Server.Facade.MainFacade.DeleteChildren",
                    requestList,
                    (result) =>
                    {
                        //do somethting while server return
                    });
                });
            }
        }
        public void GetRoot()
        {
            List<object> requestList = new List<object>();
            Dictionary<string, object> requestParams = new Dictionary<string, object>();
            requestList.Add(requestParams);
            this.Request("IHome.Server.Facade.MainFacade.GetRoot",
            requestList,
            (result) =>
            {
                Dict.children_ex.Add(result.GetData<base_datadic_tree_ex>().data);
            });
        }
		public DictionaryViewModel()
		{
            Dict = new base_datadic_tree_ex() { children_ex=new System.Collections.ObjectModel.ObservableCollection<base_datadic_tree_ex>()};
            GetRoot();
		}
        private base_datadic_tree_ex _dict;

        public base_datadic_tree_ex Dict
        {
            get { return _dict; }
            set { _dict = value;
            }
        }
        public base_datadic_tree_ex NewDict { get; set; }
        public base_datadic_tree_ex SelectedItem { get; set; }
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