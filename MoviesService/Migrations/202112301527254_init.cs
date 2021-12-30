namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IMDbMovieId = c.String(),
                        Name = c.String(nullable: false),
                        Poster = c.String(),
                        Year = c.Int(nullable: false),
                        Cast = c.String(),
                        Plot = c.String(nullable: false),
                        BudgetAndBoxOffice = c.Int(),
                        RatingIMDb = c.Double(),
                        SiteUsersRatings = c.Double(),
                        TypesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Types", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MediaId = c.Int(),
                        SeriesId = c.String(nullable: false),
                        IMDbMovieId = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        RatingIMDb = c.Double(),
                        UserIMDb = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Media", t => t.MediaId)
                .Index(t => t.MediaId);
            
            CreateTable(
                "dbo.Episodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SeasonsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seasons", t => t.SeasonsId)
                .Index(t => t.SeasonsId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsersToMedias",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ApplicationUserId = c.String(),
                        MediaId = c.Int(nullable: false),
                        Liked = c.Boolean(nullable: false),
                        Watched = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Media", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MediaCountries",
                c => new
                    {
                        Media_Id = c.Int(nullable: false),
                        Country_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Media_Id, t.Country_Id })
                .ForeignKey("dbo.Media", t => t.Media_Id, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .Index(t => t.Media_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.GenresMedias",
                c => new
                    {
                        Genres_Id = c.Int(nullable: false),
                        Media_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genres_Id, t.Media_Id })
                .ForeignKey("dbo.Genres", t => t.Genres_Id, cascadeDelete: true)
                .ForeignKey("dbo.Media", t => t.Media_Id, cascadeDelete: true)
                .Index(t => t.Genres_Id)
                .Index(t => t.Media_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersToMedias", "Id", "dbo.Media");
            DropForeignKey("dbo.Media", "Id", "dbo.Types");
            DropForeignKey("dbo.Seasons", "MediaId", "dbo.Media");
            DropForeignKey("dbo.Episodes", "SeasonsId", "dbo.Seasons");
            DropForeignKey("dbo.GenresMedias", "Media_Id", "dbo.Media");
            DropForeignKey("dbo.GenresMedias", "Genres_Id", "dbo.Genres");
            DropForeignKey("dbo.MediaCountries", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.MediaCountries", "Media_Id", "dbo.Media");
            DropIndex("dbo.GenresMedias", new[] { "Media_Id" });
            DropIndex("dbo.GenresMedias", new[] { "Genres_Id" });
            DropIndex("dbo.MediaCountries", new[] { "Country_Id" });
            DropIndex("dbo.MediaCountries", new[] { "Media_Id" });
            DropIndex("dbo.UsersToMedias", new[] { "Id" });
            DropIndex("dbo.Episodes", new[] { "SeasonsId" });
            DropIndex("dbo.Seasons", new[] { "MediaId" });
            DropIndex("dbo.Media", new[] { "Id" });
            DropTable("dbo.GenresMedias");
            DropTable("dbo.MediaCountries");
            DropTable("dbo.UsersToMedias");
            DropTable("dbo.Types");
            DropTable("dbo.Episodes");
            DropTable("dbo.Seasons");
            DropTable("dbo.Genres");
            DropTable("dbo.Media");
            DropTable("dbo.Countries");
        }
    }
}
