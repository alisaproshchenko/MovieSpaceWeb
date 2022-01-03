namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MediaUpdate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Seasons", "IMDbMovieId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Seasons", "IMDbMovieId", c => c.String(nullable: false));
        }
    }
}
