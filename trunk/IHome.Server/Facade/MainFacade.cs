using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

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
            revList.Add(new Models.ServerResult() { succeed = true, data = new Models.HouseInfo() { MyProperty1="123123",MyProperty2="234j234lf3jkl"}, message = "message f!!!!!!" });
            return revList;
        }

    }
}
