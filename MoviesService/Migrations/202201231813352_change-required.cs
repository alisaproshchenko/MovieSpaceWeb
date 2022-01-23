namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changerequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Media", "Name", c => c.String());
            AlterColumn("dbo.Media", "Plot", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Media", "Plot", c => c.String(nullable: false));
            AlterColumn("dbo.Media", "Name", c => c.String(nullable: false));
        }
    }
}
