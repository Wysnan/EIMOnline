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
                    if (item.type != "datetime")
                    {
                        filter.AppendFormat(" {0} {1}", ConvertToOp(item.op, item.type, item.data, item.field), groupOp);
                    }
                }
                if (filter.Length > 0)
                {
                    int length = groupOp.Length;
                    filter.Remove(filter.Length - length, length);
                }
                return filter.ToString().Trim();
            }
            return string.Empty;
        }

        private string ConvertToOp(string op, string type, string data, string field)
        {
            string value = string.Empty;
            switch (type)
            {
                case "string":
                    switch (op)
                    {
                        case "eq": value = string.Format("{0}=\"{1}\"", field, data); break;
                        case "ne": value = string.Format("{0}<>\"{1}\"", data); break;
                        //case "lt": value = string.Format("< '{0}'", data); break;
                        //case "le": value = string.Format("<= '{0}'", data); break;
                        //case "gt": value = string.Format("> '{0}'", data); break;
                        //case "ge": value = string.Format(">= '{0}'", data); break;
                        case "bw": value = string.Format("{0}.StartsWith(\"{1}\")", data); break;
                        case "bn": value = string.Format("{0}.StartsWith(\"{1}\")==false", data); break;
                        case "ew": value = string.Format("{0}.EndsWith(\"{1}\")", data); break;
                        case "en": value = string.Format("{0}.EndsWith(\"{1}\")==false", data); break;
                        case "cn": value = string.Format("{0}.Contains(\"{1}\")", data); break;
                        case "nc": value = string.Format("{0}.Contains(\"{1}\")==false", data); break;
                        case "nu": value = " {0}== NULL"; break;
                        case "nn": value = " {0}<> NULL"; break;
                    }
                    break;
                case "datetime":
                    ////datetime datetime = datetime.now;
                    //////bool isok = datetime.parse(data, out datetime);
                    ////if (isok)
                    ////{
                    //switch (op)
                    //{
                    //    //it.d==cast('1977-11-11' as system.datetime)
                    //    case "eq": value = field + "= convert(\"datetime2\",'2012-04-19 00:00:00.0000000\' ,121)"; break;
                    //    //string.format("({0}.date=(cast(\'{1}\' as system.datetime)))", field.trim(), data); break;
                    //    //case "eq": value = string.format("({0}.date=(cast(\'{1}\' as system.datetime)))", field.trim(), data); break;
                    //    case "ne": value = string.Format("<>\"{0}\"", data); break;
                    //    case "lt": value = string.Format("<\"{0}\"", data); break;
                    //    case "le": value = string.Format("<=\"{0}\"", data); break;
                    //    case "gt": value = string.Format(">\"{0}\"", data); break;
                    //    case "ge": value = string.Format(">=\"{0}\"", data); break;
                    //}
                    ////}
                    break;
                case "int32":
                case "int64":
                case "int16":
                    switch (op)
                    {
                        case "eq": value = string.Format("{0}= {1}", field, data); break;
                        case "ne": value = string.Format("{0}<> {1}", field, data); break;
                        case "lt": value = string.Format("{0}< {1}", field, data); break;
                        case "le": value = string.Format("{0}<= {1}", field, data); break;
                        case "gt": value = string.Format("{0}> {1}", field, data); break;
                        case "ge": value = string.Format("{0}>= {1", field, data); break;
                        case "in":
                        case "ni":
                            string tempOp = "==";
                            string tempGroupOp = "or";
                            if (op == "ni")
                            {
                                tempOp = "<>";
                                tempGroupOp = "and";
                            }
                            string[] array = data.Split(',');
                            if (array != null && array.Length > 0)
                            {
                                value = "(";
                                foreach (var item in array)
                                {
                                    value += string.Format(" {0}{1}{2} {3}", field, tempOp, item, tempGroupOp);
                                }
                                value = value.Substring(0, value.Length - tempGroupOp.Length);
                                value += ")";
                            }
                            break;
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
