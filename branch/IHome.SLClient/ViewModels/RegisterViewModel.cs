using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using IHome.Models;
using ILight.Core.Net.WebRequest;

namespace IHome.SLClient
{
	public class RegisterViewModel : INotifyPropertyChanged
	{
        public ICommand RegisterCommand {
            get {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    PostData();
                });
            }
        }
        private User _newUser;

        public User NewUser
        {
            get { return _newUser; }
            set { _newUser = value;
            NotifyPropertyChanged("NewUser");
            }
        }
        private User _currentUser;

        public User CurrentUser
        {
            get { return Application.Current.Resources["CurrentUser"] as User; }
            set
            {
                if (!Application.Current.Resources.Contains("CurrentUser"))
                {
                    Application.Current.Resources.Add("CurrentUser", value);
                }
                else
                {
                    Application.Current.Resources["CurrentUser"] = value;
                }
            }
        }
		public RegisterViewModel()
		{
            _newUser = new User();
		}
        public void PostData()
        {
            List<object> data = new List<object>();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("user", _newUser);
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
                else
                {
                    MessageBox.Show(serverResult.message);
                }

            };
            webRequest.Request(Application.Current.Host.Source.AbsoluteUri.Remove(Application.Current.Host.Source.AbsoluteUri.LastIndexOf("/ClientBin") + 1) + "apphandler.dll",
                "guest",
                "IHome.Server.Facade.MainFacade.Register",
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