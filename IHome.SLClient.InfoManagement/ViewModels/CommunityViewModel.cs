using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace IHome.SLClient.InfoManagement
{
    public class CommunityViewModel : INotifyPropertyChanged
    {
        public ICommand AddCommunity
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    System.Windows.Controls.ChildWindow childWin = new System.Windows.Controls.ChildWindow();
                    childWin.Content = new CommunityAddView();
                    childWin.Show();
                });

            }
        }
        public ICommand EditCommunity
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    if (CommunitySelected != null) {
                        CommunitySelected.IsValidate = true;
                    System.Windows.Controls.ChildWindow childWin = new System.Windows.Controls.ChildWindow();
                    CommunityAddViewModel vm = new CommunityAddViewModel() { Community = CommunitySelected,Action=Models.ActionType.Edit };
                    childWin.Content = new CommunityAddView(vm);
                    childWin.Show();
                    }
                });

            }
        }
        public ICommand GetCommunityList
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    PostData();
                });

            }
        }
        private bool _isCheckAll = false;

        public bool IsCheckAll
        {
            get { return _isCheckAll; }
            set
            {
                _isCheckAll = value;
                foreach (var item in CommunityList)
                {
                    item.check_status_ex = _isCheckAll;
                }
                NotifyPropertyChanged("IsCheckAll");
            }
        }

        public CommunityViewModel()
        {
            _communityList = new ObservableCollection<Models.Data.base_community_baseinfo_ex>();

        }

        private ObservableCollection<Models.Data.base_community_baseinfo_ex> _communityList;
        private Models.Data.base_community_baseinfo_ex _communitySelected;

        public Models.Data.base_community_baseinfo_ex CommunitySelected
        {
            get { return _communitySelected; }
            set { _communitySelected = value; }
        }
        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value;
            NotifyPropertyChanged("IsBusy");
            }
        }


        public ObservableCollection<Models.Data.base_community_baseinfo_ex> CommunityList
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
            resultType.Add(0, typeof(Models.ServerResult<List<Models.Data.base_community_baseinfo_ex>>));


            ILight.Core.Net.WebRequest.HttpWebRequestProvider webRequest = new ILight.Core.Net.WebRequest.HttpWebRequestProvider();
            //
            webRequest.OnRequestCompleted += (sender, result) =>
            {
                if (result.DataList[0] != null)
                {
                    CommunityList.Clear();
                    List<Models.Data.base_community_baseinfo_ex> data = (result.DataList[0] as Models.ServerResult<List<Models.Data.base_community_baseinfo_ex>>).data;
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