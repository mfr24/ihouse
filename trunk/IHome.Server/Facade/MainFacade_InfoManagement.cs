using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using IHome.Models.Data;

namespace IHome.Server.Facade
{
    public partial class MainFacade
    {
        #region Building Info

        /// <summary>
        /// sql for delete building info list by building_id
        /// </summary>
        readonly static string _deleteBuildingList = "update base_community_buildinginfo set status=-1 where building_id in ('{0}')";

        /// <summary>
        /// update building info
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="paramDicts"></param>
        /// <returns></returns>
        public ArrayList UpdateBuilding(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                Models.Data.base_community_buildinginfo model = paramDicts[0]["building"].ToString().JsonToModel<Models.Data.base_community_buildinginfo>();
                using (var context = new Data.CbooEntities())
                {
                    context.base_community_buildinginfo.Attach(model);
                    context.ObjectStateManager.ChangeObjectState(model, System.Data.EntityState.Modified);
                    data = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                erro = ex;
                message = ex.Message;
            }
            ArrayList revList = new ArrayList();
            revList.Add(new Models.ServerResult() { succeed = erro == null, data = data, message = message });
            return revList;
        }

        /// <summary>
        /// add building info
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="paramDicts"></param>
        /// <returns></returns>
        public ArrayList AddBuilding(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                Models.Data.base_community_buildinginfo model = paramDicts[0]["building"].ToString().JsonToModel<Models.Data.base_community_buildinginfo>();
                model.building_id = Guid.NewGuid();
                model.status = 1;
                using (var context = new Data.CbooEntities())
                {
                    context.base_community_buildinginfo.AddObject(model);
                    data = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                erro = ex;
                message = ex.Message;
            }
            ArrayList revList = new ArrayList();
            revList.Add(new Models.ServerResult() { succeed = erro == null, data = data, message = message });
            return revList;
        }

        /// <summary>
        /// get building info as List<base_community_buildinginfo>
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="paramDicts"></param>
        /// <returns></returns>
        public ArrayList GetBuildingList(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            Models.Pager<base_community_buildinginfo> pager=null;
            if (paramDicts[0].ContainsKey("Pager`1"))
                 pager=paramDicts[0].As<Models.Pager<base_community_buildinginfo>>();
            try
            {
                var community_id = new Guid(paramDicts[0]["community_id"].ToString());
                using (var context = new Data.CbooEntities())
                {

                    var models = from building in context.base_community_buildinginfo
                                 where building.community_id == community_id && building.status!=-1
                                 orderby building.building_name
                                 select building;
                    if (pager == null) data = models.ToList();
                    else data = models.Page(pager);
                }
            }
            catch (Exception ex)
            {
                erro = ex;
                message = ex.Message;
            }
            ArrayList revList = new ArrayList();
            revList.Add(new Models.ServerResult() { succeed = erro == null, data =data, message = message });
            return revList;
        }

        /// <summary>
        /// delete building info list by building_id
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="paramDicts"></param>
        /// <returns></returns>
        public ArrayList DeleteBuildingList(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                List<string> modelList = paramDicts[0]["building_list"].ToString().JsonToModel<List<string>>();
                using (var context = new Data.CbooEntities())
                {
                    context.ExecuteStoreCommand(string.Format(_deleteBuildingList, modelList.GetSelectIn()));
                    data = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                erro = ex;
                message = ex.Message;
            }

            ArrayList revList = new ArrayList();
            revList.Add(new Models.ServerResult() { succeed = erro == null, data = data, message = message });
            return revList;

        }
        #endregion

        #region base_datadict
        private readonly Activity.InfoManagementAct _infoManagementAct = new Activity.InfoManagementAct();
        public ArrayList GetRoot(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                using (var context = new Data.CbooEntities())
                {
                    var models = from model in context.base_datadic_tree
                                 where model.item_id == new Guid("0cf3f9d0-67ac-492f-91f7-d0b6f31e8165")
                                 select model;
                    data = models.First();
                }
            }
            catch (Exception ex)
            {
                erro = ex;
                message = ex.Message;
            }
            ArrayList revList = new ArrayList();
            revList.Add(new Models.ServerResult() { succeed = erro == null, data = data, message = message });
            return revList;
        }
        public ArrayList GetNode(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                var item_id = new Guid(paramDicts[0]["item_id"].ToString());
                data=_infoManagementAct.GetModel(item_id);
            }
            catch (Exception ex)
            {
                erro = ex;
                message = ex.Message;
            }
            ArrayList revList = new ArrayList();
            revList.Add(new Models.ServerResult() { succeed = erro == null, data = data, message = message });
            return revList;
        }
        public ArrayList GetChildren(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                var item_id = new Guid(paramDicts[0]["item_id"].ToString());
                using (var context=new Data.CbooEntities())
                {
                    var models = from model in context.base_datadic_tree
                                 where model.parent_id==item_id
                                 select model;
                    data = models.ToList();
                }
            }
            catch (Exception ex)
            {
                erro = ex;
                message = ex.Message;
            }
            ArrayList revList = new ArrayList();
            revList.Add(new Models.ServerResult() { succeed = erro == null, data = data, message = message });
            return revList;
        }
        public ArrayList AddDict(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                Models.Data.base_datadic_tree model = paramDicts[0]["dict"].ToString().JsonToModel<Models.Data.base_datadic_tree>();
                model.item_id = Guid.NewGuid();
                model.leaf = true;
                using (var context = new Data.CbooEntities())
                {
                    string max=(from dict in context.base_datadic_tree
                                      where dict.parent_id == model.parent_id
                                       select dict.item_key).Max();
                    if (max == null)
                    {
                        model.item_key = (from dict in context.base_datadic_tree
                                          where dict.item_id == model.parent_id
                                          select dict.item_key).First()+"01";
                    }
                    else
                    {
                        model.item_key = (int.Parse(max,System.Globalization.NumberStyles.HexNumber)+1).ToString("X");
                    }
                    
                    context.base_datadic_tree.AddObject(model);
                    (from parent in context.base_datadic_tree
                                 where parent.item_id == model.parent_id
                                 select parent).First().leaf=false;

                    data = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                erro = ex;
                message = ex.Message;
            }
            ArrayList revList = new ArrayList();
            revList.Add(new Models.ServerResult() { succeed = erro == null, data = data, message = message });
            return revList;
        }
        public ArrayList UpdateDict(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                Models.Data.base_datadic_tree model = paramDicts[0]["dict"].ToString().JsonToModel<Models.Data.base_datadic_tree>();
                using (var context = new Data.CbooEntities())
                {
                    context.base_datadic_tree.Attach(model);
                    context.ObjectStateManager.ChangeObjectState(model, System.Data.EntityState.Modified);
                    data = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                erro = ex;
                message = ex.Message;
            }
            ArrayList revList = new ArrayList();
            revList.Add(new Models.ServerResult() { succeed = erro == null, data = data, message = message });
            return revList;
        }
        readonly string _deleteDict = "delete from base_datadic_tree where item_key like '{0}%'";
        readonly string _setLeaf = "update base_datadic_tree set leaf=1 where item_id ='{0}' ";
        public ArrayList DeleteDict(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                Models.Data.base_datadic_tree model = paramDicts[0]["dict"].ToString().JsonToModel<Models.Data.base_datadic_tree>();
                using (var context = new Data.CbooEntities())
                {
                    context.ExecuteStoreCommand(string.Format(_deleteDict, model.item_key));
                    int count = (from dict in context.base_datadic_tree
                                 where dict.parent_id == model.parent_id
                                 select dict).Count();
                    if (count == 0) {
                        context.ExecuteStoreCommand(string.Format(_setLeaf, model.parent_id));
                    }
                }
            }
            catch (Exception ex)
            {
                erro = ex;
                message = ex.Message;
            }
            ArrayList revList = new ArrayList();
            revList.Add(new Models.ServerResult() { succeed = erro == null, data = data, message = message });
            return revList;
        }
        #endregion

    }
}
