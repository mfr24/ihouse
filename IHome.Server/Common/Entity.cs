using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IHome.Server
{
    public static class Entity
    {
        public static IQueryable<TEntity> GetModelList<TEntity, TKey>(Func<TEntity, bool> where, Func<TEntity, TKey> orderby) where TEntity : class
        {
            using (var context = new Data.CbooEntities())
            {
                var models = from model in context.CreateObjectSet<TEntity>()
                             select model;
                if (where != null) models.Where(where);
                if (orderby != null) models.OrderBy(orderby);
                return models;
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
    }
}
