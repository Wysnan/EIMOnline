namespace Wysnan.EIMOnline.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("zMetaFormLayout");
        }
    }
}
