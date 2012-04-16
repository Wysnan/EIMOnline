using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Business.Framework.Cache;

namespace Wysnan.EIMOnline.Business.Framework.Cache
{
    public sealed class Cache_Message : ICache
    {
        static readonly Cache_Message instance = new Cache_Message();
        public static Cache_Message Instance
        {
            get { return instance; }
        }
        string CacheKey = ConstEntity.Cache_Message;

        /// <summary>
        /// 从新加载
        /// </summary>
        private object objModel { get; set; }

        /// <summary>
        /// 存储消息的字典
        /// </summary>
        public Dictionary<string, string> Message
        {
            get
            {
                objModel = CacheModel.GetCache(CacheKey);
                if (objModel == null)
                {
                    LoadData();
                }
                return (Dictionary<string, string>)objModel;
            }
            private set { }
        }

        /// <summary>
        /// 根据code获取消息
        /// </summary>
        /// <param name="code">消息标示</param>
        /// <returns></returns>
        public string GetMessge(string code)
        {
            if (!Message.ContainsKey(code))
            {
                throw new ArgumentException("消息定义错误，code无效");
            }
            return Message[code];
        }

        /// <summary>
        /// 向缓存中加载数据
        /// </summary>
        public void LoadData()
        {
            objModel = CacheModel.GetCache(CacheKey);
            if (objModel == null)
            {
                objModel = MessageModel.Instance.DicMessage;
                if (objModel != null)
                {
                    CacheModel.SetCache(CacheKey, objModel);
                }
            }
        }

        /// <summary>
        /// 从新加载数据
        /// </summary>
        public void ReLoadData()
        {
            MessageModel.Instance.Reload();
            objModel = MessageModel.Instance.DicMessage;
            if (objModel != null)
            {
                CacheModel.SetCache(CacheKey, objModel);
            }
        }
    }
}
