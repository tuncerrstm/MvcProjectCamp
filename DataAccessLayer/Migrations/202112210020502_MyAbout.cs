namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyAbout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbilityName = c.String(maxLength: 50),
                        KnowledgeLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyAbouts",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        AboutShort = c.String(maxLength: 100),
                        ImagePath = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 50),
                        Skill1 = c.String(maxLength: 100),
                        Skill2 = c.String(maxLength: 100),
                        Skill3 = c.String(maxLength: 100),
                        Skill4 = c.String(maxLength: 100),
                        Rate1 = c.Int(nullable: false),
                        Rate2 = c.Int(nullable: false),
                        Rate3 = c.Int(nullable: false),
                        Rate4 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyAbouts");
            DropTable("dbo.Abilities");
        }
    }
}
