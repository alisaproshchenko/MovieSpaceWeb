namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change4323 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UsersToMedias");
            AddColumn("dbo.UsersToMedias", "UserToMediaId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UsersToMedias", "UserToMediaId");
            DropColumn("dbo.UsersToMedias", "Id");
            DropColumn("dbo.UsersToMedias", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersToMedias", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.UsersToMedias", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.UsersToMedias");
            DropColumn("dbo.UsersToMedias", "UserToMediaId");
            AddPrimaryKey("dbo.UsersToMedias", "Id");
        }
    }
}
