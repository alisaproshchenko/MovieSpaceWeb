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
                        Media_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Media", t => t.Media_Id)
                .Index(t => t.Media_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeriesId = c.String(nullable: false),
                        IMDbMovieId = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        RatingIMDb = c.Double(),
                        UserIMDb = c.Double(),
                        Media_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Media", t => t.Media_Id)
                .Index(t => t.Media_Id);
            
            CreateTable(
                "dbo.Episodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Seasons_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seasons", t => t.Seasons_Id)
                .Index(t => t.Seasons_Id);
            
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
                "dbo.MediaGenres",
                c => new
                    {
                        MediaId = c.Int(nullable: false),
                        GenresId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MediaId, t.GenresId })
                .ForeignKey("dbo.Media", t => t.MediaId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenresId, cascadeDelete: true)
                .Index(t => t.MediaId)
                .Index(t => t.GenresId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersToMedias", "Id", "dbo.Media");
            DropForeignKey("dbo.Media", "Id", "dbo.Types");
            DropForeignKey("dbo.Seasons", "Media_Id", "dbo.Media");
            DropForeignKey("dbo.Episodes", "Seasons_Id", "dbo.Seasons");
            DropForeignKey("dbo.MediaGenres", "GenresId", "dbo.Genres");
            DropForeignKey("dbo.MediaGenres", "MediaId", "dbo.Media");
            DropForeignKey("dbo.Countries", "Media_Id", "dbo.Media");
            DropIndex("dbo.MediaGenres", new[] { "GenresId" });
            DropIndex("dbo.MediaGenres", new[] { "MediaId" });
            DropIndex("dbo.UsersToMedias", new[] { "Id" });
            DropIndex("dbo.Episodes", new[] { "Seasons_Id" });
            DropIndex("dbo.Seasons", new[] { "Media_Id" });
            DropIndex("dbo.Media", new[] { "Id" });
            DropIndex("dbo.Countries", new[] { "Media_Id" });
            DropTable("dbo.MediaGenres");
            DropTable("dbo.UsersToMedias");
            DropTable("dbo.Types");
            DropTable("dbo.Episodes");
            DropTable("dbo.Seasons");
            DropTable("dbo.Media");
            DropTable("dbo.Genres");
            DropTable("dbo.Countries");
        }
    }
}
