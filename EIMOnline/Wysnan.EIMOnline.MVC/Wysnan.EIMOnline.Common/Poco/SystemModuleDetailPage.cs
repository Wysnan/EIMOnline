using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Wysnan.EIMOnline.Common.Poco
{
    public class SystemModuleDetailPage : IBaseEntity
    {
        public SystemModuleDetailPage()
        {            
 			this.SystemActions = new List<SystemAction>();
            this.SystemPermissions = new List<SystemPermission>();

        }
        public int ID { get; set; }

        public byte? SystemStatus { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public string DetailPageTitle { get; set; }
        public string DetailPageAction { get; set; }
        public string DetailPageUrl { get; set; }
        public int ParentID { get; set; }
        public int? SystemModuleID { get; set; }

        public virtual SystemModule SystemModule { get; set; }

     
        public virtual ICollection<SystemPermission> SystemPermissions { get; set; }
    }
}
