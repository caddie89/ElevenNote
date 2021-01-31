namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "CategoryName", c => c.String(nullable: false));
            DropColumn("dbo.Note", "NameOfCategory");
            DropColumn("dbo.Category", "NameOfCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "NameOfCategory", c => c.Int(nullable: false));
            AddColumn("dbo.Note", "NameOfCategory", c => c.Int(nullable: false));
            DropColumn("dbo.Category", "CategoryName");
        }
    }
}
