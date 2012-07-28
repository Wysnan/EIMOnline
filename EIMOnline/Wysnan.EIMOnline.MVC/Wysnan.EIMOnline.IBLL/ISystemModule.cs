using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.ViewModel;
using System.Linq;

namespace Wysnan.EIMOnline.IBLL
{
    public interface ISystemModule : IBusinessLogicModel<SystemModule>
    {
        #region 数据库查询

        IQueryable<SystemModule> GetSecuritySystemModule();

        IQueryable<SystemModule> GetAllSystemModule_Greedy();

        #endregion
    }
}
