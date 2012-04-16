using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Common.Framework.Grid.Poco
{
    public class Filters
    {
        public string groupOp { get; set; }

        public List<rules> rules { get; set; }

        public string ConvertToString()
        {
            if ((!string.IsNullOrEmpty(groupOp)) && rules != null)
            {
                StringBuilder filter = new StringBuilder();
                foreach (var item in rules)
                {
                    filter.AppendFormat(" {0} {1} {2}", item.field, ConvertToOp(item.op, item.type, item.data), groupOp);
                }
                if (filter.Length > 0)
                {
                    int length = groupOp.Length;
                    filter.Remove(filter.Length - length, length);
                }
                return filter.ToString();
            }
            return string.Empty;
        }

        private string ConvertToOp(string op, string type, string data)
        {
            string value = string.Empty;
            switch (type)
            {
                case "string":
                    switch (op)
                    {
                        case "eq": value = string.Format("= '{0}'", data); break;
                        case "ne": value = string.Format("<> '{0}'", data); break;
                        //case "lt": value = string.Format("< '{0}'", data); break;
                        //case "le": value = string.Format("<= '{0}'", data); break;
                        //case "gt": value = string.Format("> '{0}'", data); break;
                        //case "ge": value = string.Format(">= '{0}'", data); break;
                        case "bw": value = string.Format("LIKE '%{0}'", data); break;
                        case "bn": value = string.Format("NOT LIKE '%{0}'", data); break;
                        case "ew": value = string.Format("LIKE '{0}%'", data); break;
                        case "en": value = string.Format("NOT LIKE '{0}%'", data); break;
                        case "cn": value = string.Format("LIKE '%{0}%'", data); break;
                        case "nc": value = string.Format("NOT LIKE '%{0}%'", data); break;
                        case "nu": value = "IS NULL"; break;
                        case "nn": value = "IS NOT NULL"; break;
                    }
                    break;
                case "datatime":
                    break;
                case "int32":
                case "int64":
                case "int16":
                    switch (op)
                    {
                        case "eq": value = string.Format("= {0}", data); break;
                        case "ne": value = string.Format("<> {0}", data); break;
                        case "lt": value = string.Format("< {0}", data); break;
                        case "le": value = string.Format("<= {0}", data); break;
                        case "gt": value = string.Format("> {0}", data); break;
                        case "ge": value = string.Format(">= {0}", data); break;
                        case "in": value = string.Format("IN {1}{0}{2}", "{", data, "}"); break;
                        case "ni": value = string.Format("NOT IN {1}{0}{2}", "{", data, "}"); break;
                    }
                    break;
                default:
                    throw new ApplicationException("未知类型：" + type);
            }
            return value;
        }
    }

    public class rules
    {
        public string field { get; set; }
        public string op { get; set; }
        public string data { get; set; }
        public string type { get; set; }
    }
    /*
     {"name": "eq", "description": "equal", "operator":"="},
			{"name": "ne", "description": "not equal", "operator":"<>"},
			{"name": "lt", "description": "less", "operator":"<"},
			{"name": "le", "description": "less or equal","operator":"<="},
			{"name": "gt", "description": "greater", "operator":">"},
			{"name": "ge", "description": "greater or equal", "operator":">="},
			{"name": "bw", "description": "begins with", "operator":"LIKE"},
			{"name": "bn", "description": "does not begin with", "operator":"NOT LIKE"},
			{"name": "in", "description": "in", "operator":"IN"},
			{"name": "ni", "description": "not in", "operator":"NOT IN"},
			{"name": "ew", "description": "ends with", "operator":"LIKE"},
			{"name": "en", "description": "does not end with", "operator":"NOT LIKE"},
			{"name": "cn", "description": "contains", "operator":"LIKE"},
			{"name": "nc", "description": "does not contain", "operator":"NOT LIKE"},
			{"name": "nu", "description": "is null", "operator":"IS NULL"},
			{"name": "nn", "description": "is not null", "operator":"IS NOT NULL"}
     */

}
