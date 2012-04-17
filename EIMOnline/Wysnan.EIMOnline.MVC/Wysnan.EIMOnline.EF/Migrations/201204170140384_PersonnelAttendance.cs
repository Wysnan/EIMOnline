namespace Wysnan.EIMOnline.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class PersonnelAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "PersonnelAttendance",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        SecurityUserID = c.Int(nullable: false),
                        BeginWorkTime = c.DateTime(nullable: false),
                        EndWorkTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SecurityUser", t => t.SecurityUserID)
                .Index(t => t.SecurityUserID);
            
        }
        
        public override void Down()
        {
            DropIndex("PersonnelAttendance", new[] { "SecurityUserID" });
            DropForeignKey("PersonnelAttendance", "SecurityUserID", "SecurityUser");
            DropTable("PersonnelAttendance");
        }
    }
}
