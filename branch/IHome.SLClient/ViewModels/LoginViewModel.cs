using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using ILight.Core.Net.WebRequest;
using IHome.Models;
using System.Windows;
using System.Windows.Input;

namespace IHome.SLClient
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand
        {
            get
            {
                return new ILight.Core.Model.CommandBase((parameter) =>
                {
                    PostData();
                });
            }
        }
        private User _currentUser;

        public User CurrentUser
        {
            get { return Application.Current.Resources["CurrentUser"] as User; }
            set {
                if (!Application.Current.Resources.Contains("CurrentUser"))
                {
                    Application.Current.Resources.Add("CurrentUser", value);
                }
                else { Application.Current.Resources["CurrentUser"] = value;
                }
                }
        }
        private string _user_login;

        public string User_login
        {
            get { return _user_login; }
            set
            {
                _user_login = value;
                NotifyPropertyChanged("User_login");
            }
        }
        private string _user_pass;

        public string User_pass
        {
            get { return _user_pass; }
            set
            {
                _user_pass = value;
                NotifyPropertyChanged("User_pass");
            }
        }

        public LoginViewModel()
        {
            //PostData();
        }
        public void PostData()
        {
            List<object> data = new List<object>();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("user", new Models.User() { user_login = _user_login, user_pass = _user_pass });
            Dictionary<int, Type> resultType = new Dictionary<int, Type>();
            data.Add(dict);
            resultType.Add(0, typeof(Models.ServerResult<User>));
            HttpWebRequestProvider webRequest = new HttpWebRequestProvider();
            webRequest.OnRequestCompleted += (sender, result) =>
            {
                
                    Models.ServerResult<User> serverResult = result.DataList[0] as Models.ServerResult<User>;
                    if (serverResult.succeed == true)
                    {
                            CurrentUser = serverResult.data;
                    }
                    else {
                        MessageBox.Show(serverResult.message);
                    }
                
            };
            webRequest.Request(Application.Current.Host.Source.AbsoluteUri.Remove(Application.Current.Host.Source.AbsoluteUri.LastIndexOf("/ClientBin") + 1) + "apphandler.dll",
                "guest",
                "IHome.Server.Facade.MainFacade.Login",
                data,
                resultType);
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