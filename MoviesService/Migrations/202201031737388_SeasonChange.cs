namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeasonChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seasons", "Name", c => c.String());
            DropColumn("dbo.Seasons", "SeriesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seasons", "SeriesId", c => c.String(nullable: false));
            DropColumn("dbo.Seasons", "Name");
        }
    }
}
