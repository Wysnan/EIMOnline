using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.EF.Mapping
{
    public class zMetaFormLayoutMap : EntityTypeConfiguration<zMetaFormLayout>
    {
        public zMetaFormLayoutMap()
        {
            this.HasKey(t => t.ID);

            this.Property(t => t.EntityName)
                .IsRequired()
                .HasMaxLength(50);


            this.Property(t => t.EntityField)
              .IsRequired()
              .HasMaxLength(50);

            this.Property(t => t.ShortLabel)
              .IsRequired()
              .HasMaxLength(50);

            this.Property(t => t.LongLabel)
                .IsRequired();

            this.Property(t => t.IsVisible)
                .IsRequired();

            this.Property(t => t.ReferenceEntity)
              .IsOptional()
              .HasMaxLength(100);

            this.Property(t => t.SortNum)
                .IsRequired().HasColumnType("Int");

            this.Property(t => t.ReferenceEntityUrl)
                .IsOptional()
                .HasMaxLength(200);

            this.Property(t => t.Brief)
                .IsOptional()
                .HasMaxLength(100);
        }
    }
}
