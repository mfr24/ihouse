using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace IHome.SLClient.InfoManagement
{
    public class ConmmunityViewModel : INotifyPropertyChanged
    {
        public ICommand AddConmmunity
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    System.Windows.Controls.ChildWindow childWin = new System.Windows.Controls.ChildWindow();
                    childWin.Content = new ConmmunityAddView();
                    childWin.Show();
                });

            }
        }
        public ICommand GetConmmunityList
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    PostData();
                });

            }
        }
        public ConmmunityViewModel()
        {
            _communityList = new ObservableCollection<Models.Data.base_community_baseinfo>();
        }
        private ObservableCollection<Models.Data.base_community_baseinfo> _communityList;
        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value;
            NotifyPropertyChanged("IsBusy");
            }
        }
        

        public ObservableCollection<Models.Data.base_community_baseinfo> CommunityList
        {
            get { return _communityList; }
            set { _communityList = value; }
        }
        private void PostData()
        {
            // creat request array
            List<object> requsetData = new List<object>();

            // creat request object
            Dictionary<string, object> dict = new Dictionary<string, object>();
            requsetData.Add(dict);// request data :[ {house_info:{MyProperty1:'1asdjf',MyProperty2:'2134asdfasdf'}}]

            // creat dictionary contains type of returned object 
            Dictionary<int, Type> resultType = new Dictionary<int, Type>();

            //the dictionary key is index of returned array
            resultType.Add(0, typeof(Models.ServerResult<List<Models.Data.base_community_baseinfo>>));


            ILight.Core.Net.WebRequest.HttpWebRequestProvider webRequest = new ILight.Core.Net.WebRequest.HttpWebRequestProvider();
            //
            webRequest.OnRequestCompleted += (sender, result) =>
            {
                if (result.DataList[0] != null)
                {
                    CommunityList.Clear();
                    List<Models.Data.base_community_baseinfo> data = (result.DataList[0] as Models.ServerResult<List<Models.Data.base_community_baseinfo>>).data;
                    foreach (var item in data)
                    {
                        CommunityList.Add(item);
                    }


                }
            };
            webRequest.Request(Application.Current.Host.Source.AbsoluteUri.Remove(Application.Current.Host.Source.AbsoluteUri.LastIndexOf("/ClientBin") + 1) + "apphandler.dll"
                , "guest"
                , "IHome.Server.Facade.MainFacade.GetCommunityList"
                , requsetData
                , resultType);

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