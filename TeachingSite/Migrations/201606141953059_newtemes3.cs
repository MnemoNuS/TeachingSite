namespace TeachingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtemes3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Theme_Id", "dbo.Themes");
            DropIndex("dbo.Questions", new[] { "Theme_Id" });
            CreateTable(
                "dbo.ThemeQuestion",
                c => new
                    {
                        ThemeId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ThemeId, t.QuestionId })
                .ForeignKey("dbo.Themes", t => t.ThemeId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.ThemeId)
                .Index(t => t.QuestionId);
            
            DropColumn("dbo.Questions", "Theme_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Theme_Id", c => c.Int());
            DropForeignKey("dbo.ThemeQuestion", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.ThemeQuestion", "ThemeId", "dbo.Themes");
            DropIndex("dbo.ThemeQuestion", new[] { "QuestionId" });
            DropIndex("dbo.ThemeQuestion", new[] { "ThemeId" });
            DropTable("dbo.ThemeQuestion");
            CreateIndex("dbo.Questions", "Theme_Id");
            AddForeignKey("dbo.Questions", "Theme_Id", "dbo.Themes", "Id");
        }
    }
}
