namespace qlts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init33322 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fields", "ModifiedBy", c => c.String());
            AlterColumn("dbo.FixedAssets", "ModifiedBy", c => c.String());
            AlterColumn("dbo.FixedAssetStatus", "ModifiedBy", c => c.String());
            AlterColumn("dbo.Manufacturers", "ModifiedBy", c => c.String());
            AlterColumn("dbo.Warehouses", "ModifiedBy", c => c.String());
            AlterColumn("dbo.Users", "ModifiedBy", c => c.String());
            AlterColumn("dbo.WareHouseAssetsExports", "ModifiedBy", c => c.String());
            AlterColumn("dbo.WareHouseAssetsTransfers", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WareHouseAssetsTransfers", "ModifiedBy", c => c.DateTime());
            AlterColumn("dbo.WareHouseAssetsExports", "ModifiedBy", c => c.DateTime());
            AlterColumn("dbo.Users", "ModifiedBy", c => c.DateTime());
            AlterColumn("dbo.Warehouses", "ModifiedBy", c => c.DateTime());
            AlterColumn("dbo.Manufacturers", "ModifiedBy", c => c.DateTime());
            AlterColumn("dbo.FixedAssetStatus", "ModifiedBy", c => c.DateTime());
            AlterColumn("dbo.FixedAssets", "ModifiedBy", c => c.DateTime());
            AlterColumn("dbo.Fields", "ModifiedBy", c => c.DateTime());
        }
    }
}
