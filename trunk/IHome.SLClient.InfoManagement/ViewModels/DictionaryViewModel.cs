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

        public ICommand GetDictTree
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    List<object> requestList = new List<object>();
                    this.Request("IHome.Server.Facade.MainFacade.GetDictTree",
                    requestList,
                    (result) =>
                    {
                        var root = result.GetData<base_datadic_tree_ex>().data;
                        root.expanded_ex = true;
                        SetParentToChildren(root);
                        var children = new ObservableCollection<base_datadic_tree_ex>();
                        children.Add(root);
                        Dict.children_ex = children;
                    });
                });
            }
        }
        public void SetParentToChildren(base_datadic_tree_ex node)
        {
            if (node.children == null) return;
            foreach (base_datadic_tree_ex item in node.children)
            {
                item.parent_ex = node;
                SetParentToChildren(item);
            }
        }

        #region Search
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
                item.background_ex = null;
                VisibleAll(item);
            }
        }
        int _searchWait = 0;
        private Action WaitAll;
        private int SearchWait
        {
            get { return _searchWait; }
            set
            {
                _searchWait = value;
                if (_searchWait == 0 && WaitAll != null)
                {
                    WaitAll();
                }
            }
        }
        private void SearchChildren(string searchText, base_datadic_tree_ex node)
        {
            if (node.leaf.Value) return;
            if (node.children_ex == null)
            {
                _searchWait++;
                node.ChildLoaded = () =>
                {
                    SearchChildren(searchText, node);
                    node.ChildLoaded = null;
                    lock (this)
                    {
                        SearchWait--;
                    }

                };
            }
            else
            {
                foreach (var item in node.children_ex)
                {

                    if (item.item_name.ToLower().Contains(searchText))
                    {
                        if (item.visibility_ex == System.Windows.Visibility.Collapsed)
                        {
                            item.visibility_ex = System.Windows.Visibility.Visible;
                            VisibleAll(item);
                        }
                        RecoverParent(item);
                    }
                    else
                    {
                        item.visibility_ex = System.Windows.Visibility.Collapsed;
                        SearchChildren(searchText, item);
                    }
                }
            }
        }
        private void ColorChildren(string searchText, base_datadic_tree_ex node)
        {
            if (node.leaf.Value) return;
            if (node.children_ex == null)
            {
                node.ChildLoaded = () =>
                {
                    ColorChildren(searchText, node);
                    node.ChildLoaded = null;
                };
            }
            else
            {
                foreach (var item in node.children_ex)
                {
                    if (item.visibility_ex == System.Windows.Visibility.Collapsed) continue;
                    if (item.item_name.ToLower().Contains(searchText))
                    {
                        if (item.background_ex == null) item.background_ex = "Yellow";
                        node.expanded_ex = true;
                    }
                    else
                    {
                        item.background_ex = null;
                    }
                    ColorChildren(searchText, item);
                }
            }
        }
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                string search = null;
                if (string.IsNullOrWhiteSpace(value))
                {
                    if (string.IsNullOrWhiteSpace(_searchText)) return;

                    VisibleAll(Dict.children_ex[0]);
                }
                else
                {
                    search = value.ToLower().Trim();
                    if (SearchText == search) return;
                    SearchChildren(search, Dict.children_ex[0]);
                    lock (this)
                    {
                        if (_searchWait > 0)
                        {
                            WaitAll = () => { ColorChildren(search, Dict.children_ex[0]); };
                        }
                        else { ColorChildren(search, Dict.children_ex[0]); }
                    }

                }
                _searchText = search;
            }
        }
        #endregion
       

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
            Dict = new base_datadic_tree_ex() { children_ex = new System.Collections.ObjectModel.ObservableCollection<base_datadic_tree_ex>() };
            if (!((AppViewModel)System.Windows.Application.Current.Resources["AppDataSource"]).IsInDesignMode)
            {
                GetRoot();
            }


        }

        private base_datadic_tree_ex _dict;
        public base_datadic_tree_ex Dict
        {
            get { return _dict; }
            set
            {
                _dict = value;
            }
        }
        private base_datadic_tree_ex _selectedItem;

        public base_datadic_tree_ex SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyPropertyChanged("SelectedItem");
            }
        }

        public base_datadic_tree_ex GridSelected { get; set; }
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