using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Injection.JqGrid
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ListAttribute : Attribute
    {
    }
}