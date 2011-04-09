using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHome.Models.Data;
namespace IHome.Server.Activity
{
    public class InfoManagementAct
    {
        private readonly Data.Storage.base_datadic_tree_storage dataStorage = new Data.Storage.base_datadic_tree_storage();
        public base_datadic_tree GetModel(Guid id)
        {
            if (dataStorage.GetList(id).Count == 0) return null;
            return dataStorage.GetList(id)[0];
        }
    }
}
