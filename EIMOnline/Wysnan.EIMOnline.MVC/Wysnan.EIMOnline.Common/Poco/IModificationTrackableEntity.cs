using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Common.Poco
{
    public interface IModificationTrackableEntity : IBaseEntity
    {
        int CreatedByUserID { get; set; }

        int ModifiedByUserID { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime ModifiedOn { get; set; }

        SecurityUser CreatedByUser { get; set; }

        SecurityUser ModifiedByUser { get; set; }
    }
}
