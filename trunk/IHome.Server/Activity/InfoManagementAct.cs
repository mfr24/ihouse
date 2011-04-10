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
        public base_datadic_tree GetDictTree()
        {
            var root = _datadictStorage.GetRoot();
            FillChildren(root);
            return root;
        }
        public void FillChildren(base_datadic_tree node)
        {
            node.children_ex = _datadictStorage.GetChildren(node.item_id);
            foreach (var item in node.children_ex)
            {
                if (item.leaf.Value) return;
                FillChildren(item);
            }
        }
    }
}
