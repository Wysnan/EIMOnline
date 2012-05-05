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
    public sealed class Cache_SystemModuleType : ICache
    {
        #region 单态
        static readonly Cache_SystemModuleType instance = new Cache_SystemModuleType();

        public static Cache_SystemModuleType Instance
        {
            get { return instance; }
        }

        private Cache_SystemModuleType()
        {
            SystemModuleTypeModel = GlobalEntity.Instance.ApplicationContext.GetObject("SystemModuleTypeModel") as ISystemModuleType;
        }
        #endregion

        #region
        private string CacheKey = ConstEntity.Cache_DB_SystemModuleType;

        #endregion

        #region 属性

        public ISystemModuleType SystemModuleTypeModel { get; set; }

        private object objModel { get; set; }

        public IList<SystemModuleType> SystemModuleTypes
        {
            get
            {
                objModel = CacheModel.GetCache(CacheKey);
                if (objModel == null)
                {
                    LoadData();
                }
                return objModel as IList<SystemModuleType>;
            }
            private set { }
        }

        #endregion


        public void LoadData()
        {
            objModel = CacheModel.GetCache(CacheKey);
            if (objModel == null)
            {
                objModel = SystemModuleTypeModel.All().ToList();
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
