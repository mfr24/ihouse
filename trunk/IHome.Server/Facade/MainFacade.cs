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
                user.CityName = "北京";
                using (var context=new Data.CbooMainEntities())
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
            using (var context = new Data.CbooMainEntities())
            {

                var users = from user in context.sys_user_baseinfo

                            where user.CityName == "北京"

                            select user;
                ArrayList revList = new ArrayList();
                {
                    //check user
                }
                revList.Add(new Models.ServerResult() { succeed = true, data = users.ToList<Data.sys_user_baseinfo>(), message = "message f!!!!!!" });
                return revList;

            }

        }


    }
}
