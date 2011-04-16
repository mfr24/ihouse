using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;
using IHome.Models.Data;
using System.Windows.Input;
using IHome.Models;
using ILight.Core.Net.WebRequest;
namespace IHome.SLClient.UserManagement
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public CmdType _cmdTpe;
        public UserViewModel()
        {
            ButtonList = new ObservableCollection<CmdButton>() { 
                new CmdButton() { text = "添加" }, 
                new CmdButton() { text = "修改" }, 
                new CmdButton() { text = "删除" }, 
                new CmdButton() { text = "查看" } 
            };
            NewUser = new sys_user_baseinfo_ex() { user_name = "蜡笔小新" };
        }
        public ICommand GetUserList
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {

                    Dictionary<string, object> requestParams = new Dictionary<string, object>();

                    requestParams["Pager`1"] = DataPager;
                    List<object> requestList = new List<object>() { requestParams };

                    this.Request("IHome.Server.Facade.MainFacade.GetUserList",
                    requestList,
                    (result) =>
                    {
                        var model = result.GetData<Pager<sys_user_baseinfo_ex>>().data;
                        DataPager.total = model.total;
                        UserList = model.data_list;
                        NotifyPropertyChanged("UserList");
                    });
                });
            }
        }
        public ICommand SaveUser
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    List<object> requestList = new List<object>();
                    Dictionary<string, object> requestParams = new Dictionary<string, object>();
                    requestParams["user"] = NewUser;
                    requestList.Add(requestParams);
                    this.Request(_cmdTpe==CmdType.Add
                        ? "IHome.Server.Facade.MainFacade.AddUser"
                        : "IHome.Server.Facade.MainFacade.UpdateUser",
                    requestList,
                    (result) =>
                    {
                        //do somethting while server return
                    });
                });
            }
        }
        public ICommand DeleteUser
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    List<object> requestList = new List<object>();
                    Dictionary<string, object> requestParams = new Dictionary<string, object>();
                    requestParams["user_id"] = SelectedUser.user_id;
                    requestList.Add(requestParams);
                    this.Request("IHome.Server.Facade.MainFacade.DeleteUser",
                    requestList,
                    (result) =>
                    {
                        //do somethting while server return
                    });
                });
            }
        }
        public ICommand ViewAdd
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                        NewUser = new sys_user_baseinfo_ex();
                        _cmdTpe = CmdType.Add;
                        NotifyPropertyChanged("NewUser");
                });
            }
        }
        public ICommand ViewUpdate
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                        NewUser = SelectedUser;
                        _cmdTpe = CmdType.Update;
                        NotifyPropertyChanged("NewUser");
                });
            }
        }
        public ObservableCollection<CmdButton> ButtonList { get; set; }
        public ObservableCollection<sys_user_baseinfo_ex> UserList { get; set; }
        private Models.Pager<sys_user_baseinfo_ex> _dataPager = new Models.Pager<sys_user_baseinfo_ex>() { page_index = 0, page_size = 5, total = 20 };
        public Models.Pager<sys_user_baseinfo_ex> DataPager
        {
            get { return _dataPager; }
            set { _dataPager = value; }
        }
        private bool _isCheckAll = false;
        public bool IsCheckAll
        {
            get { return _isCheckAll; }
            set
            {
                _isCheckAll = value;
                foreach (var item in UserList)
                {
                    item.check_status_ex = _isCheckAll;
                }
                NotifyPropertyChanged("IsCheckAll");
            }
        }
        public sys_user_baseinfo_ex SelectedUser { get; set; }
        public sys_user_baseinfo_ex NewUser { get; set; }
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