namespace Wysnan.EIMOnline.EF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AllTable : DbMigration
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
                "SystemModuleDetailPage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        DetailPageTitle = c.String(),
                        DetailPageAction = c.String(),
                        DetailPageUrl = c.String(),
                        ParentID = c.Int(nullable: false),
                        SystemModuleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SystemModule", t => t.SystemModuleID)
                .Index(t => t.SystemModuleID);

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
                        RoleID = c.Int(nullable: false),
                        SystemModuleDetailPage_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SystemModule", t => t.SystemModuleID)
                .ForeignKey("SystemModuleType", t => t.SystemModuleTypeID)
                .ForeignKey("SystemModuleDetailPage", t => t.SystemModuleDetailPage_ID)
                .Index(t => t.SystemModuleID)
                .Index(t => t.SystemModuleTypeID)
                .Index(t => t.SystemModuleDetailPage_ID);

            CreateTable(
                "zMetaFormLayout",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntityName = c.String(nullable: false, maxLength: 50),
                        EntityField = c.String(nullable: false, maxLength: 50),
                        ShortLabel = c.String(nullable: false, maxLength: 50),
                        LongLabel = c.String(nullable: false),
                        IsVisible = c.Boolean(nullable: false),
                        ReferenceEntity = c.String(maxLength: 100),
                        SortNum = c.Int(nullable: false),
                        ReferenceEntityUrl = c.String(maxLength: 200),
                        Brief = c.String(maxLength: 100),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);

            MigrationsHelp.InitDB(Sql);

            Sql("Exec Proc_InitionViewTab 'SecurityUser'");
        }

        public override void Down()
        {
            DropIndex("SystemPermission", new[] { "SystemModuleDetailPage_ID" });
            DropIndex("SystemPermission", new[] { "SystemModuleTypeID" });
            DropIndex("SystemPermission", new[] { "SystemModuleID" });
            DropIndex("SystemModuleDetailPage", new[] { "SystemModuleID" });
            DropIndex("SystemModule", new[] { "ModuleTypeId" });
            DropIndex("PersonnelAttendance", new[] { "SecurityUserID" });
            DropIndex("SecurityUserRole", new[] { "SecurityRoleID" });
            DropIndex("SecurityUserRole", new[] { "SecurityUserID" });
            DropIndex("OperateLog", new[] { "SecurityUserId_ID" });
            DropForeignKey("SystemPermission", "SystemModuleDetailPage_ID", "SystemModuleDetailPage");
            DropForeignKey("SystemPermission", "SystemModuleTypeID", "SystemModuleType");
            DropForeignKey("SystemPermission", "SystemModuleID", "SystemModule");
            DropForeignKey("SystemModuleDetailPage", "SystemModuleID", "SystemModule");
            DropForeignKey("SystemModule", "ModuleTypeId", "SystemModuleType");
            DropForeignKey("PersonnelAttendance", "SecurityUserID", "SecurityUser");
            DropForeignKey("SecurityUserRole", "SecurityRoleID", "SecurityRole");
            DropForeignKey("SecurityUserRole", "SecurityUserID", "SecurityUser");
            DropForeignKey("OperateLog", "SecurityUserId_ID", "SecurityUser");
            DropTable("zMetaFormLayout");
            DropTable("SystemPermission");
            DropTable("SystemModuleDetailPage");
            DropTable("SystemModule");
            DropTable("SystemModuleType");
            DropTable("PersonnelAttendance");
            DropTable("SecurityRole");
            DropTable("SecurityUserRole");
            DropTable("OperateLog");
            DropTable("SecurityUser");
        }
    }
}
