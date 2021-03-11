namespace CycleWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update7_remove_transactions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "PartId", "dbo.Part");
            DropForeignKey("dbo.User", "TransactionId", "dbo.Transaction");
            DropIndex("dbo.Transaction", new[] { "PartId" });
            DropIndex("dbo.User", new[] { "TransactionId" });
            DropColumn("dbo.User", "TransactionId");
            DropTable("dbo.Transaction");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.TransactionId);
            
            AddColumn("dbo.User", "TransactionId", c => c.Int());
            CreateIndex("dbo.User", "TransactionId");
            CreateIndex("dbo.Transaction", "PartId");
            AddForeignKey("dbo.User", "TransactionId", "dbo.Transaction", "TransactionId");
            AddForeignKey("dbo.Transaction", "PartId", "dbo.Part", "PartId");
        }
    }
}
