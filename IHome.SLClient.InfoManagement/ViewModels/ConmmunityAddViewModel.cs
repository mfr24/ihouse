﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace IHome.SLClient.InfoManagement
{
	public class ConmmunityAddViewModel : INotifyPropertyChanged
	{

        public ICommand AddConmmunity
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    PostData();
                });

            }
        }
		public ConmmunityAddViewModel()
		{
            community = new Data.base_community_baseinfo();
		}
        public Data.base_community_baseinfo community { get; set; }
        private void PostData()
        {
            // creat request array
            List<object> requsetData = new List<object>();

            // creat request object
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("community", community);
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
                    if ((result.DataList[0] as Models.ServerResult<Models.HouseInfo>).succeed)
                    {
                        MessageBox.Show("OK!!!");
                    }
                }
            };
            webRequest.Request(Application.Current.Host.Source.AbsoluteUri.Remove(Application.Current.Host.Source.AbsoluteUri.LastIndexOf("/ClientBin") + 1) + "apphandler.dll"
                , "guest"
                , "IHome.Server.Facade.MainFacade.AddCommunity"
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