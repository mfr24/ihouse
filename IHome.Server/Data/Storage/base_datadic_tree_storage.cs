using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHome.Models.Data;

namespace IHome.Server.Data.Storage
{
    public class base_datadic_tree_storage
    {
        public List<base_datadic_tree> GetList(Guid id)
        {
            using (var context = new Data.CbooEntities())
            {

                var models = from model in context.base_datadic_tree
                             where model.item_id == id
                             select model;
                return models.ToList();
            }
        }
        public List<base_datadic_tree> GetChildren(Guid parent_id)
        {
            using (var context = new Data.CbooEntities())
            {

                var models = from model in context.base_datadic_tree
                             where model.parent_id == parent_id
                             select model;
                return models.ToList();
            }
        }
        public base_datadic_tree GetRoot() {
            using (var context = new Data.CbooEntities())
            {
                var models = from model in context.base_datadic_tree
                             where model.item_id == new Guid("0cf3f9d0-67ac-492f-91f7-d0b6f31e8165")
                             select model;
                return models.First();
            }
        }
    }
}
