using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Business.Framework;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.Business
{
    public class BusinessHelp
    {
        public static T Lookup_GetEnum<T>(int lookupid)
           where T : struct
        {
            var lookup = GlobalEntity.Instance.Cache_Lookup.Lookups.Where(a => a.ID == lookupid).FirstOrDefault();
            T t;
            if (lookup != null)
            {
                string enumvalue = lookup.EnumCode.Substring(lookup.EnumCode.LastIndexOf('.') + 1);
                Enum.TryParse(enumvalue, out t);
                return t;
            }
            throw new ApplicationException("系统出现错误,请联系管理员。");
        }

        public static Lookup Lookup_GetLookup<T>(T t)
        {
            string enumCode = typeof(T).Name + "." + t.ToString();
            var lookup = GlobalEntity.Instance.Cache_Lookup.Lookups.Where(a => a.EnumCode == enumCode).FirstOrDefault();
            return lookup;
        }
    }
}
