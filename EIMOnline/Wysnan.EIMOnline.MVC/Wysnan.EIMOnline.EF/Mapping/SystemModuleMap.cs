using System.Data.Entity.ModelConfiguration;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.EF.Mapping
{
    public class SystemModuleMap : EntityTypeConfiguration<SystemModule>
    {
        public SystemModuleMap()
        {
            this.Property(t => t.ControllerModule)
                .IsOptional()
                .HasMaxLength(20);

            this.Property(t => t.ModuleName)
                .IsOptional()
                .HasMaxLength(30);

            this.Property(t => t.ModuleMainUrl)
                .IsOptional()
                .HasMaxLength(100);

            this.HasOptional(t => t.ModuleType)
                .WithMany(s => s.SystemModules)
                .HasForeignKey(o => o.ModuleTypeId);

        }
    }
}
