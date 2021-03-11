namespace CycleWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shop", "PartId", "dbo.Part");
            DropIndex("dbo.Shop", new[] { "PartId" });
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        PartId = c.Int(),
                        ItemCount = c.Int(nullable: false),
                        DateOfTransaction = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Part", t => t.PartId)
                .Index(t => t.PartId);
            
            AddColumn("dbo.Part", "NumberInInventory", c => c.Int(nullable: false));
            AddColumn("dbo.User", "TransactionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Shop", "PartId", c => c.Int());
            CreateIndex("dbo.Shop", "PartId");
            CreateIndex("dbo.User", "TransactionId");
            AddForeignKey("dbo.User", "TransactionId", "dbo.Transaction", "TransactionId", cascadeDelete: true);
            AddForeignKey("dbo.Shop", "PartId", "dbo.Part", "PartId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shop", "PartId", "dbo.Part");
            DropForeignKey("dbo.User", "TransactionId", "dbo.Transaction");
            DropForeignKey("dbo.Transaction", "PartId", "dbo.Part");
            DropIndex("dbo.User", new[] { "TransactionId" });
            DropIndex("dbo.Transaction", new[] { "PartId" });
            DropIndex("dbo.Shop", new[] { "PartId" });
            AlterColumn("dbo.Shop", "PartId", c => c.Int(nullable: false));
            DropColumn("dbo.User", "TransactionId");
            DropColumn("dbo.Part", "NumberInInventory");
            DropTable("dbo.Transaction");
            CreateIndex("dbo.Shop", "PartId");
            AddForeignKey("dbo.Shop", "PartId", "dbo.Part", "PartId", cascadeDelete: true);
        }
    }
}
