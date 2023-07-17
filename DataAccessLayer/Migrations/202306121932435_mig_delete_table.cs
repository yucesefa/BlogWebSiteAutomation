namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_delete_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Headings", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Contents", "Heading_HeadiingID", "dbo.Headings");
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Headings", "WriterID", "dbo.Writers");
            DropIndex("dbo.Headings", new[] { "CategoryID" });
            DropIndex("dbo.Headings", new[] { "WriterID" });
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropIndex("dbo.Contents", new[] { "Heading_HeadiingID" });
            DropTable("dbo.Headings");
            DropTable("dbo.Contents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        ContentValue = c.String(maxLength: 1000),
                        ContentDate = c.DateTime(nullable: false),
                        ContentStatus = c.Boolean(nullable: false),
                        HeadingID = c.Int(nullable: false),
                        WriterID = c.Int(),
                        Heading_HeadiingID = c.Int(),
                    })
                .PrimaryKey(t => t.ContentID);
            
            CreateTable(
                "dbo.Headings",
                c => new
                    {
                        HeadiingID = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(maxLength: 50),
                        HeadingDate = c.DateTime(nullable: false),
                        HeadingStatus = c.Boolean(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        WriterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HeadiingID);
            
            CreateIndex("dbo.Contents", "Heading_HeadiingID");
            CreateIndex("dbo.Contents", "WriterID");
            CreateIndex("dbo.Headings", "WriterID");
            CreateIndex("dbo.Headings", "CategoryID");
            AddForeignKey("dbo.Headings", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: true);
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID");
            AddForeignKey("dbo.Contents", "Heading_HeadiingID", "dbo.Headings", "HeadiingID");
            AddForeignKey("dbo.Headings", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
    }
}
