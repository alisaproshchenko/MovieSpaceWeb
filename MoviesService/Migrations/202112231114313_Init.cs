namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Types");
            AlterColumn("dbo.Types", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Types", "Id");
            CreateIndex("dbo.Types", "Id");
            AddForeignKey("dbo.Types", "Id", "dbo.Media", "Id");
            DropColumn("dbo.Media", "TypesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Media", "TypesId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Types", "Id", "dbo.Media");
            DropIndex("dbo.Types", new[] { "Id" });
            DropPrimaryKey("dbo.Types");
            AlterColumn("dbo.Types", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Types", "Id");
        }
    }
}
