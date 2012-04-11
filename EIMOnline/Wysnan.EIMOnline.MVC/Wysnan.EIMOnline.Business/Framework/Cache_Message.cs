using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Business.Framework
{
    public sealed class Cache_Message : ICache
    {
        static readonly Cache_Message instance = new Cache_Message();

        public static Cache_Message Instance
        {
            get { return instance; }
        }

        public Dictionary<string, string> Message { get; set; }

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
