namespace CycleWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update6v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Part", "TypeOfPart", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Part", "TypeOfPart");
        }
    }
}
