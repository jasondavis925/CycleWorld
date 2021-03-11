namespace CycleWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "TransactionId", "dbo.Transaction");
            DropIndex("dbo.User", new[] { "TransactionId" });
            AlterColumn("dbo.User", "TransactionId", c => c.Int());
            CreateIndex("dbo.User", "TransactionId");
            AddForeignKey("dbo.User", "TransactionId", "dbo.Transaction", "TransactionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "TransactionId", "dbo.Transaction");
            DropIndex("dbo.User", new[] { "TransactionId" });
            AlterColumn("dbo.User", "TransactionId", c => c.Int(nullable: false));
            CreateIndex("dbo.User", "TransactionId");
            AddForeignKey("dbo.User", "TransactionId", "dbo.Transaction", "TransactionId", cascadeDelete: true);
        }
    }
}
