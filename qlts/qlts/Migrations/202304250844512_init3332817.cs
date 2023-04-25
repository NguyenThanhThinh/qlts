namespace qlts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3332817 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FixedAssetManufacturers", "FixedAssetCode", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.FixedAssetManufacturers", "FixedAssetName", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.FixedAssetManufacturers", "Description", c => c.String());
            AddColumn("dbo.FixedAssetManufacturers", "PartNumber", c => c.String());
            AddColumn("dbo.FixedAssetManufacturers", "Unit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FixedAssetManufacturers", "Unit");
            DropColumn("dbo.FixedAssetManufacturers", "PartNumber");
            DropColumn("dbo.FixedAssetManufacturers", "Description");
            DropColumn("dbo.FixedAssetManufacturers", "FixedAssetName");
            DropColumn("dbo.FixedAssetManufacturers", "FixedAssetCode");
        }
    }
}
