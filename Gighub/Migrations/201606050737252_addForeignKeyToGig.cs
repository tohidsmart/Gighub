namespace Gighub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKeyToGig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Artists_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artists_Id" });
            AddColumn("dbo.Gigs", "ArtistId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Gigs", "GenredId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Gigs", "ArtistId");
            AddForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Gigs", "Artists_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gigs", "Artists_Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "ArtistId" });
            DropColumn("dbo.Gigs", "GenredId");
            DropColumn("dbo.Gigs", "ArtistId");
            CreateIndex("dbo.Gigs", "Artists_Id");
            AddForeignKey("dbo.Gigs", "Artists_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
