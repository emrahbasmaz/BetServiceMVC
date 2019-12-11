namespace BetService.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modify : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Result", c => c.String(nullable: false));
            AlterColumn("dbo.Players", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Players", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "Email", c => c.String());
            AlterColumn("dbo.Players", "Name", c => c.String());
            AlterColumn("dbo.Events", "Result", c => c.String());
        }
    }
}
