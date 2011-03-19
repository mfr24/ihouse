using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using IHome.Server.Common;
namespace IHome.Server.Facade
{
    public class MainFacade
    {
        public MainFacade()
        {
        }
        public MainFacade(string user)
        {
        }
        public ArrayList AddHoseInfo(string userKey, Dictionary<string, object>[] paramDicts)
        {

            ArrayList revList = new ArrayList();
            revList.Add(new Models.ServerResult() { succeed = true, data = new Models.HouseInfo() { MyProperty1 = "123123 from server", MyProperty2 = "123123 from server" }, message = "message f!!!!!!" });
            return revList;
        }
        public ArrayList Login(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Models.User model = paramDicts[0]["user"].ToString().JsonToModel<Models.User>();
            ArrayList revList = new ArrayList();
            {
                //check user
            }
            revList.Add(new Models.ServerResult() { succeed = true, data = new Models.User() { user_login = "哈哈", token = Guid.NewGuid().ToString() }, message = "message f!!!!!!" });
            return revList;
        }
        public ArrayList Register(string userKey, Dictionary<string, object>[] paramDicts)
        {
            //Models.User model = paramDicts[0]["user"].ToString().JsonToModel<Models.User>();
            {
                Data.sys_user_baseinfo user = new Data.sys_user_baseinfo();
                user.user_id = Guid.NewGuid();
                user.city_name = "北京";
                using (var context=new Data.CbooEntities())
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
                revList.Add(new Models.ServerResult() { succeed = true, data = users.ToList<Data.sys_user_baseinfo>(), message = "message f!!!!!!" });
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

                    data = communities.ToList<Data.base_community_baseinfo>();
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
            revList.Add(new Models.ServerResult() { succeed = erro == null, data = data ,message=message});
            return revList;

        }

        public ArrayList AddCommunity(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            try
            {
                Data.base_community_baseinfo community = paramDicts[0]["community"].ToString().JsonToModel<Data.base_community_baseinfo>();
                community.community_id = Guid.NewGuid();
                using (var context = new Data.CbooEntities())
                {
                    context.base_community_baseinfo.AddObject(community);
                    int a =context.SaveChanges();
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
