using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Dynamic;

namespace IHome.Models.Validation
{
    public class ServerAttribute : ValidationAttribute
    {
        public ServerAttribute() { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return PostData(value, validationContext); 
        }

        private ValidationResult PostData(object value, ValidationContext validationContext)
        {
            ValidationResult validrusult=ValidationResult.Success;
            List<object> requsetData = new List<object>();

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("ValidationRequest", new ValidationRequest() { ModelName = validationContext.ObjectInstance.GetType().FullName,Property=validationContext.MemberName,Value=value});
            requsetData.Add(dict);
            Dictionary<int, Type> resultType = new Dictionary<int, Type>();
            resultType.Add(0, typeof(Models.ServerResult<object>));
            ILight.Core.Net.WebRequest.HttpWebRequestProvider webRequest = new ILight.Core.Net.WebRequest.HttpWebRequestProvider();
            webRequest.OnRequestCompleted += (sender, result) =>
            {
                if (result.DataList[0] != null)
                {
                    if ((result.DataList[0] as Models.ServerResult<object>).succeed)
                    {
                        validrusult = new ValidationResult("test");
                        ((ILight.Core.Model.IValidateable)validationContext.ObjectInstance).Errors[validationContext.MemberName].Add(validrusult.ErrorMessage);
                        ((ILight.Core.Model.IValidateable)validationContext.ObjectInstance).RaiseErrorsChanged(validationContext.MemberName);
                    }
                }
                validrusult = ValidationResult.Success;
            };
            webRequest.Request(Application.Current.Host.Source.AbsoluteUri.Remove(Application.Current.Host.Source.AbsoluteUri.LastIndexOf("/ClientBin") + 1) + "apphandler.dll"
                , "guest"
                , "IHome.Server.Facade.MainFacade.Validate"
                , requsetData
                , resultType);
            return validrusult;
        }
    }
}
