using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.ComponentModel.DataAnnotations;
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
                List<ValidationResult> validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateProperty(valid.Value, new ValidationContext(Activator.CreateInstance(null, valid.ModelName).Unwrap(),null,null) { MemberName = valid.Property }, validationResults))
                {
                    data = validationResults;
                }
                else
                {
                    data = null;
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
