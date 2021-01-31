namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryObjects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "CategoryId", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CategoryId" });
            DropColumn("dbo.Note", "CategoryId");
            DropColumn("dbo.Note", "CategoryName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "CategoryName", c => c.String());
            AddColumn("dbo.Note", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Note", "CategoryId");
            AddForeignKey("dbo.Note", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
        }
    }
}
