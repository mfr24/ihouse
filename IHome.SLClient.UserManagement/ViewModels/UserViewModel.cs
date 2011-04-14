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
        public UserViewModel()
        {

        }
        public ICommand GetUserList
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {

                    this.Request("IHome.Server.Facade.MainFacade.GetUserList",
                    new List<object>() { new Dictionary<string, object>()},
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