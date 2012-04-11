using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Wysnan.EIMOnline.Business.Framework.Cache
{
    public class CacheModel
    {
        private CacheModel() { }

        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache对象值
        /// </summary>
        /// <param name="CacheKey">索引键值</param>
        /// <returns>返回缓存对象</returns>
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache对象值
        /// </summary>
        /// <param name="CacheKey">索引键值</param>
        /// <param name="objObject">缓存对象</param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache对象值
        /// </summary>
        /// <param name="CacheKey">索引键值</param>
        /// <param name="objObject">缓存对象</param>
        /// <param name="absoluteExpiration">绝对过期时间</param>
        /// <param name="slidingExpiration">最后一次访问所插入对象时与该对象过期时之间的时间间隔</param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string CacheKey = "cachetest";
        //    object objModel = GetCache(CacheKey);//从缓存中获取
        //    if (objModel == null)//缓存里没有
        //    {
        //        objModel = DateTime.Now;//把当前时间进行缓存
        //        if (objModel != null)
        //        {
        //            int CacheTime = 30;//缓存时间30秒
        //            SetCache(CacheKey, objModel, DateTime.Now.AddSeconds(CacheTime), TimeSpan.Zero);//写入缓存
        //        }
        //    }
        //    Label1.Text = objModel.ToString();
        //}

    }
}
