namespace CycleWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LukeUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "ShopId", "dbo.Shop");
            DropIndex("dbo.User", new[] { "ShopId" });
            CreateTable(
                "dbo.Bike",
                c => new
                    {
                        BikeId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Model = c.String(nullable: false),
                        Make = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        Mileage = c.Decimal(precision: 18, scale: 2),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.BikeId);
            
            AddColumn("dbo.User", "BikeId", c => c.Int());
            CreateIndex("dbo.User", "BikeId");
            AddForeignKey("dbo.User", "BikeId", "dbo.Bike", "BikeId");
            DropColumn("dbo.User", "ShopId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "ShopId", c => c.Int(nullable: false));
            DropForeignKey("dbo.User", "BikeId", "dbo.Bike");
            DropIndex("dbo.User", new[] { "BikeId" });
            DropColumn("dbo.User", "BikeId");
            DropTable("dbo.Bike");
            CreateIndex("dbo.User", "ShopId");
            AddForeignKey("dbo.User", "ShopId", "dbo.Shop", "ShopId", cascadeDelete: true);
        }
    }
}
