namespace Wysnan.EIMOnline.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Reimbursement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Reimbursement",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Code = c.String(nullable: false, maxLength: 10),
                        TypeCode = c.Int(nullable: false),
                        ApplicantID = c.Int(nullable: false),
                        ApproverID = c.Int(nullable: false),
                        ApproveStatusID = c.Int(nullable: false),
                        Notes = c.Int(nullable: false),
                        ApproveResultID = c.Int(),
                        FinanceNotes = c.Int(nullable: false),
                        FinanceApproveResultID = c.Int(),
                        Remark = c.String(maxLength: 200),
                        SystemStatus = c.Byte(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("zMetaLookup", t => t.ApproveStatusID)
                .ForeignKey("zMetaLookup", t => t.ApproveResultID)
                .ForeignKey("zMetaLookup", t => t.FinanceApproveResultID)
                .ForeignKey("ReimbursementType", t => t.TypeCode)
                .ForeignKey("SecurityUser", t => t.ApplicantID)
                .ForeignKey("SecurityUser", t => t.ApproverID)
                .Index(t => t.ApproveStatusID)
                .Index(t => t.ApproveResultID)
                .Index(t => t.FinanceApproveResultID)
                .Index(t => t.TypeCode)
                .Index(t => t.ApplicantID)
                .Index(t => t.ApproverID);
            Sql("EXEC Proc_EntityActionURLCreate 'Reimbursement','Reimbursement'");
            Sql("Exec Proc_InitialView 'Reimbursement'");
        }
        
        public override void Down()
        {
            DropIndex("Reimbursement", new[] { "ApproverID" });
            DropIndex("Reimbursement", new[] { "ApplicantID" });
            DropIndex("Reimbursement", new[] { "TypeCode" });
            DropIndex("Reimbursement", new[] { "FinanceApproveResultID" });
            DropIndex("Reimbursement", new[] { "ApproveResultID" });
            DropIndex("Reimbursement", new[] { "ApproveStatusID" });
            DropForeignKey("Reimbursement", "ApproverID", "SecurityUser");
            DropForeignKey("Reimbursement", "ApplicantID", "SecurityUser");
            DropForeignKey("Reimbursement", "TypeCode", "ReimbursementType");
            DropForeignKey("Reimbursement", "FinanceApproveResultID", "zMetaLookup");
            DropForeignKey("Reimbursement", "ApproveResultID", "zMetaLookup");
            DropForeignKey("Reimbursement", "ApproveStatusID", "zMetaLookup");
            DropTable("Reimbursement");
        }
    }
}
