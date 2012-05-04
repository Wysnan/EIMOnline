using System.Data.Entity.ModelConfiguration;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.EF.Mapping
{
    public class SystemPermissionMap : EntityTypeConfiguration<SystemPermission>
    {
        public SystemPermissionMap()
        {
            this.HasOptional(t => t.SystemModuleType)
                .WithMany(s => s.SystemPermissions)
                .HasForeignKey(o => o.SystemModuleTypeID);

            this.HasOptional(t => t.SystemModule)
                .WithMany(s => s.SystemPermissions)
                .HasForeignKey(o => o.SystemModuleID);

            this.HasOptional(t => t.SystemModuleDetailPage)
                .WithMany(s => s.SystemPermissions)
                .HasForeignKey(o => o.SystemModulDatailPageID);

            this.HasOptional(t => t.SecurityRole)
                .WithMany(s => s.SystemPermissions)
                .HasForeignKey(o => o.RoleID);
        }
    }
}
