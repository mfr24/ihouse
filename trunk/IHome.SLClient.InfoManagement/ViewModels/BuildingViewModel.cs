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
        public ICommand EditBuilding
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    if (!Building.Validate()) { return; }
                    List<object> requestList = new List<object>();
                    Dictionary<string, object> requestParams = new Dictionary<string, object>();
                    Building.community_id = Community.community_id;
                    string method = Building.building_id == Guid.Empty ?
                                    "IHome.Server.Facade.MainFacade.AddBuilding" : "IHome.Server.Facade.MainFacade.UpdateBuilding";
                    requestParams["building"] = Building;
                    requestList.Add(requestParams);

                    this.Request(method,
                    requestList,
                    (result) =>
                    {
                        if (result.GetData<int>().data > 0)
                        {
                            NotifyPropertyChanged("Building");
                        }
                    });
                });
            }
        }
        public ICommand DeleteBuilding
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    List<object> requestList = new List<object>();
                    Dictionary<string, object> requestParams = new Dictionary<string, object>();
                    List<string> list = new List<string>();
                    list.Add(Building.building_id.ToString());
                    requestParams["building_list"] = list;
                    requestList.Add(requestParams);
                    this.Request("IHome.Server.Facade.MainFacade.DeleteBuildingList",
                    requestList,
                    (result) =>
                    {

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
                   
                    requestParams["community_id"] = Community.community_id;
                    requestParams["Pager`1"] = DataPager;
                    requestList.Add(requestParams);
                    this.Request("IHome.Server.Facade.MainFacade.GetBuildingList",
                    requestList,
                    (result) =>
                    {
                        var model = result.GetData<Pager<base_community_buildinginfo_ex>>().data;
                        DataPager.total = model.total;
                        BuildingList = model.data_list;
                        NotifyPropertyChanged("BuildingList");
                    });
                    //System.Threading.Thread.Sleep(5000);
                });
            }
        }
        public ICommand SbEditeCompleted
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {

                });
            }
        }
        public BuildingViewModel()
        {
            BuildingList = new ObservableCollection<base_community_buildinginfo_ex>();
        }
        private Models.Pager<base_community_buildinginfo_ex> _dataPager = new Pager<base_community_buildinginfo_ex>() { page_index = 1, page_size = 5,total=20 };

        public Models.Pager<base_community_buildinginfo_ex> DataPager
        {
            get { return _dataPager; }
            set { _dataPager = value; }
        }
        public ObservableCollection<base_community_buildinginfo_ex> BuildingList { get; set; }
        private base_community_baseinfo_ex _community;

        public base_community_baseinfo_ex Community
        {
            get { return _community; }
            set
            {
                _community = value;
                GetBuildingList.Execute(null);
            }
        }
        private base_community_buildinginfo_ex _building;

        public base_community_buildinginfo_ex Building
        {
            get { return _building; }
            set
            {
                _building = value;
                NotifyPropertyChanged("Building");
            }
        }
        private bool _isCheckAll = false;
        public bool IsCheckAll
        {
            get { return _isCheckAll; }
            set
            {
                _isCheckAll = value;
                foreach (var item in BuildingList)
                {
                    item.check_status_ex = _isCheckAll;
                }
                NotifyPropertyChanged("IsCheckAll");
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
    }
}