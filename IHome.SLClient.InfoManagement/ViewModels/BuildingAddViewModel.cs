﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;
using IHome.Models.Data;
using System.Windows.Input;
using ILight.Core.Net.WebRequest;
namespace IHome.SLClient.InfoManagement
{
	public class BuildingAddViewModel : INotifyPropertyChanged
	{
        public ICommand AddBuilding
        {
            get
            {
                return new ILight.Core.Model.CommandBase((p) =>
                {
                    if (!Building[0].Validate()) { return; }
                    List<object> requestList = new List<object>();
                    Dictionary<string, object> requestParams = new Dictionary<string, object>();
                    requestParams["Building"] = Building;
                    requestList.Add(requestParams);
                    this.Request("IHome.Server.Facade.MainFacade.MyMethod",
                    requestList,
                    (result) =>
                    {
                        //do somethting while server return
                    });
                });
            }
        }
		public BuildingAddViewModel()
		{

            Building = new ObservableCollection<base_community_buildinginfo_ex>();
            Building.Add(new base_community_buildinginfo_ex());
		}
        public ObservableCollection<base_community_buildinginfo_ex> Building { get; set; }
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