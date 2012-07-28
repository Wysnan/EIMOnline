using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using Wysnan.EIMOnline.Common.Poco;


namespace Wysnan.EIMOnline.EF.Mapping
{
    public class ReimbursementMap : EntityTypeConfiguration<Reimbursement>
    {
        public ReimbursementMap()
        {
            this.HasKey(t => t.ID);

            this.Property(t => t.ApproveResultID)
                .IsOptional();

            this.Property(t => t.FinanceApproveResultID)
               .IsOptional();

            this.HasRequired(t => t.ReimbursementType)
                .WithMany(t => t.Reimbursements)
                .HasForeignKey(f => f.TypeCode);

            this.HasRequired(t => t.SecurityUserApplicant)
                .WithMany(t => t.Reimbursements)
                .HasForeignKey(f => f.ApplicantID);

            this.HasRequired(t => t.SecurityUserApprover)
                .WithMany(t => t.Reimbursements1)
                .HasForeignKey(f => f.ApproverID);

            this.HasOptional(t => t.ApproverResult)
                .WithMany(t => t.Reimbursements)
                .HasForeignKey(f => f.ApproveResultID);

            this.HasOptional(t => t.FinanceApproverResult)
                 .WithMany(t => t.Reimbursements1)
                 .HasForeignKey(f => f.FinanceApproveResultID);

            this.HasRequired(t => t.ApproverStatus)
                .WithMany(t => t.Reimbursements2)
                .HasForeignKey(f => f.ApproveStatusID);
        }
    }
}
