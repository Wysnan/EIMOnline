namespace Wysnan.EIMOnline.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UserRole : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropIndex("SecurityUserRole", new[] { "SecurityRoleID" });
            DropIndex("SecurityUserRole", new[] { "SecurityUserID" });
            DropForeignKey("SecurityUserRole", "SecurityRoleID", "SecurityRole");
            DropForeignKey("SecurityUserRole", "SecurityUserID", "SecurityUser");
            DropTable("SecurityRole");
            DropTable("SecurityUserRole");
            DropTable("SecurityUser");
        }
    }
}
