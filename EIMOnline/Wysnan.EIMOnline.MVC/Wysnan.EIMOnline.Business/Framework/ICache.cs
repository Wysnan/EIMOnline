using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Business.Framework
{
    public interface ICache
    {
        void LoadData();

        void ReLoadData();
    }
}
