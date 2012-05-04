using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.IO;

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

        /// <summary>
        /// 添加文件依赖缓存
        /// </summary>
        /// <param name="cacheKey">缓存键</param>
        /// <param name="obj">缓存对象</param>
        /// <param name="filePath">依赖文件</param>
        public static void SetFileDenpendencyCahce(string cacheKey, Object objName, string filePath)
        {
            if (File.Exists(filePath))
            {
                using (CacheDependency fileDependency = new CacheDependency(filePath))
                {
                    HttpRuntime.Cache.Insert(cacheKey, objName, fileDependency);
                }
            }
            else
            {
                throw new ArgumentException("没有找到需要要缓存的文件");
            }
        }

        /// <summary>
        /// SqlServer依赖缓存(v2005以上包括)
        /// </summary>
        /// <param name="cacheKey">web.config文件中配置的缓存键</param>
        /// <param name="objName"></param>
        public static void SetSqlDenpendencyCahce(string cacheKey, object obj, string cacheTableName)
        {
            if (obj != null)
            {
                using (CacheDependency fileDependency = new SqlCacheDependency(cacheKey, cacheTableName))
                {
                    HttpRuntime.Cache.Insert(cacheKey, obj, fileDependency);
                }
            }
        }
    }
}
