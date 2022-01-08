namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtrailerLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Media", "LinkEmbed", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Media", "LinkEmbed");
        }
    }
}
