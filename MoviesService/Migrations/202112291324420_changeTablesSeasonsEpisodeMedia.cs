namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTablesSeasonsEpisodeMedia : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Seasons", name: "Media_Id", newName: "MediaId");
            RenameColumn(table: "dbo.Episodes", name: "Seasons_Id", newName: "SeasonsId");
            RenameIndex(table: "dbo.Seasons", name: "IX_Media_Id", newName: "IX_MediaId");
            RenameIndex(table: "dbo.Episodes", name: "IX_Seasons_Id", newName: "IX_SeasonsId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Episodes", name: "IX_SeasonsId", newName: "IX_Seasons_Id");
            RenameIndex(table: "dbo.Seasons", name: "IX_MediaId", newName: "IX_Media_Id");
            RenameColumn(table: "dbo.Episodes", name: "SeasonsId", newName: "Seasons_Id");
            RenameColumn(table: "dbo.Seasons", name: "MediaId", newName: "Media_Id");
        }
    }
}
