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
        public ICommand RefreshChild
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    SelectedItem.RefreshChild();
                });
            }
        }
        public ICommand AddChild
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    if (SelectedItem.children_ex == null) { SelectedItem.children_ex = new ObservableCollection<base_datadic_tree_ex>(); }
                    base_datadic_tree_ex newitem = new base_datadic_tree_ex();
                    SelectedItem.children_ex.Add(newitem);
                    SelectedItem.expanded_ex = true;
                    newitem.edit_mode_ex = true;
                });
            }
        }
        public ICommand EditChild
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    SelectedItem.edit_mode_ex = true;
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
                    requestParams["dict"] = SelectedItem;
                    requestList.Add(requestParams);
                    this.Request("IHome.Server.Facade.MainFacade.DeleteDict",
                    requestList,
                    (result) =>
                    {
                        SelectedItem.parent_ex.children_ex.Remove(SelectedItem);
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