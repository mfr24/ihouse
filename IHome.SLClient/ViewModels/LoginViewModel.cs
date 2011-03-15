﻿using System;
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
        public ICommand Cmd_Login {
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
            set { Application.Current.Resources["CurrentUser"] = value; }
        }
        private string _user_login;

        public string User_login
        {
            get { return _user_login; }
            set { _user_login = value;
            NotifyPropertyChanged("User_login");
            }
        }
        private string _user_pass;

        public string User_pass
        {
            get { return _user_pass; }
            set { _user_pass = value;
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
            dict.Add("User_login", User_login);
            dict.Add("User_pass", User_pass);
            Dictionary<int, Type> resultType = new Dictionary<int, Type>();
            data.Add(dict);
            resultType.Add(0, typeof(User));
            HttpWebRequestProvider webRequest = new HttpWebRequestProvider();
            webRequest.OnRequestCompleted += (sender, result) =>
            {
                if (result.DataList[0] != null)
                {
                    CurrentUser = result.DataList[0] as User;
                }
            };
            webRequest.Request(Application.Current.Host.Source.AbsoluteUri.Remove(Application.Current.Host.Source.AbsoluteUri.LastIndexOf("/ClientBin") + 1) + "apphandler.dll", "guest", "SomeHelp.Sever.Facade.MainFacade.Login", data, resultType);
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