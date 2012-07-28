namespace Wysnan.EIMOnline.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class PersonnelAttendance : DbMigration
    {
        public override void Up()
        {
            AddColumn("PersonnelAttendance", "IsLateComer", c => c.Boolean(nullable: false));
            AlterColumn("PersonnelAttendance", "EndWorkTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("PersonnelAttendance", "EndWorkTime", c => c.DateTime(nullable: false));
            DropColumn("PersonnelAttendance", "IsLateComer");
        }
    }
}
