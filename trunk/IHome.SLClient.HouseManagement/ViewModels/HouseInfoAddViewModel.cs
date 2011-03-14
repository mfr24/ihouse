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

        private Models.ServerResult _result;

        public Models.ServerResult Result
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
            resultType.Add(0, typeof(Models.ServerResult));


            ILight.Core.Net.WebRequest.HttpWebRequestProvider webRequest = new ILight.Core.Net.WebRequest.HttpWebRequestProvider();
            //
            webRequest.OnRequestCompleted += (sender, result) =>
            {
                if (result.DataList[0] != null)
                {
                    Result = result.DataList[0] as Models.ServerResult;
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