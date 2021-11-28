using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAnnotation.customAttr
{
    public class ValidCreationDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime crtDate = DateTime.Parse(value.ToString());

            return crtDate <= DateTime.Now;
        }
    }
}