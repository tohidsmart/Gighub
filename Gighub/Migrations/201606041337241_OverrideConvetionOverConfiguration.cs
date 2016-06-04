namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConvetionOverConfiguration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Artists_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gigs", "genre_Id", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "Artists_Id" });
            DropIndex("dbo.Gigs", new[] { "genre_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Gigs", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Gigs", "Artists_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Gigs", "Genre_Id", c => c.Byte());
            CreateIndex("dbo.Gigs", "Artists_Id");
            CreateIndex("dbo.Gigs", "Genre_Id");
            AddForeignKey("dbo.Gigs", "Artists_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "Artists_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Genre_Id" });
            DropIndex("dbo.Gigs", new[] { "Artists_Id" });
            AlterColumn("dbo.Gigs", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Gigs", "Artists_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Gigs", "Venue", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.Gigs", "genre_Id");
            CreateIndex("dbo.Gigs", "Artists_Id");
            AddForeignKey("dbo.Gigs", "genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Gigs", "Artists_Id", "dbo.AspNetUsers", "Id");
        }
    }
}