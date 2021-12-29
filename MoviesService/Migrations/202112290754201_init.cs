namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Countries", "Media_Id", "dbo.Media");
            DropForeignKey("dbo.Genres", "Media_Id", "dbo.Media");
            DropForeignKey("dbo.Seasons", "Media_Id", "dbo.Media");
            DropForeignKey("dbo.Types", "Id", "dbo.Media");
            DropIndex("dbo.Types", new[] { "Id" });
            DropPrimaryKey("dbo.Media");
            DropPrimaryKey("dbo.Types");
            AddColumn("dbo.Media", "TypesId", c => c.Int(nullable: false));
            AlterColumn("dbo.Media", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Types", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Media", "Id");
            AddPrimaryKey("dbo.Types", "Id");
            CreateIndex("dbo.Media", "Id");
            AddForeignKey("dbo.Countries", "Media_Id", "dbo.Media", "Id");
            AddForeignKey("dbo.Genres", "Media_Id", "dbo.Media", "Id");
            AddForeignKey("dbo.Seasons", "Media_Id", "dbo.Media", "Id");
            AddForeignKey("dbo.Media", "Id", "dbo.Types", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Media", "Id", "dbo.Types");
            DropForeignKey("dbo.Seasons", "Media_Id", "dbo.Media");
            DropForeignKey("dbo.Genres", "Media_Id", "dbo.Media");
            DropForeignKey("dbo.Countries", "Media_Id", "dbo.Media");
            DropIndex("dbo.Media", new[] { "Id" });
            DropPrimaryKey("dbo.Types");
            DropPrimaryKey("dbo.Media");
            AlterColumn("dbo.Types", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Media", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Media", "TypesId");
            AddPrimaryKey("dbo.Types", "Id");
            AddPrimaryKey("dbo.Media", "Id");
            CreateIndex("dbo.Types", "Id");
            AddForeignKey("dbo.Types", "Id", "dbo.Media", "Id");
            AddForeignKey("dbo.Seasons", "Media_Id", "dbo.Media", "Id");
            AddForeignKey("dbo.Genres", "Media_Id", "dbo.Media", "Id");
            AddForeignKey("dbo.Countries", "Media_Id", "dbo.Media", "Id");
        }
    }
}
