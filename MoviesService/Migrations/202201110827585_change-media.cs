namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemedia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Media", "AmountOfLikes", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Media", "AmountOfLikes");
        }
    }
}
