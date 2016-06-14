namespace TeachingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtemes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "EslLevelId", c => c.Int());
            AddColumn("dbo.Questions", "GrammaCategoryId", c => c.Int());
            AddColumn("dbo.Questions", "LexicTypeId", c => c.Int());
            CreateIndex("dbo.Questions", "LexicTypeId");
            AddForeignKey("dbo.Questions", "LexicTypeId", "dbo.LexicTypes", "Id");
            DropColumn("dbo.Questions", "LexicType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "LexicType", c => c.String());
            DropForeignKey("dbo.Questions", "LexicTypeId", "dbo.LexicTypes");
            DropIndex("dbo.Questions", new[] { "LexicTypeId" });
            DropColumn("dbo.Questions", "LexicTypeId");
            DropColumn("dbo.Questions", "GrammaCategoryId");
            DropColumn("dbo.Questions", "EslLevelId");
        }
    }
}
