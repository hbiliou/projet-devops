namespace nouhailaMiniProjet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingauthorname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "AuthorName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "AuthorName");
        }
    }
}
