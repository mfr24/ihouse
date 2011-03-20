using System;
using System.ComponentModel.DataAnnotations;

namespace IHome.Models.Validation
{
    public class VRegularExpressionAttribute : Attribute
    {
        public VRegularExpressionAttribute(string pattern)
            
        {
            string a = pattern;
        }
        protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult r=new ValidationResult("!!!");
            return r;
        }
    }
}
