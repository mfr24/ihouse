using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using IHome.Models;
using IHome.Models.Data;
using ILight.Core.Net.WebRequest;
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
                    SelectedItem.Refresh();
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
                        SelectedItem.parent_ex.Refresh();
                    });
                });
            }
        }

        private void RecoverParent(base_datadic_tree_ex node)
        {
            if (node.parent_ex == null || node.parent_ex.visibility_ex == System.Windows.Visibility.Visible) return;
            node.parent_ex.visibility_ex = System.Windows.Visibility.Visible;
            node.parent_ex.expanded_ex = true;
            RecoverParent(node.parent_ex);
        }
        private void VisibleAll(base_datadic_tree_ex node)
        {
            if (node.children_ex == null) return;
            foreach (var item in node.children_ex)
            {
                item.visibility_ex = System.Windows.Visibility.Visible;
                VisibleAll(item);
            }
        }
        private void SearchChildren(string searchText, base_datadic_tree_ex node)
        {
            if (node.children_ex == null) return;
            foreach (var item in node.children_ex)
            {

                if (item.item_name.ToLower().Contains(searchText))
                {
                    RecoverParent(item);
                }
                else
                {
                    item.visibility_ex = System.Windows.Visibility.Collapsed;
                    SearchChildren(searchText, item);
                }
            }
        }
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    if (string.IsNullOrWhiteSpace(_searchText)) return;
                    
                    VisibleAll(Dict.children_ex[0]);
                }
                else
                {
                    SearchChildren(value.ToLower(), Dict.children_ex[0]);
                }
                _searchText = value;
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
                if (!Dict.children_ex[0].leaf.Value) { Dict.children_ex[0].expanded_ex = true; }
            });
        }
		public DictionaryViewModel()
		{
            Dict = new base_datadic_tree_ex() { children_ex=new System.Collections.ObjectModel.ObservableCollection<base_datadic_tree_ex>()};
            if (!((AppViewModel)System.Windows.Application.Current.Resources["AppDataSource"]).IsInDesignMode)
            {
                GetRoot();
            }
                

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