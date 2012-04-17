namespace Wysnan.EIMOnline.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AllTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SecurityUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UserName = c.String(),
                        UserLoginID = c.String(),
                        UserLoginPwd = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "OperateLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        OperateLogInfo = c.String(),
                        OperateDate = c.DateTime(nullable: false),
                        SecurityUserId_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SecurityUser", t => t.SecurityUserId_ID)
                .Index(t => t.SecurityUserId_ID);
            
            CreateTable(
                "SecurityUserRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        SecurityUserID = c.Int(nullable: false),
                        SecurityRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SecurityUser", t => t.SecurityUserID)
                .ForeignKey("SecurityRole", t => t.SecurityRoleID)
                .Index(t => t.SecurityUserID)
                .Index(t => t.SecurityRoleID);
            
            CreateTable(
                "SecurityRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
            DropIndex("SecurityUserRole", new[] { "SecurityRoleID" });
            DropIndex("SecurityUserRole", new[] { "SecurityUserID" });
            DropIndex("OperateLog", new[] { "SecurityUserId_ID" });
            DropForeignKey("PersonnelAttendance", "SecurityUserID", "SecurityUser");
            DropForeignKey("SecurityUserRole", "SecurityRoleID", "SecurityRole");
            DropForeignKey("SecurityUserRole", "SecurityUserID", "SecurityUser");
            DropForeignKey("OperateLog", "SecurityUserId_ID", "SecurityUser");
            DropTable("PersonnelAttendance");
            DropTable("SecurityRole");
            DropTable("SecurityUserRole");
            DropTable("OperateLog");
            DropTable("SecurityUser");
        }
    }
}
