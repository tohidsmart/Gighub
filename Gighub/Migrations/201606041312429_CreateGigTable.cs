namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGigTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Artists_Id = c.String(maxLength: 128),
                        genre_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artists_Id)
                .ForeignKey("dbo.Genres", t => t.genre_Id)
                .Index(t => t.Artists_Id)
                .Index(t => t.genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "Artists_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "genre_Id" });
            DropIndex("dbo.Gigs", new[] { "Artists_Id" });
            DropTable("dbo.Gigs");
            DropTable("dbo.Genres");
        }
    }
}
