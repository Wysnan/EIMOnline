using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Enum;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Business.Framework.Cache;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.Business.Framework
{
    public sealed class Cache_JqGrid : ICache
    {
        static readonly Cache_JqGrid instance = new Cache_JqGrid();

        public static Cache_JqGrid Instance
        {
            get { return instance; }
        }

        public Cache_JqGrid()
        {
            LoadData();
        }

        string CacheKey =ConstEntity.Cache_JqGrid;

        #region 属性

        private object objModel { get; set; }

        public Dictionary<GridEnum, JqGrid> JqGrids
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
            objModel = CacheModel.GetCache(CacheKey);
            if (objModel == null)
            {
                objModel = GridModel.Instance.JqGrids;
                if (objModel != null)
                {
                    CacheModel.SetCache(CacheKey, objModel);
                }
            }
        }

        public void ReLoadData()
        {
            throw new NotImplementedException();
        }

    }
}
