using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace IHome.SLClient.HouseManagement
{

    public class HouseInfoAddViewModel : INotifyPropertyChanged
    {

        public HouseInfoAddViewModel()
        {

        }

        private string _xxx;

        public string xxx
        {
            get { return _xxx; }
            set { _xxx = value;
            NotifyPropertyChanged("xxx");
            }
        }
        public ICommand AddHoseInfoCommand
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    PostData();
                });
            }
        }
        public ICommand ChangePCommand
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    xxx = Guid.NewGuid().ToString();
                });
            }
        }
        private Models.ServerResult<Models.HouseInfo> _result;

        public Models.ServerResult<Models.HouseInfo> Result
        {
            get { return _result; }
            set { _result = value;
            NotifyPropertyChanged("Result");
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

        /// <summary>
        /// send request to server
        /// server receive a ArrayType like : [{prop1:'jffj',prop2:'du3'},{}]
        /// </summary>

        private void PostData()
        {
            // creat request array
            List<object> requsetData = new List<object>();

            // creat request object
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("house_info", new Models.HouseInfo() { MyProperty1 = "1asdjf", MyProperty2 = "2134asdfasdf" });
            requsetData.Add(dict);// request data :[ {house_info:{MyProperty1:'1asdjf',MyProperty2:'2134asdfasdf'}}]

            // creat dictionary contains type of returned object 
            Dictionary<int, Type> resultType = new Dictionary<int, Type>();

            //the dictionary key is index of returned array
            resultType.Add(0, typeof(Models.ServerResult<Models.HouseInfo>));


            ILight.Core.Net.WebRequest.HttpWebRequestProvider webRequest = new ILight.Core.Net.WebRequest.HttpWebRequestProvider();
            //
            webRequest.OnRequestCompleted += (sender, result) =>
            {
                if (result.DataList[0] != null)
                {
                    Result = result.DataList[0] as Models.ServerResult<Models.HouseInfo>;
                    // do this 
                    Models.HouseInfo houseinfo = Result.data;
                }
            };
            webRequest.Request(Application.Current.Host.Source.AbsoluteUri.Remove(Application.Current.Host.Source.AbsoluteUri.LastIndexOf("/ClientBin") + 1) + "apphandler.dll"
                , "guest"
                , "IHome.Server.Facade.MainFacade.AddHoseInfo"
                , requsetData
                , resultType);

        }
    }
}