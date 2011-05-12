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
        public Action<string> CmdCompleted { get; set; }
        private CmdType _cmdType;

        public CmdType CmdType
        {
            get { return _cmdType; }
            set { _cmdType = value; }
        }
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
                        if (CmdCompleted != null) {
                            CmdCompleted("Save");
                        }
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
                    if (CmdCompleted != null)
                    {
                        CmdCompleted("Cancel");
                    }
                });
            }
        }
        public UserDetailViewModel()
        {
           
        }
        private sys_user_baseinfo_ex _user;

        public sys_user_baseinfo_ex User
        {
            get { return _user; }
            set
            {
                _user = value;
                NotifyPropertyChanged("User");
            }
        }
       
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