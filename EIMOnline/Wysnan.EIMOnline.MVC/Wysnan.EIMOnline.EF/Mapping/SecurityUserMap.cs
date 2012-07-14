using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.EF.Mapping
{
    class SecurityUserMap : EntityTypeConfiguration<SecurityUser>
    {
        public SecurityUserMap()
        {
            this.HasOptional(t => t.CreatedByUser)
                .WithMany(s => s.SecurityUsers1)
                .HasForeignKey(o => o.CreatedByUserID);

            this.HasOptional(t => t.ModifiedByUser)
                .WithMany(s => s.SecurityUsers2)
                .HasForeignKey(o => o.ModifiedByUserID);

            this.Property(a => a.Code).IsUnicode(false);

            this.Property(a => a.UserLoginID).IsUnicode(false);

            this.HasRequired(t => t.LookupSex)
                .WithMany(s => s.SecurityUsers1)
                .HasForeignKey(o => o.Sex);

            this.Property(a => a.CertificateNo).IsUnicode(false);
            this.Property(a => a.Phone).IsUnicode(false);
            this.Property(a => a.Email).IsUnicode(false);
            this.Property(a => a.UrgentPhone).IsUnicode(false);
            this.Property(a => a.Mobile).IsUnicode(false);

            this.HasRequired(t => t.MarriageStatus)
                .WithMany(s => s.SecurityUsers2)
                .HasForeignKey(o => o.MarriageStatusID);

            this.HasRequired(t => t.CultureStatus)
                .WithMany(s => s.SecurityUsers3)
                .HasForeignKey(o => o.CultureStatusID);

            this.HasRequired(t => t.StaffCategory)
                .WithMany(s => s.SecurityUsers4)
                .HasForeignKey(o => o.StaffCategoryID);

            this.HasRequired(t => t.Status)
                .WithMany(s => s.SecurityUsers5)
                .HasForeignKey(o => o.StatusID);
        }
    }
}
