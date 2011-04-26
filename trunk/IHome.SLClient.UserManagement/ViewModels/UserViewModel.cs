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
        private int _viewIndex;

        public int ViewIndex
        {
            get { return _viewIndex; }
            set
            {
                _viewIndex = value;
                NotifyPropertyChanged("ViewIndex");
            }
        }

        private UserDetailViewModel _detailVM;
        public UserDetailViewModel DetailVM
        {
            get { return _detailVM; }
        }
        private UserListViewModel _listVM = new UserListViewModel();
        public UserListViewModel ListVM
        {
            get { return _listVM; }
        }

        public ICommand ToAdd
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    _detailVM.User = new sys_user_baseinfo_ex();
                    _detailVM.CmdType = CmdType.Add;
                    ViewIndex = 1;
                });
            }
        }
        public ICommand ToUpdate
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    _detailVM.User = _listVM.SelectedUser;
                    _detailVM.CmdType = CmdType.Update;
                    ViewIndex = 1;
                });
            }
        }
        public ICommand ToListView
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    ViewIndex = 0;
                });
            }
        }
        public CmdType _cmdTpe;
        public UserViewModel()
        {
            ButtonList = new ObservableCollection<CmdButton>() { 
                new CmdButton() { text = "添加" }, 
                new CmdButton() { text = "修改" }, 
                new CmdButton() { text = "删除" }, 
                new CmdButton() { text = "查看" } 
            };
            _detailVM = new UserDetailViewModel()
            {
                CmdCompleted = cmd =>
                {
                    ViewIndex = 0;
                    _listVM.GetUserList.Execute(null);
                }
            };
        }
        public ObservableCollection<CmdButton> ButtonList { get; set; }
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