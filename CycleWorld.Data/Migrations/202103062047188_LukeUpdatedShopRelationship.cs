namespace CycleWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LukeUpdatedShopRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "ShopId", c => c.Int());
            CreateIndex("dbo.User", "ShopId");
            AddForeignKey("dbo.User", "ShopId", "dbo.Shop", "ShopId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "ShopId", "dbo.Shop");
            DropIndex("dbo.User", new[] { "ShopId" });
            DropColumn("dbo.User", "ShopId");
        }
    }
}
