using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.IBLL;
using Spring.Context;
using Spring.Context.Support;

namespace Wysnan.EIMOnline.Business.Framework.Cache
{
    public sealed class Cache_SystemModule : ICache
    {
        #region 单态
        static readonly Cache_SystemModule instance = new Cache_SystemModule();

        public static Cache_SystemModule Instance
        {
            get { return instance; }
        }

        private Cache_SystemModule()
        {
            SystemModuleModel = GlobalEntity.Instance.ApplicationContext.GetObject("SystemModuleModel") as ISystemModule;
        }
        #endregion

        #region
        private string CacheKey = ConstEntity.Cache_DB_SystemModule;

        #endregion

        #region 属性

        public ISystemModule SystemModuleModel { get; set; }

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
                return objModel as IList<SystemModule>;
            }
            private set { }
        }

        #endregion


        public void LoadData()
        {
            objModel = CacheModel.GetCache(CacheKey);
            if (objModel == null)
            {
                objModel = SystemModuleModel.GetAllSystemModule_Greedy().ToList();
                if (objModel != null)
                {
                    Type t = typeof(Wysnan.EIMOnline.Common.Poco.SystemModule);
                    CacheModel.SetCache(CacheKey, objModel);
                    //CacheModel.SetSqlDenpendencyCahce(CacheKey, objModel, t.Name);
                }
            }
        }

        public void ReLoadData()
        {
            throw new NotImplementedException();
        }
    }
}
