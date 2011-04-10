using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHome.Models.Data;
namespace IHome.Server.Activity
{
    public class InfoManagementAct
    {
        private readonly Data.Storage.base_datadic_tree_storage _datadictStorage = new Data.Storage.base_datadic_tree_storage();
        public base_datadic_tree GetModel(Guid id)
        {
            if (_datadictStorage.GetList(id).Count == 0) return null;
            return _datadictStorage.GetList(id)[0];
        }
        public base_datadic_tree_ex GetDictTree()
        {
            dynamic root = _datadictStorage.GetRoot();

            return root;
        }
    }
}
