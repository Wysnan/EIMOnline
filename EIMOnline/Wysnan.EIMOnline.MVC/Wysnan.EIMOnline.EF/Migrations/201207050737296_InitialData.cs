namespace Wysnan.EIMOnline.EF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialData : DbMigration
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
                        SecurityUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SecurityUser", t => t.SecurityUserId)
                .Index(t => t.SecurityUserId);

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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SystemModule", t => t.SystemModuleID)
                .ForeignKey("SystemModuleType", t => t.SystemModuleTypeID)
                .ForeignKey("SystemModuleDetailPage", t => t.SystemModulDatailPageID)
                .ForeignKey("SecurityRole", t => t.RoleID)
                .Index(t => t.SystemModuleID)
                .Index(t => t.SystemModuleTypeID)
                .Index(t => t.SystemModulDatailPageID)
                .Index(t => t.RoleID);

            CreateTable(
                "SystemModule",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ControllerModule = c.String(maxLength: 20),
                        ModuleName = c.String(maxLength: 30),
                        SortOrder = c.Int(nullable: false),
                        ModuleMainUrl = c.String(maxLength: 100),
                        ImageUrl = c.String(),
                        ModuleTypeId = c.Int(),
                        ParentSystemModuleID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SystemModuleType", t => t.ModuleTypeId)
                .ForeignKey("SystemModule", t => t.ParentSystemModuleID)
                .Index(t => t.ModuleTypeId)
                .Index(t => t.ParentSystemModuleID);

            CreateTable(
                "SystemModuleType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Area = c.String(maxLength: 30),
                        ModuleTypeName = c.String(maxLength: 30),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "SystemModuleDetailPage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        DetailPageTitle = c.String(maxLength: 30),
                        DetailPageAction = c.String(maxLength: 20),
                        DetailPageUrl = c.String(maxLength: 100),
                        SystemModuleID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SystemModule", t => t.SystemModuleID)
                .Index(t => t.SystemModuleID);

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
                        IsPunchCard = c.Boolean(nullable: false),
                        TestLookupID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SecurityUser", t => t.SecurityUserID)
                .ForeignKey("zMetaLookup", t => t.TestLookupID)
                .Index(t => t.SecurityUserID)
                .Index(t => t.TestLookupID);

            CreateTable(
                "zMetaLookup",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(),
                        Name = c.String(maxLength: 20),
                        Code = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);

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

            //MigrationsHelp.InitDB(Sql);
            //Sql("Exec Proc_InitialView 'SecurityUser'");
            //Sql("Exec Proc_InitialView 'PersonnelAttendance'");

        }

        public override void Down()
        {
            DropIndex("PersonnelAttendance", new[] { "TestLookupID" });
            DropIndex("PersonnelAttendance", new[] { "SecurityUserID" });
            DropIndex("SystemModuleDetailPage", new[] { "SystemModuleID" });
            DropIndex("SystemModule", new[] { "ParentSystemModuleID" });
            DropIndex("SystemModule", new[] { "ModuleTypeId" });
            DropIndex("SystemPermission", new[] { "RoleID" });
            DropIndex("SystemPermission", new[] { "SystemModulDatailPageID" });
            DropIndex("SystemPermission", new[] { "SystemModuleTypeID" });
            DropIndex("SystemPermission", new[] { "SystemModuleID" });
            DropIndex("SecurityUserRole", new[] { "SecurityRoleID" });
            DropIndex("SecurityUserRole", new[] { "SecurityUserID" });
            DropIndex("OperateLog", new[] { "SecurityUserId" });
            DropForeignKey("PersonnelAttendance", "TestLookupID", "zMetaLookup");
            DropForeignKey("PersonnelAttendance", "SecurityUserID", "SecurityUser");
            DropForeignKey("SystemModuleDetailPage", "SystemModuleID", "SystemModule");
            DropForeignKey("SystemModule", "ParentSystemModuleID", "SystemModule");
            DropForeignKey("SystemModule", "ModuleTypeId", "SystemModuleType");
            DropForeignKey("SystemPermission", "RoleID", "SecurityRole");
            DropForeignKey("SystemPermission", "SystemModulDatailPageID", "SystemModuleDetailPage");
            DropForeignKey("SystemPermission", "SystemModuleTypeID", "SystemModuleType");
            DropForeignKey("SystemPermission", "SystemModuleID", "SystemModule");
            DropForeignKey("SecurityUserRole", "SecurityRoleID", "SecurityRole");
            DropForeignKey("SecurityUserRole", "SecurityUserID", "SecurityUser");
            DropForeignKey("OperateLog", "SecurityUserId", "SecurityUser");
            DropTable("zMetaFormLayout");
            DropTable("zMetaLookup");
            DropTable("PersonnelAttendance");
            DropTable("SystemModuleDetailPage");
            DropTable("SystemModuleType");
            DropTable("SystemModule");
            DropTable("SystemPermission");
            DropTable("SecurityRole");
            DropTable("SecurityUserRole");
            DropTable("OperateLog");
            DropTable("SecurityUser");
        }
    }
}
