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
            revList.Add(new Models.ServerResult() { succeed = true, data = new Models.User() { User_nicename = "哈哈",Token=Guid.NewGuid().ToString() }, message = "message f!!!!!!" });
            return revList;
        }

    }
}
