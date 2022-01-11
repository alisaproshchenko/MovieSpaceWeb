namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemedia2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Media", "SiteUsersRatings", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Media", "SiteUsersRatings", c => c.Int());
        }
    }
}
