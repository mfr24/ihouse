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
        readonly static string _deleteUserList = "update base_community_buildinginfo set status=-1 where building_id in ('{0}')";

        /// <summary>
        /// update building info
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="paramDicts"></param>
        /// <returns></returns>
        public ArrayList UpdateUser(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                Models.Data.sys_user_baseinfo model = paramDicts[0]["building"].ToString().JsonToModel<Models.Data.base_community_buildinginfo>();

                data = Entity.UpdateModel(model);
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
        public ArrayList AddUser(string userKey, Dictionary<string, object>[] paramDicts)
        {
            return Excute(data => {
                Models.Data.sys_user_baseinfo model = paramDicts[0]["user"].ToString().JsonToModel<Models.Data.sys_user_baseinfo>();
                model.user_id = Guid.NewGuid();
                data = Entity.AddModel(model);
            });
        }

        /// <summary>
        /// get building info as List<base_community_buildinginfo>
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="paramDicts"></param>
        /// <returns></returns>
        public ArrayList GetUserList(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            Models.Pager<sys_user_baseinfo> pager=null;
            if (paramDicts[0].ContainsKey("Pager`1"))
                pager = paramDicts[0].As<Models.Pager<sys_user_baseinfo>>();
            try
            {
                var models = Entity.GetModelList<sys_user_baseinfo, object>(
                    //model => model.user_name == "aaa",
                    null,
                    model => model.user_name
                    );
                    if (pager == null) data = models.ToList();
                    else data = models.Page(pager);
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
        public ArrayList DeleteUserList(string userKey, Dictionary<string, object>[] paramDicts)
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


    }
}
