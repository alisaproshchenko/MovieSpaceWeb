namespace IdentityService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutUs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutUs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        PhotoLink = c.String(),
                        ProjectRole = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AboutUs");
        }
    }
}
