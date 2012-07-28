using System.Data.Entity.ModelConfiguration;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.EF.Mapping
{
    public class SystemModuleDetailPageMap : EntityTypeConfiguration<SystemModuleDetailPage>
    {
        public SystemModuleDetailPageMap()
        {
            this.Property(t => t.DetailPageTitle)
                .IsOptional()
                .HasMaxLength(30);
            this.Property(t => t.DetailPageAction)
                .IsOptional()
                .HasMaxLength(20);
            this.Property(t => t.DetailPageUrl)
                .IsOptional()
                .HasMaxLength(100);


            this.HasOptional(t => t.SystemModule)
                .WithMany(o => o.SystemModuleDetailPages)
                .HasForeignKey(s => s.SystemModuleID);
         }
    }
}
