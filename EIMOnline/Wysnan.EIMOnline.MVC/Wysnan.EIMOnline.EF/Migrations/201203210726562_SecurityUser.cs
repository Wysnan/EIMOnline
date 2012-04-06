namespace Wysnan.EIMOnline.EF.Migrations
{
    using System.Data.Entity.Migrations;
    using Wysnan.EIMOnline.EF.Migrations.DBScript;

    public partial class SecurityUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SecurityUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);

            Sql(SqlMigration.GetInitMigration());
        }

        public override void Down()
        {
            DropTable("SecurityUser");
        }
    }
}
