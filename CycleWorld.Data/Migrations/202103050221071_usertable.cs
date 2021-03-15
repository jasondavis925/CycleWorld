namespace CycleWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        PersonalId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Bio = c.String(),
                        ShopId = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Shop", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ShopId);
            
            AddColumn("dbo.Part", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "ShopId", "dbo.Shop");
            DropIndex("dbo.User", new[] { "ShopId" });
            DropColumn("dbo.Part", "Description");
            DropTable("dbo.User");
        }
    }
}
