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
    public class UserListViewModel : INotifyPropertyChanged
    {
        public UserListViewModel()
        {
            GetUserList.Execute(null);
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
                        GetUserList.Execute(null);
                    });
                });
            }
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
        public ObservableCollection<sys_user_baseinfo_ex> UserList { get; set; }
        private Models.Pager<sys_user_baseinfo_ex> _dataPager = new Models.Pager<sys_user_baseinfo_ex>() { page_index = 0, page_size = 5, total = 20 };
        public Models.Pager<sys_user_baseinfo_ex> DataPager
        {
            get { return _dataPager; }
            set { _dataPager = value; }
        }
        public sys_user_baseinfo_ex SelectedUser { get; set; }
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