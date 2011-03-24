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
            string menulist = "["
                            + " {header:'房源管理',item_list:[{name:'SL测试',type_name:'IHome.SLClient.InfoManagement.TestView',xap_name:'IHome.SLClient.InfoManagement.zip'},{name:'新增房源',type_name:'IHome.SLClient.HouseManagement.HoseInfoAddView',xap_name:'IHome.SLClient.HouseManagement.zip'},{name:'查询房源'},{name:'房源跟单'},{name:'房源详情'},{name:'房源修改'},{name:'房源推送'},{name:'房源委托'},{name:'房源带看'},{name:'钥匙收据'},{name:'房源备案'},{name:'房源图片'}]}"
                            + ",{header:'客户管理',item_list:[{name:'新增客需'},{name:'查询客需'},{name:'客需详情'},{name:'客需修改'},{name:'客户跟单'},{name:'客需分类'},{name:'查询客户'},{name:'客户档案'},{name:'客户修改'},{name:'客户分类'},{name:'客户跟单'}]}"
                            + ",{header:'基础设置',item_list:[{name:'小区管理',type_name:'IHome.SLClient.InfoManagement.BuildingAddView',xap_name:'IHome.SLClient.InfoManagement.zip'},{name:'楼盘字典'},{name:'数据字典'},{name:'区域板块'},{name:'数据字典'},{name:'推送配置'},{name:'业务参数'},{name:'个人管理'},{name:'个人信息管理'},{name:'业务报表'}]}"
                            + ",{header:'成交管理',item_list:[{name:'成交登记'},{name:'成交查询'},{name:'交易详情'},{name:'交易修改'},{name:'款项收支'},{name:'成交统计'},{name:'按区域统计'},{name:'按交易类型统计'},{name:'按小区统计'}]}"
                            + ",{header:'佣金管理',item_list:[{name:'款项明细'},{name:'款项修改'},{name:'款项作废'},{name:'资金报表'},{name:'未收管理'},{name:'意向金管理'},{name:'服务费管理'}]}"
                            + ",{header:'最近打开',item_list:[]}]";
            _menuList = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Menu>>(menulist);
            _recent = _menuList[_menuList.Count - 1];
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