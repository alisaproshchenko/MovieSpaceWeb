namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Countries", "MediaId", "dbo.Media");
            DropForeignKey("dbo.Genres", "MediaId", "dbo.Media");
            DropForeignKey("dbo.Seasons", "MediaId", "dbo.Media");
            DropIndex("dbo.Countries", new[] { "MediaId" });
            DropIndex("dbo.Genres", new[] { "MediaId" });
            DropIndex("dbo.Seasons", new[] { "MediaId" });
            RenameColumn(table: "dbo.Countries", name: "MediaId", newName: "Media_Id");
            RenameColumn(table: "dbo.Genres", name: "MediaId", newName: "Media_Id");
            RenameColumn(table: "dbo.Seasons", name: "MediaId", newName: "Media_Id");
            AlterColumn("dbo.Countries", "Media_Id", c => c.Int());
            AlterColumn("dbo.Genres", "Media_Id", c => c.Int());
            AlterColumn("dbo.Seasons", "Media_Id", c => c.Int());
            CreateIndex("dbo.Countries", "Media_Id");
            CreateIndex("dbo.Genres", "Media_Id");
            CreateIndex("dbo.Seasons", "Media_Id");
            AddForeignKey("dbo.Countries", "Media_Id", "dbo.Media", "Id");
            AddForeignKey("dbo.Genres", "Media_Id", "dbo.Media", "Id");
            AddForeignKey("dbo.Seasons", "Media_Id", "dbo.Media", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seasons", "Media_Id", "dbo.Media");
            DropForeignKey("dbo.Genres", "Media_Id", "dbo.Media");
            DropForeignKey("dbo.Countries", "Media_Id", "dbo.Media");
            DropIndex("dbo.Seasons", new[] { "Media_Id" });
            DropIndex("dbo.Genres", new[] { "Media_Id" });
            DropIndex("dbo.Countries", new[] { "Media_Id" });
            AlterColumn("dbo.Seasons", "Media_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Genres", "Media_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Countries", "Media_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Seasons", name: "Media_Id", newName: "MediaId");
            RenameColumn(table: "dbo.Genres", name: "Media_Id", newName: "MediaId");
            RenameColumn(table: "dbo.Countries", name: "Media_Id", newName: "MediaId");
            CreateIndex("dbo.Seasons", "MediaId");
            CreateIndex("dbo.Genres", "MediaId");
            CreateIndex("dbo.Countries", "MediaId");
            AddForeignKey("dbo.Seasons", "MediaId", "dbo.Media", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Genres", "MediaId", "dbo.Media", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Countries", "MediaId", "dbo.Media", "Id", cascadeDelete: true);
        }
    }
}
