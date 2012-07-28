using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Common.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CodeAttribute : Attribute
    {

        public Dictionary<string, string> Fields { get; private set; }
        public CodeAttribute(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ApplicationException("CodeAttribute 构造方法中参数为空。");
            }
            string[] items = json.Split('|');
            if (items != null)
            {
                Fields = new Dictionary<string, string>();
                foreach (var item in items)
                {
                    var fieldEntity = item.Split(':');
                    if (fieldEntity == null || fieldEntity.Length != 2)
                    {
                        throw new ApplicationException("CodeAttribute 构造方法中参数格式错误（'" + json + "'）。");
                    }
                    Fields[fieldEntity[0]] = fieldEntity[1];
                }
            }
        }

        public class _Entity
        {
            public string Field { get; set; }
            public string Prefix { get; set; }
            public string Length { get; set; }
        }
    }


}
