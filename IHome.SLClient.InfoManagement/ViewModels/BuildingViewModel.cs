using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using IHome.Models;
using IHome.Models.Data;
using ILight.Core.Net.WebRequest;
namespace IHome.SLClient.InfoManagement
{
    public class BuildingViewModel : INotifyPropertyChanged
    {
        public ICommand AddBuilding
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    if (!Building.Validate()) { return; }
                    List<object> requestList = new List<object>();
                    Dictionary<string, object> requestParams = new Dictionary<string, object>();
                    requestParams["Building"] = Building;
                    requestList.Add(requestParams);
                    this.Request("IHome.Server.Facade.MainFacade.AddBuilding",
                    requestList,
                    (result) =>
                    {
                        //do somethting while server return
                    });
                });
            }
        }
        public ICommand GetBuildingList
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    List<object> requestList = new List<object>();
                    Dictionary<string, object> requestParams = new Dictionary<string, object>();
                    requestParams["CommunityID"] = "";
                    requestList.Add(requestParams);
                    this.Request("IHome.Server.Facade.MainFacade.GetBuildingList",
                    requestList,
                    (result) =>
                    {

                    });
                });
            }
        }
        public BuildingViewModel()
        {
            BuildingList = new ObservableCollection<base_community_buildinginfo_ex>();
        }
        public ObservableCollection<base_community_buildinginfo_ex> BuildingList { get; set; }
        public base_community_buildinginfo_ex Building { get; set; }
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