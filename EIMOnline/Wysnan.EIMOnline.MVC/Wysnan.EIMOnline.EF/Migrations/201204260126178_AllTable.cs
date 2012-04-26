namespace Wysnan.EIMOnline.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AllTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SystemAction",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        SyAction = c.String(),
                        Value = c.String(),
                        Brief = c.String(),
                        SystemModuleDetailPageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SystemModuleDetailPage", t => t.SystemModuleDetailPageID)
                .Index(t => t.SystemModuleDetailPageID);
            
            CreateTable(
                "SystemModuleDetailPage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        DatailPageTitle = c.String(),
                        DetailPageAction = c.String(),
                        DetailPageUrl = c.String(),
                        ParentID = c.Int(nullable: false),
                        SystemModuleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SystemModule", t => t.SystemModuleID)
                .Index(t => t.SystemModuleID);
            
            CreateTable(
                "SystemModule",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ControllerModule = c.String(),
                        ModuleName = c.String(),
                        SortOrder = c.Int(nullable: false),
                        ModuleMainUrl = c.String(),
                        ModuleTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SystemModuleType", t => t.ModuleTypeId)
                .Index(t => t.ModuleTypeId);
            
            CreateTable(
                "SystemModuleType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Area = c.String(),
                        ModuleTypeName = c.String(),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "SystemPermission",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        SystemModuleTypeID = c.Int(nullable: false),
                        SystemModuleID = c.Int(nullable: false),
                        SystemModulDatailPageID = c.Int(nullable: false),
                        SystemActionID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        SystemModuleDetailPage_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SystemModule", t => t.SystemModuleID)
                .ForeignKey("SystemModuleType", t => t.SystemModuleTypeID)
                .ForeignKey("SystemModuleDetailPage", t => t.SystemModuleDetailPage_ID)
                .ForeignKey("SystemAction", t => t.SystemActionID)
                .Index(t => t.SystemModuleID)
                .Index(t => t.SystemModuleTypeID)
                .Index(t => t.SystemModuleDetailPage_ID)
                .Index(t => t.SystemActionID);
            
        }
        
        public override void Down()
        {
            DropIndex("SystemPermission", new[] { "SystemActionID" });
            DropIndex("SystemPermission", new[] { "SystemModuleDetailPage_ID" });
            DropIndex("SystemPermission", new[] { "SystemModuleTypeID" });
            DropIndex("SystemPermission", new[] { "SystemModuleID" });
            DropIndex("SystemModule", new[] { "ModuleTypeId" });
            DropIndex("SystemModuleDetailPage", new[] { "SystemModuleID" });
            DropIndex("SystemAction", new[] { "SystemModuleDetailPageID" });
            DropForeignKey("SystemPermission", "SystemActionID", "SystemAction");
            DropForeignKey("SystemPermission", "SystemModuleDetailPage_ID", "SystemModuleDetailPage");
            DropForeignKey("SystemPermission", "SystemModuleTypeID", "SystemModuleType");
            DropForeignKey("SystemPermission", "SystemModuleID", "SystemModule");
            DropForeignKey("SystemModule", "ModuleTypeId", "SystemModuleType");
            DropForeignKey("SystemModuleDetailPage", "SystemModuleID", "SystemModule");
            DropForeignKey("SystemAction", "SystemModuleDetailPageID", "SystemModuleDetailPage");
            DropTable("SystemPermission");
            DropTable("SystemModuleType");
            DropTable("SystemModule");
            DropTable("SystemModuleDetailPage");
            DropTable("SystemAction");
        }
    }
}
