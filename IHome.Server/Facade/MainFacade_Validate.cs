using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace IHome.Server.Facade
{
     public partial class MainFacade
    {
         public ArrayList Validate(string userKey, Dictionary<string, object>[] paramDicts)
        {
            Exception erro = null;
            object data = null;
            string message = null;
            Models.ValidationRequest valid = paramDicts[0].GetModel<Models.ValidationRequest>();
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
    }
}
