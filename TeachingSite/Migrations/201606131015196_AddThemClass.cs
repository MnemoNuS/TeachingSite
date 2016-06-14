namespace TeachingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThemClass : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GrammaQuestions", newName: "Questions");
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "Type", c => c.String());
            AddColumn("dbo.Questions", "ModifiedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Questions", "Topic", c => c.String());
            AddColumn("dbo.Questions", "LexicType", c => c.String());
            AddColumn("dbo.Questions", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Questions", "Theme_Id", c => c.Int());
            CreateIndex("dbo.Questions", "Theme_Id");
            AddForeignKey("dbo.Questions", "Theme_Id", "dbo.Themes", "Id");
            DropColumn("dbo.Questions", "CreatedAt");
            DropTable("dbo.LexicQuestions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LexicQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        LexicType = c.String(),
                        Body = c.String(),
                        Answer = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "CreatedAt", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Questions", "Theme_Id", "dbo.Themes");
            DropIndex("dbo.Questions", new[] { "Theme_Id" });
            DropColumn("dbo.Questions", "Theme_Id");
            DropColumn("dbo.Questions", "Discriminator");
            DropColumn("dbo.Questions", "LexicType");
            DropColumn("dbo.Questions", "Topic");
            DropColumn("dbo.Questions", "ModifiedAt");
            DropColumn("dbo.Questions", "Type");
            DropTable("dbo.Themes");
            RenameTable(name: "dbo.Questions", newName: "GrammaQuestions");
        }
    }
}
