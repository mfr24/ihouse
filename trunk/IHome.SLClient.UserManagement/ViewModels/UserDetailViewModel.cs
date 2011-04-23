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
    public class UserDetailViewModel : INotifyPropertyChanged
    {
        private CmdType _cmdType;
        public ICommand Save
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    List<object> requestList = new List<object>();
                    Dictionary<string, object> requestParams = new Dictionary<string, object>();
                    requestParams["user"] = User;
                    requestList.Add(requestParams);
                    this.Request(_cmdType == CmdType.Add
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
        public ICommand Cancel
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {

                });
            }
        }
        public UserDetailViewModel()
        {
           
        }
        public sys_user_baseinfo_ex User { get; set; }
        public List<string> State { get; set; }
        public List<string> City { get; set; }
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