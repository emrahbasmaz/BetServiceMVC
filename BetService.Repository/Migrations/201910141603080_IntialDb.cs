namespace BetService.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        BetId = c.Long(nullable: false, identity: true),
                        EventId = c.Long(nullable: false),
                        PlayerId = c.Long(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BetType = c.String(),
                    })
                .PrimaryKey(t => t.BetId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Long(nullable: false, identity: true),
                        HomeTeam = c.String(),
                        AwayTeam = c.String(),
                        KickOff = c.DateTime(nullable: false),
                        HomeTeamOdds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AwayTeamOdds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DrawOdds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Result = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Credit = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Players");
            DropTable("dbo.Events");
            DropTable("dbo.Bets");
        }
    }
}
