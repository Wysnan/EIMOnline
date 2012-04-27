using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.Business.Framework
{
    public sealed class SystemInitialization
    {
        private SystemInitialization() { }

        //Application_Start 
        public static void Application_Start()
        {
            //初始化grid
            GlobalEntity.Instance.Cache_JqGrid.LoadData();
        }

        //Session_Start
        public static void Session_Start()
        {
            SystemEntity systemEntity = new SystemEntity();
            HttpContext.Current.Session[ConstEntity.Session_SystemEntity] = systemEntity;
        }
    }
}
