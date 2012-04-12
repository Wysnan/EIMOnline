using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Business.Framework
{
    public class SystemInitialization
    {
        public SystemInitialization()
        {
            Load();
        }

        protected virtual void Load()
        {
            GlobalEntity.Instance.Cache_JqGrid.LoadData();
        }

        public void Reload()
        {

        }

        internal List<Wysnan.EIMOnline.Common.Poco.SecurityUser> a { get; set; }
    }
}
