using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace IHome.Server.Facade
{
    /// <summary>
    /// entrance of assembly
    /// </summary>
    public partial class MainFacade
    {
        private ArrayList Excute(Action<object> act)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                if(act!=null)act(data);
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
        public MainFacade()
        {
        }
        public MainFacade(string user)
        {
        }
        public ArrayList Login(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {

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
        public ArrayList Register(string userKey, Dictionary<string, object>[] paramDicts)
        {
            //Models.User model = paramDicts[0]["user"].ToString().JsonToModel<Models.User>();
            {
                Models.Data.sys_user_baseinfo user = new Models.Data.sys_user_baseinfo();
                user.user_id = Guid.NewGuid();
                user.city_name = "北京";
                using (var context = new Data.CbooEntities())
                {
                    context.sys_user_baseinfo.AddObject(user);
                    context.SaveChanges();
                }
            }
            ArrayList revList = new ArrayList();
            {
                //check user
            }
            revList.Add(new Models.ServerResult() { succeed = true, data = null, message = "message f!!!!!!" });
            return revList;
        }

        public ArrayList GetUserList(string userKey, Dictionary<string, object>[] paramDicts)
        {
            using (var context = new Data.CbooEntities())
            {

                var users = from user in context.sys_user_baseinfo

                            where user.city_name == "北京"

                            select user;
                ArrayList revList = new ArrayList();
                {
                    //check user
                }
                revList.Add(new Models.ServerResult() { succeed = true, data = users.ToList<Models.Data.sys_user_baseinfo>(), message = "message f!!!!!!" });
                return revList;

            }

        }
        public ArrayList GetCommunityList(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                using (var context = new Data.CbooEntities())
                {

                    var communities = from community in context.base_community_baseinfo

                                      //where community.city_name == "北京"

                                      select community;

                    data = communities.ToList<Models.Data.base_community_baseinfo>();
                }
            }
            catch (Exception ex)
            {
                erro = ex;
                message = ex.Message;
            }

            ArrayList revList = new ArrayList();
            {
                //check user
            }
            revList.Add(new Models.ServerResult() { succeed = erro == null, data = data, message = message });
            return revList;

        }

        public ArrayList AddCommunity(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                Models.Data.base_community_baseinfo community = paramDicts[0]["community"].ToString().JsonToModel<Models.Data.base_community_baseinfo>();
                community.community_id = Guid.NewGuid();
                using (var context = new Data.CbooEntities())
                {
                    context.base_community_baseinfo.AddObject(community);
                    int a = context.SaveChanges();
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
        public ArrayList UpdateCommunity(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                Models.Data.base_community_baseinfo community = paramDicts[0]["community"].ToString().JsonToModel<Models.Data.base_community_baseinfo>();
                using (var context = new Data.CbooEntities())
                {
                    context.base_community_baseinfo.Attach(community);
                    context.ObjectStateManager.ChangeObjectState(community, System.Data.EntityState.Modified);
                    int a = context.SaveChanges();
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

        readonly static string _deleteCommunityList = "update base_community_baseinfo set status=-1 where community_id in ('{0}')";
        public ArrayList DeleteCommunityList(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                List<string> communityList = paramDicts[0]["communityList"].ToString().JsonToModel<List<string>>();
                using (var context = new Data.CbooEntities())
                {
                    context.ExecuteStoreCommand(string.Format(_deleteCommunityList, communityList.GetSelectIn()));
                    int a = context.SaveChanges();
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

    }
}
