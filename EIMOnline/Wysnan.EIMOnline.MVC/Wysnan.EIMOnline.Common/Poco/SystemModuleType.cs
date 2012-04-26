using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Wysnan.EIMOnline.Common.Poco
{
    public class SystemModuleType : IBaseEntity
    {
        public SystemModuleType()
        {
            this.SystemModules =new List<SystemModule>();
            this.SystemPermissions = new List<SystemPermission>();
        }
        public int ID { get; set; }

        public byte? SystemStatus { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public string Area { get; set; }
        public string ModuleTypeName { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<SystemModule> SystemModules { get; set; }
        public virtual ICollection<SystemPermission> SystemPermissions { get; set; }
    }
}
