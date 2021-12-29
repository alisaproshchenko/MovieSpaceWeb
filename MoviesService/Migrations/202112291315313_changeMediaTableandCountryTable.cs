namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMediaTableandCountryTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Countries", "Media_Id", "dbo.Media");
            DropIndex("dbo.Countries", new[] { "Media_Id" });
            CreateTable(
                "dbo.MediaCountry",
                c => new
                    {
                        MediaId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MediaId, t.CountryId })
                .ForeignKey("dbo.Media", t => t.MediaId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.MediaId)
                .Index(t => t.CountryId);
            
            DropColumn("dbo.Countries", "Media_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Countries", "Media_Id", c => c.Int());
            DropForeignKey("dbo.MediaCountry", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.MediaCountry", "MediaId", "dbo.Media");
            DropIndex("dbo.MediaCountry", new[] { "CountryId" });
            DropIndex("dbo.MediaCountry", new[] { "MediaId" });
            DropTable("dbo.MediaCountry");
            CreateIndex("dbo.Countries", "Media_Id");
            AddForeignKey("dbo.Countries", "Media_Id", "dbo.Media", "Id");
        }
    }
}
