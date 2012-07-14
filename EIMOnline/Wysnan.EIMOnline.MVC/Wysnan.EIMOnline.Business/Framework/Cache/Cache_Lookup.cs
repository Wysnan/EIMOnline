using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.IBLL;
using Spring.Context;
using Spring.Context.Support;
using Wysnan.EIMOnline.Common.Enum;

namespace Wysnan.EIMOnline.Business.Framework.Cache
{
    public sealed class Cache_Lookup : ICache
    {
        #region 单态
        static readonly Cache_Lookup instance = new Cache_Lookup();

        public static Cache_Lookup Instance
        {
            get { return instance; }
        }

        private Cache_Lookup()
        {
            LookupModel = GlobalEntity.Instance.ApplicationContext.GetObject("LookupModel") as ILookupModel;
            InitLookupDictionary();
        }
        #endregion

        #region
        private string CacheKey = ConstEntity.Cache_DB_Lookup;

        #endregion

        #region 属性

        public ILookupModel LookupModel { get; set; }

        private object objModel { get; set; }

        public IList<Lookup> Lookups
        {
            get
            {
                objModel = CacheModel.GetCache(CacheKey);
                if (objModel == null)
                {
                    LoadData();
                }
                return objModel as IList<Lookup>;
            }
            private set { }
        }

        public Dictionary<LookupCodeEnum, List<Lookup>> LookupDictionary
        {
            get;
            private set;
        }

        #endregion


        public void LoadData()
        {
            objModel = CacheModel.GetCache(CacheKey);
            if (objModel == null)
            {
                objModel = LookupModel.List().ToList();
                if (objModel != null)
                {
                    Type t = typeof(Wysnan.EIMOnline.Common.Poco.Lookup);
                    CacheModel.SetCache(CacheKey, objModel);
                    //CacheModel.SetSqlDenpendencyCahce(CacheKey, objModel, t.Name);
                }
            }
        }

        public void ReLoadData()
        {
            throw new NotImplementedException();
        }

        private void InitLookupDictionary()
        {
            var list = Lookups.GroupBy(a => a.Code);
            if (LookupDictionary == null)
            {
                LookupDictionary = new Dictionary<LookupCodeEnum, List<Lookup>>();
            }
            foreach (var item in list)
            {
                LookupCodeEnum lookupCodeEnum;
                bool isok = Enum.TryParse(item.Key, out lookupCodeEnum);
                if (isok)
                {
                    LookupDictionary[lookupCodeEnum] = item.ToList();
                }
            }
        }
    }
}
