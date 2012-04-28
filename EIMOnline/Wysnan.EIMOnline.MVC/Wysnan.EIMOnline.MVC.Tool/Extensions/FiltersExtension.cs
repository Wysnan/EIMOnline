using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Grid.Poco;

namespace Wysnan.EIMOnline.Tool.Extensions
{
    public static class FiltersExtension
    {
        public static IQueryable ConvertToIQueryable(this Filters filters, IQueryable query)
        {
            //query = query.Where("CreatedOn=@0", dt);
            if (filters != null && filters.rules != null && filters.rules.Count > 0)
            {
                StringBuilder value = null;
                var rules = filters.rules.Where(a => a.type == "datetime");
                object[] datas = null;
                if (rules != null&&rules.Count()>0)
                {
                    var list = rules.ToList();
                    value = new StringBuilder();
                    string op = null;
                    int length = list.Count;
                    datas = new object[length];
                    for (int i = 0; i < length; i++)
                    {
                        DateTime dt = DateTime.Parse(list[i].data);
                        op = ConvertToOpWithDateTime(list[i].op);
                        value.AppendFormat(" {0}{1}@{2} {3}", list[i].field, op, i, filters.groupOp);
                        datas[i] = dt;
                    }
                }

                rules = filters.rules.Where(a => a.type != "datetime");
                if (rules != null&&rules.Count() > 0)
                {
                    var list = rules.ToList();
                    if (value == null)
                    {
                        value = new StringBuilder();
                    }
                    foreach (var item in rules)
                    {
                        value.AppendFormat(" {0} {1}", ConvertToOp(item.op, item.type, item.data, item.field), filters.groupOp);
                    }
                }
                if (value != null && value.Length > 0)
                {
                    int length = filters.groupOp.Length;
                    value.Remove(value.Length - length, length);
                }
                if (value.Length > 0)
                {
                    string where = value.ToString().Trim();
                    if (where.Length > 0)
                    {
                        query = query.Where(value.ToString(), datas);
                    }
                }
            }
            return query;
        }
        private static string ConvertToOpWithDateTime(string op)
        {
            string value = string.Empty;
            switch (op)
            {
                case "eq": value = "="; break;
                case "ne": value = "<>"; break;
                case "lt": value = "<"; break;
                case "le": value = "<="; break;
                case "gt": value = ">"; break;
                case "ge": value = ">="; break;
            }
            return value;
        }

        private static string ConvertToOp(string op, string type, string data, string field)
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
}
