namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersToMedia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsersToMedias", "AddToWatch", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsersToMedias", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UsersToMedias", "Date");
            DropColumn("dbo.UsersToMedias", "AddToWatch");
        }
    }
}
