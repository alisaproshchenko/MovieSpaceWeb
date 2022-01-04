namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seasons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seasons", "EpisodeCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Seasons", "EpisodeCount");
        }
    }
}
