using Wysnan.EIMOnline.Common.Poco;
using System.Data.Entity.ModelConfiguration;

namespace Wysnan.EIMOnline.EF.Mapping
{
    public class OperateLogMap : EntityTypeConfiguration<OperateLog>
    {
        private OperateLogMap()
        {
            this.HasOptional(t => t.SecurityUser)
                .WithMany(s => s.OperateLogs)
                .HasForeignKey(o => o.SecurityUserId);
        }
    }
}
