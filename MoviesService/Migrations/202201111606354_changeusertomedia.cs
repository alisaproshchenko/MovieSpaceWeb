namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeusertomedia : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersToMedias", "Id", "dbo.Media");
            DropIndex("dbo.UsersToMedias", new[] { "Id" });
            DropPrimaryKey("dbo.UsersToMedias");
            AlterColumn("dbo.UsersToMedias", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UsersToMedias", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UsersToMedias");
            AlterColumn("dbo.UsersToMedias", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UsersToMedias", "Id");
            CreateIndex("dbo.UsersToMedias", "Id");
            AddForeignKey("dbo.UsersToMedias", "Id", "dbo.Media", "Id");
        }
    }
}
