using System.Data.Entity.ModelConfiguration;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.EF.Mapping
{
    public class SystemModuleTypeMap : EntityTypeConfiguration<SystemModuleType>
    {
        public SystemModuleTypeMap()
        {
            this.Property(t => t.Area)
                .IsOptional()
                .HasMaxLength(30);
            this.Property(t => t.ModuleTypeName)
                .IsOptional()
                .HasMaxLength(30);

        }
    }
}
