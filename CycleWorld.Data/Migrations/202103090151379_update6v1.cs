namespace CycleWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update6v1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Part", "TypeofPart");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Part", "TypeofPart", c => c.Int(nullable: false));
        }
    }
}
