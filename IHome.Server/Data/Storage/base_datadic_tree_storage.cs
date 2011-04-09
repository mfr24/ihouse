using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IHome.Server.Data.Storage
{
    public class base_datadic_tree_storage
    {
        public List<Models.Data.base_datadic_tree> GetList(Guid id)
        {
            using (var context = new Data.CbooEntities())
            {

                var models = from model in context.base_datadic_tree
                             where model.item_id == id
                             select model;
                return models.ToList();
            }
        }
    }
}
