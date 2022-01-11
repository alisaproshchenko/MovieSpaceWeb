namespace MoviesService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class mediatablechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Media", "SiteUsersRatings", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Media", "SiteUsersRatings", c => c.Int(nullable: false));
        }
    }
}
