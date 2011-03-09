using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace IHome.SLClient
{

    public class Menu {
        public string header { get; set; }
        public List<DLLModel> item_list{get;set;}
    }
	public class MainOutLookViewModel : INotifyPropertyChanged
	{
        public ICommand ItemCommand {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {

                    DLLModel dll = (DLLModel)p;
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
		public MainOutLookViewModel()
		{
            string menulist = "[{header:'房源管理',item_list:[{name:'新增房源'},{name:'查询房源'}]},{header:'客户管理',item_list:[{name:'新增客户'},{name:'查询客户'}]},{header:'基础设置',item_list:[{name:'架构设置'},{name:'小区名称设置'}]},{header:'最近打开',item_list:[{name:'新增房源'},{name:'查询客户'}]}]";
            string houselist = "[{name:'新增房源'},{name:'查询房源'}]";
            menuList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Menu>>(menulist);
           houseManagementList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DLLModel>>(houselist);
		}
        private List<Menu> menuList;

        public List<Menu> MenuList
        {
            get { return menuList; }
            set { menuList = value; }
        }
        private List<DLLModel> houseManagementList;

        public List<DLLModel> HouseManagementList
        {
            get { return houseManagementList; }
            set { houseManagementList = value; }
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