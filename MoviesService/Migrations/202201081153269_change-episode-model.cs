namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeepisodemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Episodes", "Image", c => c.String());
            AddColumn("dbo.Episodes", "Year", c => c.String());
            AddColumn("dbo.Episodes", "Plot", c => c.String());
            AddColumn("dbo.Episodes", "RatingValue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Episodes", "RatingValue");
            DropColumn("dbo.Episodes", "Plot");
            DropColumn("dbo.Episodes", "Year");
            DropColumn("dbo.Episodes", "Image");
        }
    }
}
