namespace qlts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init333 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TBL_Fields", newName: "Fields");
            RenameTable(name: "dbo.TBL_FixedAssets", newName: "FixedAssets");
            RenameTable(name: "dbo.TBL_FixedAssetStatus", newName: "FixedAssetStatus");
            RenameTable(name: "dbo.TBL_Manufacturers", newName: "Manufacturers");
            RenameTable(name: "dbo.TBL_Warehouses", newName: "Warehouses");
            RenameTable(name: "dbo.TBL_Users", newName: "Users");
            RenameTable(name: "dbo.TBL_WareHouseAssetsExports", newName: "WareHouseAssetsExports");
            RenameTable(name: "dbo.TBL_WareHouseAssetsTransfers", newName: "WareHouseAssetsTransfers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.WareHouseAssetsTransfers", newName: "TBL_WareHouseAssetsTransfers");
            RenameTable(name: "dbo.WareHouseAssetsExports", newName: "TBL_WareHouseAssetsExports");
            RenameTable(name: "dbo.Users", newName: "TBL_Users");
            RenameTable(name: "dbo.Warehouses", newName: "TBL_Warehouses");
            RenameTable(name: "dbo.Manufacturers", newName: "TBL_Manufacturers");
            RenameTable(name: "dbo.FixedAssetStatus", newName: "TBL_FixedAssetStatus");
            RenameTable(name: "dbo.FixedAssets", newName: "TBL_FixedAssets");
            RenameTable(name: "dbo.Fields", newName: "TBL_Fields");
        }
    }
}
