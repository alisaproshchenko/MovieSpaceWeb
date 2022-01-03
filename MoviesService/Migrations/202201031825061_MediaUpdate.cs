namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MediaUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Media", "SeasonCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Media", "SeasonCount");
        }
    }
}
