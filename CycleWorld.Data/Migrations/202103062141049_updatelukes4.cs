namespace CycleWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelukes4 : DbMigration
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
            AlterColumn("dbo.User", "ShopId", c => c.Int());
            CreateIndex("dbo.User", "BikeId");
            CreateIndex("dbo.User", "ShopId");
            AddForeignKey("dbo.User", "BikeId", "dbo.Bike", "BikeId");
            AddForeignKey("dbo.User", "ShopId", "dbo.Shop", "ShopId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "ShopId", "dbo.Shop");
            DropForeignKey("dbo.User", "BikeId", "dbo.Bike");
            DropIndex("dbo.User", new[] { "ShopId" });
            DropIndex("dbo.User", new[] { "BikeId" });
            AlterColumn("dbo.User", "ShopId", c => c.Int(nullable: false));
            DropColumn("dbo.User", "BikeId");
            DropTable("dbo.Bike");
            CreateIndex("dbo.User", "ShopId");
            AddForeignKey("dbo.User", "ShopId", "dbo.Shop", "ShopId", cascadeDelete: true);
        }
    }
}
