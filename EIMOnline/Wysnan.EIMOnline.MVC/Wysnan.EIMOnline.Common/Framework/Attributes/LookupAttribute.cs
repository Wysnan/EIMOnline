using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Enum;

namespace Wysnan.EIMOnline.Common.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class LookupAttribute : Attribute
    {
        public LookupCodeEnum LookupCode { get; set; }
        public LookupAttribute(LookupCodeEnum lookupCode)
        {
            this.LookupCode = lookupCode;
        }
    }
}
