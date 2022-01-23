namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changerequired3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Media", "Plot", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Media", "Plot", c => c.String(nullable: false));
        }
    }
}
