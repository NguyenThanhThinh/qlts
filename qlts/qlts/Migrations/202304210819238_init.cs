namespace qlts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.WareHouseAssetsTransfers", newName: "TBL_WareHouseAssetsTransfers");
            CreateTable(
                "dbo.TBL_WareHouseAssetsExports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FixedAssetId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Note = c.String(),
                        Date = c.DateTime(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.DateTime(),
                        FixedAsset_Id = c.Guid(),
                        User_Id = c.Guid(),
                        Warehouse_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBL_FixedAssets", t => t.FixedAsset_Id)
                .ForeignKey("dbo.TBL_Users", t => t.User_Id)
                .ForeignKey("dbo.TBL_Warehouses", t => t.Warehouse_Id)
                .Index(t => t.FixedAsset_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Warehouse_Id);
            
            AddColumn("dbo.TBL_Manufacturers", "WarrantyPeriodDate", c => c.DateTime());
            AddColumn("dbo.TBL_Warehouses", "WarehouseType", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_FixedAssets", "Unit", c => c.Int(nullable: false));
            AlterColumn("dbo.TBL_Warehouses", "Unit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBL_WareHouseAssetsExports", "Warehouse_Id", "dbo.TBL_Warehouses");
            DropForeignKey("dbo.TBL_WareHouseAssetsExports", "User_Id", "dbo.TBL_Users");
            DropForeignKey("dbo.TBL_WareHouseAssetsExports", "FixedAsset_Id", "dbo.TBL_FixedAssets");
            DropIndex("dbo.TBL_WareHouseAssetsExports", new[] { "Warehouse_Id" });
            DropIndex("dbo.TBL_WareHouseAssetsExports", new[] { "User_Id" });
            DropIndex("dbo.TBL_WareHouseAssetsExports", new[] { "FixedAsset_Id" });
            AlterColumn("dbo.TBL_Warehouses", "Unit", c => c.String(maxLength: 100));
            AlterColumn("dbo.TBL_FixedAssets", "Unit", c => c.String());
            DropColumn("dbo.TBL_Warehouses", "WarehouseType");
            DropColumn("dbo.TBL_Manufacturers", "WarrantyPeriodDate");
            DropTable("dbo.TBL_WareHouseAssetsExports");
            RenameTable(name: "dbo.TBL_WareHouseAssetsTransfers", newName: "WareHouseAssetsTransfers");
        }
    }
}
