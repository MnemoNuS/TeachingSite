namespace TeachingSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EslLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EslLevelName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrammaCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrammaCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GrammaQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EslLevel = c.String(),
                        GrammaCategory = c.String(),
                        Body = c.String(),
                        Answer = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.LexicTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LexicTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LexicTypes");
            DropTable("dbo.LexicQuestions");
            DropTable("dbo.GrammaQuestions");
            DropTable("dbo.GrammaCategories");
            DropTable("dbo.EslLevels");
        }
    }
}
