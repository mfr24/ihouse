﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using ILight.Core.Net.WebRequest;
using IHome.Models.Data;
using IHome.Models;
namespace IHome.SLClient.InfoManagement
{
    public class CommunityViewModel : INotifyPropertyChanged
    {

        public ICommand EditCommunity
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    if (CommunitySelected != null)
                    {
                        CommunitySelected.CanValidate = true;
                        System.Windows.Controls.ChildWindow childWin = new System.Windows.Controls.ChildWindow();
                        CommunityAddViewModel vm = new CommunityAddViewModel() { Community = CommunitySelected, Action = Models.ActionType.Edit };
                        childWin.Content = new CommunityAddView(vm);
                        childWin.Show();
                    }
                });

            }
        }
        public ICommand DeleteCommunity
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    List<string> deleteList = new List<string>();
                    foreach (var item in CommunityList)
                    {
                        if (item.check_status_ex) deleteList.Add(item.community_id.ToString());
                    }
                    List<object> list = new List<object>();
                    Dictionary<string, object> requestParams = new Dictionary<string, object>();
                    requestParams["communityList"] = deleteList;
                    list.Add(requestParams);
                    this.Request("IHome.Server.Facade.MainFacade.DeleteCommunityList",
                            list,
                            (result) => { });
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

        private IHome.Models.CmdWin _buildingView = new Models.CmdWin()
                {
                    name = "楼栋信息",
                    type_name = "IHome.SLClient.InfoManagement.BuildingView",
                    xap_name = "IHome.SLClient.InfoManagement.zip",
                    Win = Models.CmdWin.WinType.modal,
                    VeiwModel = new BuildingViewModel()
                };
        public IHome.Models.CmdWin BuildingView
        {
            get
            {
                return _buildingView;
            }
        }

        public IHome.Models.CmdWin CommunityAddView
        {
            get
            {
                return new Models.CmdWin()
                {
                    name = "添加楼盘",
                    type_name = "IHome.SLClient.InfoManagement.CommunityAddView",
                    xap_name = "IHome.SLClient.InfoManagement.zip",
                    Win = Models.CmdWin.WinType.modal
                };
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
            CommunityList = new ObservableCollection<base_community_baseinfo_ex>();
        }

        private Models.Data.base_community_baseinfo_ex _communitySelected;

        public Models.Data.base_community_baseinfo_ex CommunitySelected
        {
            get { return _communitySelected; }
            set
            {
                _communitySelected = value;
                ((BuildingViewModel)BuildingView.VeiwModel).Community = _communitySelected;
            }
        }


        public ObservableCollection<Models.Data.base_community_baseinfo_ex> CommunityList
        {
            get;
            set;
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