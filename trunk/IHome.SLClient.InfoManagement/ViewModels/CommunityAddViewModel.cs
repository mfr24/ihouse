using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace IHome.SLClient.InfoManagement
{
	public class CommunityAddViewModel : INotifyPropertyChanged
	{

        public ICommand AddCommunity
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    if (!Community.Validate()) {
                        return;
                    }
                    if (Action == Models.ActionType.Edit)
                    {
                        List<object> list=new List<object>();
                        Dictionary<string, object> dict = new Dictionary<string, object>();
                        dict.Add("community", Community);
                        list.Add(dict);
                        //list.Add(new {base_community_baseinfo= Community });
                        UpdateCommunity("IHome.Server.Facade.MainFacade.UpdateCommunity",
                            list,
                            (result) => { });
                    }
                    else
                    {
                        PostData();
                    }
                });

            }
        }
		public CommunityAddViewModel()
		{
            Community = new Models.Data.base_community_baseinfo_ex() { IsValidate=true};
            Action = Models.ActionType.Add;
		}
        public Models.ActionType Action { get; set; }
        public Models.Data.base_community_baseinfo_ex Community
        {
            get;
            set;
        }
        private void PostData()
        {
            // creat request array
            List<object> requestData = new List<object>();

            // creat request object
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("community", Community);
            requestData.Add(dict);// request data :[ {house_info:{MyProperty1:'1asdjf',MyProperty2:'2134asdfasdf'}}]

            // creat dictionary contains type of returned object 
            Dictionary<int, Type> resultType = new Dictionary<int, Type>();

            //the dictionary key is index of returned array
            resultType.Add(0, typeof(Models.ServerResult<Models.Data.base_community_baseinfo>));


            ILight.Core.Net.WebRequest.HttpWebRequestProvider webRequest = new ILight.Core.Net.WebRequest.HttpWebRequestProvider();
            //
            webRequest.OnRequestCompleted += (sender, result) =>
            {
                if (result.DataList[0] != null)
                {
                    if ((result.DataList[0] as Models.ServerResult<Models.Data.base_community_baseinfo>).succeed)
                    {
                        MessageBox.Show("OK!!!");
                    }
                }
            };
            webRequest.Request(Application.Current.Host.Source.AbsoluteUri.Remove(Application.Current.Host.Source.AbsoluteUri.LastIndexOf("/ClientBin") + 1) + "apphandler.dll"
                , "guest"
                , "IHome.Server.Facade.MainFacade.AddCommunity"
                , requestData
                , resultType);

        }
        private void UpdateCommunity(string method, List<object> requestData, Action<ILight.Core.Net.WebRequest.RequestCompletedEventArgs> onCompleted)
        {


            ILight.Core.Net.WebRequest.HttpWebRequestProvider webRequest = new ILight.Core.Net.WebRequest.HttpWebRequestProvider();
            webRequest.OnRequestCompleted += (sender, result) =>
            {
                onCompleted(result);
            };
            webRequest.Request(Application.Current.Host.Source.AbsoluteUri.Remove(Application.Current.Host.Source.AbsoluteUri.LastIndexOf("/ClientBin") + 1) + "apphandler.dll"
                , "guest"
                , method
                , requestData
                , null);
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