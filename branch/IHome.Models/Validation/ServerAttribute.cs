using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Dynamic;

namespace IHome.Models.Validation
{
    public class ServerAttribute : ValidationAttribute
    {

        public ServerAttribute()
        {
            Result = ValidationResult.Success;
        }
        public ValidationResult Result { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return PostData(value, validationContext);
        }

        private ValidationResult PostData(object value, ValidationContext validationContext)
        {

            List<object> requsetData = new List<object>();

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("ValidationRequest", new ValidationRequest() { ModelName = validationContext.ObjectInstance.GetType().FullName, Property = validationContext.MemberName, Value = value });
            requsetData.Add(dict);
            Dictionary<int, Type> resultType = new Dictionary<int, Type>();
            resultType.Add(0, typeof(Models.ServerResult<List<Dictionary<string, object>>>));
            ILight.Core.Net.WebRequest.HttpWebRequestProvider webRequest = new ILight.Core.Net.WebRequest.HttpWebRequestProvider();
            webRequest.OnRequestCompleted += (sender, result) =>
            {
                if (result.DataList[0] != null)
                {
                    if ((result.DataList[0] as Models.ServerResult<List<Dictionary<string, object>>>).succeed)
                    {
                        List<Dictionary<string, object>> validrusults = (result.DataList[0] as Models.ServerResult<List<Dictionary<string, object>>>).data;
                        if (validrusults != null)
                        {
                            foreach (var item in validrusults)
                            {
                                ((ILight.Core.Model.IValidateable)validationContext.ObjectInstance).Errors[validationContext.MemberName].Add(item["ErrorMessage"].ToString());
                            }


                            ((ILight.Core.Model.IValidateable)validationContext.ObjectInstance).RaiseErrorsChanged(validationContext.MemberName);
                        }

                    }
                }
            };
            webRequest.Request(Application.Current.Host.Source.AbsoluteUri.Remove(Application.Current.Host.Source.AbsoluteUri.LastIndexOf("/ClientBin") + 1) + "apphandler.dll"
                , "guest"
                , "IHome.Server.Facade.MainFacade.Validate"
                , requsetData
                , resultType);
            return Result;
        }
    }
}
