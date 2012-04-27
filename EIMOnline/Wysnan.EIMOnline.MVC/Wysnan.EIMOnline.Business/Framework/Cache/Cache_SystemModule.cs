using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.Business.Framework.Cache
{
    public sealed class Cache_SystemModule : ICache
    {
        static readonly Cache_SystemModule instance = new Cache_SystemModule();

        public static Cache_SystemModule Instance
        {
            get { return instance; }
        }

        private Cache_SystemModule() { }

        #region 属性

        private object objModel { get; set; }

        public IList<SystemModule> SystemModules
        {
            get
            {
                objModel = CacheModel.GetCache(CacheKey);
                if (objModel == null)
                {
                    LoadData();
                }
                return objModel as Dictionary<GridEnum, JqGrid>;
            }
            private set { }
        }

        #endregion


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
