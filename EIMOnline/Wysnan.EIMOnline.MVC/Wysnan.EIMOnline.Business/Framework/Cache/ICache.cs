using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Business.Framework.Cache
{
    public interface ICache
    {
        void LoadData();

        void ReLoadData();
    }
}
