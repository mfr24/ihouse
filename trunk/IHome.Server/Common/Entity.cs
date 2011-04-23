using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IHome.Server.Facade
{
    public class table_info {
        public string key { get; set; }
        public string field { get; set; }
    }
    public static class Entity
    {
        private static Dictionary<string, string> EntityKey = new Dictionary<string, string>();
        private static string GetKey(string tableName)
        {
            if (!EntityKey.ContainsKey(tableName))
            {
                using (var context = new Data.CbooEntities())
                {
                    var table = context.ExecuteStoreQuery<table_info>("desc " + tableName);
                    EntityKey[tableName] = table.Where(t => t.key == "PRI").First().field;
                }
            }
            return EntityKey[tableName];
        }
        public static object GetModelList<TEntity, TKey>(Func<TEntity, bool> where, Func<TEntity, TKey> orderby, Models.Pager<TEntity> pager) where TEntity : class
        {
            using (var context = new Data.CbooEntities())
            {
                IEnumerable<TEntity> models = (from model in context.CreateObjectSet<TEntity>()
                             select model);
                if (where != null) models=models.Where(where);
                if (orderby != null) models=models.OrderBy(orderby);
                if(pager!=null) return models.Page(pager);
                return models.ToList();
            }
        }
        public static int AddModel<TEntity>(TEntity model) where TEntity : class
        {
            using (var context = new Data.CbooEntities())
            {
                context.CreateObjectSet<TEntity>().AddObject(model);
                return context.SaveChanges();
            }
        }
        public static int UpdateModel<TEntity>(TEntity model) where TEntity : class
        {
            using (var context = new Data.CbooEntities())
            {
                context.CreateObjectSet<TEntity>().Attach(model);
                context.ObjectStateManager.ChangeObjectState(model, System.Data.EntityState.Modified);
                return context.SaveChanges();
            }
        }
        public static string _deleteModel = "update {0} set dr=1 where {1}='{2}'";
        /// <summary>
        /// update TEntity set dr=1 where Primarykey = id
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id">Primary key</param>
        /// <returns></returns>
        public static int DeleteModel<TEntity>(string id) where TEntity : class
        {
            string tableName=typeof(TEntity).Name;
            using (var context = new Data.CbooEntities())
            {
                context.ExecuteStoreCommand(string.Format(_deleteModel, tableName, GetKey(tableName), id));
                return context.SaveChanges();
            }
        }
    }
}
