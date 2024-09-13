namespace nouhailaMiniProjet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        AdCategory_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.AdCategory_CategoryId)
                .Index(t => t.AdCategory_CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        RelatedAd_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Ads", t => t.RelatedAd_Id)
                .Index(t => t.RelatedAd_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "RelatedAd_Id", "dbo.Ads");
            DropForeignKey("dbo.Ads", "AdCategory_CategoryId", "dbo.Categories");
            DropIndex("dbo.Comments", new[] { "RelatedAd_Id" });
            DropIndex("dbo.Ads", new[] { "AdCategory_CategoryId" });
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Ads");
        }
    }
}
