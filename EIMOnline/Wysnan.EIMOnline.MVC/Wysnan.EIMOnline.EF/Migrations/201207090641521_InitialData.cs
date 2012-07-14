namespace Wysnan.EIMOnline.EF.Migrations
{
    using System.Data.Entity.Migrations;
    using Wysnan.EIMOnline.Common.Poco;
    using System.Collections.Generic;
    using Wysnan.EIMOnline.Common.Enum;

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
                        CreatedOn = c.DateTime(nullable: false),
                        CreatedByUserID = c.Int(nullable: false),
                        ModifiedByUserID = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Code = c.String(nullable: false, maxLength: 10, unicode: false),
                        UserName = c.String(nullable: false, maxLength: 10),
                        UserNameEn = c.String(maxLength: 15),
                        UserLoginID = c.String(nullable: false, maxLength: 15, unicode: false),
                        UserLoginPwd = c.String(nullable: false, maxLength: 15),
                        Sex = c.Int(nullable: false),
                        Country = c.String(nullable: false, maxLength: 20),
                        Birthplace = c.String(nullable: false, maxLength: 30),
                        Birthday = c.DateTime(nullable: false),
                        CertificateNo = c.String(nullable: false, maxLength: 30, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 15, unicode: false),
                        Email = c.String(nullable: false, maxLength: 30, unicode: false),
                        UrgentName = c.String(nullable: false, maxLength: 20),
                        UrgentPhone = c.String(nullable: false, maxLength: 20, unicode: false),
                        Mobile = c.String(nullable: false, maxLength: 20, unicode: false),
                        MarriageStatusID = c.Int(nullable: false),
                        HomeAddress = c.String(maxLength: 50),
                        CultureStatusID = c.Int(nullable: false),
                        EducationalInstitute = c.String(maxLength: 25),
                        Professional = c.String(maxLength: 25),
                        GraduationTime = c.DateTime(),
                        StaffCategoryID = c.Int(nullable: false),
                        Resume = c.String(maxLength: 400),
                        StatusID = c.Int(nullable: false),
                        VacationDays = c.Int(nullable: false),
                        RemainingVacationDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SecurityUser", t => t.CreatedByUserID)
                .ForeignKey("SecurityUser", t => t.ModifiedByUserID)
                .ForeignKey("zMetaLookup", t => t.Sex)
                .ForeignKey("zMetaLookup", t => t.MarriageStatusID)
                .ForeignKey("zMetaLookup", t => t.CultureStatusID)
                .ForeignKey("zMetaLookup", t => t.StaffCategoryID)
                .ForeignKey("zMetaLookup", t => t.StatusID)
                .Index(t => t.CreatedByUserID)
                .Index(t => t.ModifiedByUserID)
                .Index(t => t.Sex)
                .Index(t => t.MarriageStatusID)
                .Index(t => t.CultureStatusID)
                .Index(t => t.StaffCategoryID)
                .Index(t => t.StatusID);

            CreateTable(
                "zMetaLookup",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Byte(),
                        TimeStamp = c.Binary(),
                        Name = c.String(maxLength: 30),
                        Code = c.String(maxLength: 30),
                        EnumCode = c.String(maxLength: 50),
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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SecurityUser", t => t.SecurityUserID)
                .Index(t => t.SecurityUserID);

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

            MigrationsHelp.AddLookUp(Sql,
                new Lookup("大专", Common.Enum.LookupCodeEnum.EnumCultureStatus, EnumCultureStatus.College),
                new Lookup("本科", Common.Enum.LookupCodeEnum.EnumCultureStatus, EnumCultureStatus.Undergraduate),
                new Lookup("硕士", Common.Enum.LookupCodeEnum.EnumCultureStatus, EnumCultureStatus.Master),
                new Lookup("博士", Common.Enum.LookupCodeEnum.EnumCultureStatus, EnumCultureStatus.Doctor),

                new Lookup("保密", Common.Enum.LookupCodeEnum.EnumMarriageStatus, EnumMarriageStatus.None),
                new Lookup("已婚", Common.Enum.LookupCodeEnum.EnumMarriageStatus, EnumMarriageStatus.Married),
                new Lookup("未婚", Common.Enum.LookupCodeEnum.EnumMarriageStatus, EnumMarriageStatus.Unmarried),

                new Lookup("保密", Common.Enum.LookupCodeEnum.EnumSex, EnumSex.None),
                new Lookup("男", Common.Enum.LookupCodeEnum.EnumSex, EnumSex.Man),
                new Lookup("女", Common.Enum.LookupCodeEnum.EnumSex, EnumSex.Woman),

                new Lookup("开发者", Common.Enum.LookupCodeEnum.EnumStaffCategory, EnumStaffCategory.Developer),
                new Lookup("管理者", Common.Enum.LookupCodeEnum.EnumStaffCategory, EnumStaffCategory.Manager),

                new Lookup("注销", Common.Enum.LookupCodeEnum.EnumAccountStatus, EnumAccountStatus.LogOff),
                new Lookup("未注销", Common.Enum.LookupCodeEnum.EnumAccountStatus, EnumAccountStatus.NuLogOff)
                );
            MigrationsHelp.InitDB(Sql);
            Sql("Exec Proc_InitialView 'SecurityUser'");
            Sql("Exec Proc_InitialView 'PersonnelAttendance'");
        }

        public override void Down()
        {
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
            DropIndex("SecurityUser", new[] { "StatusID" });
            DropIndex("SecurityUser", new[] { "StaffCategoryID" });
            DropIndex("SecurityUser", new[] { "CultureStatusID" });
            DropIndex("SecurityUser", new[] { "MarriageStatusID" });
            DropIndex("SecurityUser", new[] { "Sex" });
            DropIndex("SecurityUser", new[] { "ModifiedByUserID" });
            DropIndex("SecurityUser", new[] { "CreatedByUserID" });
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
            DropForeignKey("SecurityUser", "StatusID", "zMetaLookup");
            DropForeignKey("SecurityUser", "StaffCategoryID", "zMetaLookup");
            DropForeignKey("SecurityUser", "CultureStatusID", "zMetaLookup");
            DropForeignKey("SecurityUser", "MarriageStatusID", "zMetaLookup");
            DropForeignKey("SecurityUser", "Sex", "zMetaLookup");
            DropForeignKey("SecurityUser", "ModifiedByUserID", "SecurityUser");
            DropForeignKey("SecurityUser", "CreatedByUserID", "SecurityUser");
            DropTable("zMetaFormLayout");
            DropTable("PersonnelAttendance");
            DropTable("SystemModuleDetailPage");
            DropTable("SystemModuleType");
            DropTable("SystemModule");
            DropTable("SystemPermission");
            DropTable("SecurityRole");
            DropTable("SecurityUserRole");
            DropTable("OperateLog");
            DropTable("zMetaLookup");
            DropTable("SecurityUser");
        }
    }
}
