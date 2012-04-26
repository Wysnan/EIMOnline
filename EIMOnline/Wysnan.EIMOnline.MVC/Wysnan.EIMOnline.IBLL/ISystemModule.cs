using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.ViewModel;
using System.Linq;

namespace Wysnan.EIMOnline.IBLL
{
    public interface ISystemModule : IBusinessLogicModel<SystemModule>, IBusinessLogicModelEx<CombinedSystemModule>
    {
        IQueryable<SystemModule> GetSecuritySystemModule();
    }
}
