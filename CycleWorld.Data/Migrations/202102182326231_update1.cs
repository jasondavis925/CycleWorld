namespace CycleWorld.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Part", "PartName", c => c.String(nullable: false));
            AddColumn("dbo.Part", "ModelNumber", c => c.String(nullable: false));
            AddColumn("dbo.Part", "Manufacturer", c => c.String(nullable: false));
            AddColumn("dbo.Part", "TypeofPart", c => c.Int(nullable: false));
            AddColumn("dbo.Part", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Part", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Shop", "ShopName", c => c.String(nullable: false));
            AddColumn("dbo.Shop", "Services", c => c.String(nullable: false));
            AddColumn("dbo.Shop", "Location", c => c.String());
            DropColumn("dbo.Part", "Title");
            DropColumn("dbo.Shop", "Title");
            DropColumn("dbo.Shop", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shop", "Content", c => c.String(nullable: false));
            AddColumn("dbo.Shop", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Part", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Shop", "Location");
            DropColumn("dbo.Shop", "Services");
            DropColumn("dbo.Shop", "ShopName");
            DropColumn("dbo.Part", "ModifiedUtc");
            DropColumn("dbo.Part", "CreatedUtc");
            DropColumn("dbo.Part", "TypeofPart");
            DropColumn("dbo.Part", "Manufacturer");
            DropColumn("dbo.Part", "ModelNumber");
            DropColumn("dbo.Part", "PartName");
        }
    }
}
