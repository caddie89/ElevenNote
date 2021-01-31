namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "CategoryName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Note", "CategoryName");
        }
    }
}
