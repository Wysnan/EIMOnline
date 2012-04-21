using System.ComponentModel.DataAnnotations;

namespace Wysnan.EIMOnline.Common.Poco
{
    public class SystemPermission : IBaseEntity
    {
        public SystemPermission()
        {
           
        }
        public int ID { get; set; }

        public byte? SystemStatus { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public int SystemModuleTypeID { get; set; }
        public int SystemModuleID { get; set; }
        public int SystemModulDatailPageID { get; set; }
        public int SystemActionID { get; set; }
        public int RoleID { get; set; }

        public virtual SystemModule SystemModule { get; set; }
        public virtual SystemModuleType SystemModuleType { get; set; }
        public virtual SystemModuleDetailPage SystemModuleDetailPage { get; set; }
        public virtual SystemAction SystemAction { get; set; }
    }
}
