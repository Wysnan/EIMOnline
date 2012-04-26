using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Common.Framework.Enum;

namespace Wysnan.EIMOnline.Business.Framework.Cache
{
   public sealed class Cache_JqGridHtml: ICache
   {
        static readonly Cache_JqGridHtml instance = new Cache_JqGridHtml();

        public static Cache_JqGridHtml Instance
        {
            get { return instance; }
        }

        private Cache_JqGridHtml()
        {
            LoadData();
        }

        public void LoadData()
        {
            throw new NotImplementedException();
        }

        public void ReLoadData()
        {
            throw new NotImplementedException();
        }
   }
}
