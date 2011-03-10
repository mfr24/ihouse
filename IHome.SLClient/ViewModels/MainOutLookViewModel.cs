using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace IHome.SLClient
{

    public class Menu
    {

        public string header { get; set; }
        public ObservableCollection<DLLModel> item_list { get; set; }
    }
    public class MainOutLookViewModel : INotifyPropertyChanged
    {
        public ICommand ItemCommand
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {

                    DLLModel dll = (DLLModel)p;
                    if (Recent.item_list.Contains(dll))
                    {
                        Recent.item_list.RemoveAt(Recent.item_list.IndexOf(dll));
                    }
                    if (Recent.item_list.Count == _recentMax)
                    {
                        Recent.item_list.RemoveAt(Recent.item_list.Count - 1);
                    }
                    Recent.item_list.Insert(0, dll);
                    return;
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
                    });
                }
                    );
            }
        }
        public MainOutLookViewModel()
        {
            string menulist = "[{header:'房源管理',item_list:[{name:'新增房源'},{name:'查询房源'}]},{header:'客户管理',item_list:[{name:'新增客户'},{name:'查询客户'}]},{header:'基础设置',item_list:[{name:'架构设置'},{name:'小区名称设置'}]}]";
            _menuList = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Menu>>(menulist);
            _recent = new Menu() { header = "最近打开", item_list = new ObservableCollection<DLLModel>() };
            _menuList.Add(_recent);
        }
        private ObservableCollection<Menu> _menuList;

        public ObservableCollection<Menu> MenuList
        {
            get { return _menuList; }
            set { _menuList = value; }
        }
        private Menu _recent;
        private int _recentMax = 10;
        public Menu Recent
        {
            get { return _recent; }
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