using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.EF.Mapping
{
    public class SecurityUserMap : EntityTypeConfiguration<SecurityUser>
    {
        public SecurityUserMap()
        {
            this.Property(t => t.UserName)
                .IsOptional()
                .HasMaxLength(50);

            this.Property(t => t.UserLoginID)
                .IsOptional()
                .HasMaxLength(50);

            this.Property(t => t.UserLoginPwd)
                .IsOptional()
                .HasMaxLength(50);
        }
    }
}
