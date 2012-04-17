namespace Wysnan.EIMOnline.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropIndex("OperateLog", new[] { "SecurityUserId_ID" });
            DropForeignKey("OperateLog", "SecurityUserId_ID", "SecurityUser");
            DropTable("OperateLog");
        }
    }
}
