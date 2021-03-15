namespace CycleWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migdav0212v0 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Part", "ShopId", "dbo.Shop");
            DropIndex("dbo.Part", new[] { "ShopId" });
            AddColumn("dbo.Shop", "PartId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shop", "PartId");
            AddForeignKey("dbo.Shop", "PartId", "dbo.Part", "PartId", cascadeDelete: true);
            DropColumn("dbo.Part", "ShopId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Part", "ShopId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Shop", "PartId", "dbo.Part");
            DropIndex("dbo.Shop", new[] { "PartId" });
            DropColumn("dbo.Shop", "PartId");
            CreateIndex("dbo.Part", "ShopId");
            AddForeignKey("dbo.Part", "ShopId", "dbo.Shop", "ShopId", cascadeDelete: true);
        }
    }
}
