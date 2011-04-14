using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;
using IHome.Models.Data;
using System.Windows.Input;
using ILight.Core.Net.WebRequest;
namespace IHome.UserManagement
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
                    null,
                    (result) =>
                    {
                        //do somethting while server return
                    });
                });
            }
        }
        public ObservableCollection<sys_user_baseinfo_ex> UserList { get; set; }
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