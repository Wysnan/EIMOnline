using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Common.ViewModel;

namespace Wysnan.EIMOnline.IBLL
{
    public interface IBusinessLogicModelEx<T> where T : ICombined
    {
        IQueryable<T> ListCombined();
    }
}
