namespace qlts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init333281 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Manufacturers", newName: "FixedAssetManufacturers");
            DropForeignKey("dbo.WareHouseAssetsExports", "FixedAsset_Id", "dbo.FixedAssets");
            DropForeignKey("dbo.WareHouseAssetsExports", "UserId", "dbo.Users");
            DropForeignKey("dbo.WareHouseAssetsExports", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.WareHouseAssetsTransfers", "FixedAsset_Id", "dbo.FixedAssets");
            DropForeignKey("dbo.WareHouseAssetsTransfers", "UserId", "dbo.Users");
            DropForeignKey("dbo.WareHouseAssetsTransfers", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.FixedAssets", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.FixedAssets", new[] { "ManufacturerId" });
            DropIndex("dbo.WareHouseAssetsExports", new[] { "UserId" });
            DropIndex("dbo.WareHouseAssetsExports", new[] { "WarehouseId" });
            DropIndex("dbo.WareHouseAssetsExports", new[] { "FixedAsset_Id" });
            DropIndex("dbo.WareHouseAssetsTransfers", new[] { "UserId" });
            DropIndex("dbo.WareHouseAssetsTransfers", new[] { "WarehouseId" });
            DropIndex("dbo.WareHouseAssetsTransfers", new[] { "FixedAsset_Id" });
            AddColumn("dbo.FixedAssets", "FixedAssetManufacturer_Id", c => c.Guid());
            CreateIndex("dbo.FixedAssets", "FixedAssetManufacturer_Id");
            AddForeignKey("dbo.FixedAssets", "FixedAssetManufacturer_Id", "dbo.FixedAssetManufacturers", "Id");
            DropTable("dbo.WareHouseAssetsExports");
            DropTable("dbo.WareHouseAssetsTransfers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WareHouseAssetsTransfers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FixedAssetId = c.String(),
                        UserId = c.Guid(nullable: false),
                        Note = c.String(),
                        Date = c.DateTime(nullable: false),
                        WarehouseId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        FixedAsset_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WareHouseAssetsExports",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FixedAssetId = c.String(),
                        UserId = c.Guid(nullable: false),
                        Note = c.String(),
                        Date = c.DateTime(nullable: false),
                        WarehouseId = c.Guid(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        FixedAsset_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.FixedAssets", "FixedAssetManufacturer_Id", "dbo.FixedAssetManufacturers");
            DropIndex("dbo.FixedAssets", new[] { "FixedAssetManufacturer_Id" });
            DropColumn("dbo.FixedAssets", "FixedAssetManufacturer_Id");
            CreateIndex("dbo.WareHouseAssetsTransfers", "FixedAsset_Id");
            CreateIndex("dbo.WareHouseAssetsTransfers", "WarehouseId");
            CreateIndex("dbo.WareHouseAssetsTransfers", "UserId");
            CreateIndex("dbo.WareHouseAssetsExports", "FixedAsset_Id");
            CreateIndex("dbo.WareHouseAssetsExports", "WarehouseId");
            CreateIndex("dbo.WareHouseAssetsExports", "UserId");
            CreateIndex("dbo.FixedAssets", "ManufacturerId");
            AddForeignKey("dbo.FixedAssets", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WareHouseAssetsTransfers", "WarehouseId", "dbo.Warehouses", "Id");
            AddForeignKey("dbo.WareHouseAssetsTransfers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WareHouseAssetsTransfers", "FixedAsset_Id", "dbo.FixedAssets", "Id");
            AddForeignKey("dbo.WareHouseAssetsExports", "WarehouseId", "dbo.Warehouses", "Id");
            AddForeignKey("dbo.WareHouseAssetsExports", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WareHouseAssetsExports", "FixedAsset_Id", "dbo.FixedAssets", "Id");
            RenameTable(name: "dbo.FixedAssetManufacturers", newName: "Manufacturers");
        }
    }
}
