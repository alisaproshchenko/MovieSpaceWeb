namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changerequired2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Media", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Media", "Plot", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Media", "Plot", c => c.String());
            AlterColumn("dbo.Media", "Name", c => c.String());
        }
    }
}
