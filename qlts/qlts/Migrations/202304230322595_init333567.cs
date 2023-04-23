namespace qlts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init333567 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FixedAssets", "Field_Id", "dbo.Fields");
            DropForeignKey("dbo.FixedAssets", "FixedAssetStatus_Id", "dbo.FixedAssetStatus");
            DropForeignKey("dbo.FixedAssets", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.FixedAssets", "Warehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.WareHouseAssetsExports", "User_Id", "dbo.Users");
            DropForeignKey("dbo.WareHouseAssetsTransfers", "User_Id", "dbo.Users");
            DropIndex("dbo.FixedAssets", new[] { "Field_Id" });
            DropIndex("dbo.FixedAssets", new[] { "FixedAssetStatus_Id" });
            DropIndex("dbo.FixedAssets", new[] { "Manufacturer_Id" });
            DropIndex("dbo.FixedAssets", new[] { "Warehouse_Id" });
            DropIndex("dbo.WareHouseAssetsExports", new[] { "User_Id" });
            DropIndex("dbo.WareHouseAssetsExports", new[] { "Warehouse_Id" });
            DropIndex("dbo.WareHouseAssetsTransfers", new[] { "User_Id" });
            DropIndex("dbo.WareHouseAssetsTransfers", new[] { "Warehouse_Id" });
            DropColumn("dbo.FixedAssets", "FieldId");
            DropColumn("dbo.FixedAssets", "FixedAssetStatusId");
            DropColumn("dbo.FixedAssets", "ManufacturerId");
            DropColumn("dbo.FixedAssets", "WarehouseId");
            DropColumn("dbo.WareHouseAssetsExports", "UserId");
            DropColumn("dbo.WareHouseAssetsExports", "WarehouseId");
            DropColumn("dbo.WareHouseAssetsTransfers", "UserId");
            DropColumn("dbo.WareHouseAssetsTransfers", "WarehouseId");
            RenameColumn(table: "dbo.FixedAssets", name: "Field_Id", newName: "FieldId");
            RenameColumn(table: "dbo.FixedAssets", name: "FixedAssetStatus_Id", newName: "FixedAssetStatusId");
            RenameColumn(table: "dbo.FixedAssets", name: "Manufacturer_Id", newName: "ManufacturerId");
            RenameColumn(table: "dbo.FixedAssets", name: "Warehouse_Id", newName: "WarehouseId");
            RenameColumn(table: "dbo.WareHouseAssetsExports", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.WareHouseAssetsExports", name: "Warehouse_Id", newName: "WarehouseId");
            RenameColumn(table: "dbo.WareHouseAssetsTransfers", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.WareHouseAssetsTransfers", name: "Warehouse_Id", newName: "WarehouseId");
            AlterColumn("dbo.FixedAssets", "FieldId", c => c.Guid(nullable: false));
            AlterColumn("dbo.FixedAssets", "ManufacturerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.FixedAssets", "FixedAssetStatusId", c => c.Guid(nullable: false));
            AlterColumn("dbo.FixedAssets", "WarehouseId", c => c.Guid(nullable: false));
            AlterColumn("dbo.FixedAssets", "FieldId", c => c.Guid(nullable: false));
            AlterColumn("dbo.FixedAssets", "FixedAssetStatusId", c => c.Guid(nullable: false));
            AlterColumn("dbo.FixedAssets", "ManufacturerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.FixedAssets", "WarehouseId", c => c.Guid(nullable: false));
            AlterColumn("dbo.WareHouseAssetsExports", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.WareHouseAssetsExports", "WarehouseId", c => c.Guid());
            AlterColumn("dbo.WareHouseAssetsExports", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.WareHouseAssetsTransfers", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.WareHouseAssetsTransfers", "WarehouseId", c => c.Guid());
            AlterColumn("dbo.WareHouseAssetsTransfers", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.FixedAssets", "FieldId");
            CreateIndex("dbo.FixedAssets", "ManufacturerId");
            CreateIndex("dbo.FixedAssets", "FixedAssetStatusId");
            CreateIndex("dbo.FixedAssets", "WarehouseId");
            CreateIndex("dbo.WareHouseAssetsExports", "UserId");
            CreateIndex("dbo.WareHouseAssetsExports", "WarehouseId");
            CreateIndex("dbo.WareHouseAssetsTransfers", "UserId");
            CreateIndex("dbo.WareHouseAssetsTransfers", "WarehouseId");
            AddForeignKey("dbo.FixedAssets", "FieldId", "dbo.Fields", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FixedAssets", "FixedAssetStatusId", "dbo.FixedAssetStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FixedAssets", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FixedAssets", "WarehouseId", "dbo.Warehouses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WareHouseAssetsExports", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WareHouseAssetsTransfers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WareHouseAssetsTransfers", "UserId", "dbo.Users");
            DropForeignKey("dbo.WareHouseAssetsExports", "UserId", "dbo.Users");
            DropForeignKey("dbo.FixedAssets", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.FixedAssets", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.FixedAssets", "FixedAssetStatusId", "dbo.FixedAssetStatus");
            DropForeignKey("dbo.FixedAssets", "FieldId", "dbo.Fields");
            DropIndex("dbo.WareHouseAssetsTransfers", new[] { "WarehouseId" });
            DropIndex("dbo.WareHouseAssetsTransfers", new[] { "UserId" });
            DropIndex("dbo.WareHouseAssetsExports", new[] { "WarehouseId" });
            DropIndex("dbo.WareHouseAssetsExports", new[] { "UserId" });
            DropIndex("dbo.FixedAssets", new[] { "WarehouseId" });
            DropIndex("dbo.FixedAssets", new[] { "FixedAssetStatusId" });
            DropIndex("dbo.FixedAssets", new[] { "ManufacturerId" });
            DropIndex("dbo.FixedAssets", new[] { "FieldId" });
            AlterColumn("dbo.WareHouseAssetsTransfers", "UserId", c => c.Guid());
            AlterColumn("dbo.WareHouseAssetsTransfers", "WarehouseId", c => c.String());
            AlterColumn("dbo.WareHouseAssetsTransfers", "UserId", c => c.String());
            AlterColumn("dbo.WareHouseAssetsExports", "UserId", c => c.Guid());
            AlterColumn("dbo.WareHouseAssetsExports", "WarehouseId", c => c.String());
            AlterColumn("dbo.WareHouseAssetsExports", "UserId", c => c.String());
            AlterColumn("dbo.FixedAssets", "WarehouseId", c => c.Guid());
            AlterColumn("dbo.FixedAssets", "ManufacturerId", c => c.Guid());
            AlterColumn("dbo.FixedAssets", "FixedAssetStatusId", c => c.Guid());
            AlterColumn("dbo.FixedAssets", "FieldId", c => c.Guid());
            AlterColumn("dbo.FixedAssets", "WarehouseId", c => c.String());
            AlterColumn("dbo.FixedAssets", "FixedAssetStatusId", c => c.String());
            AlterColumn("dbo.FixedAssets", "ManufacturerId", c => c.String());
            AlterColumn("dbo.FixedAssets", "FieldId", c => c.String());
            RenameColumn(table: "dbo.WareHouseAssetsTransfers", name: "WarehouseId", newName: "Warehouse_Id");
            RenameColumn(table: "dbo.WareHouseAssetsTransfers", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.WareHouseAssetsExports", name: "WarehouseId", newName: "Warehouse_Id");
            RenameColumn(table: "dbo.WareHouseAssetsExports", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.FixedAssets", name: "WarehouseId", newName: "Warehouse_Id");
            RenameColumn(table: "dbo.FixedAssets", name: "ManufacturerId", newName: "Manufacturer_Id");
            RenameColumn(table: "dbo.FixedAssets", name: "FixedAssetStatusId", newName: "FixedAssetStatus_Id");
            RenameColumn(table: "dbo.FixedAssets", name: "FieldId", newName: "Field_Id");
            AddColumn("dbo.WareHouseAssetsTransfers", "WarehouseId", c => c.String());
            AddColumn("dbo.WareHouseAssetsTransfers", "UserId", c => c.String());
            AddColumn("dbo.WareHouseAssetsExports", "WarehouseId", c => c.String());
            AddColumn("dbo.WareHouseAssetsExports", "UserId", c => c.String());
            AddColumn("dbo.FixedAssets", "WarehouseId", c => c.String());
            AddColumn("dbo.FixedAssets", "ManufacturerId", c => c.String());
            AddColumn("dbo.FixedAssets", "FixedAssetStatusId", c => c.String());
            AddColumn("dbo.FixedAssets", "FieldId", c => c.String());
            CreateIndex("dbo.WareHouseAssetsTransfers", "Warehouse_Id");
            CreateIndex("dbo.WareHouseAssetsTransfers", "User_Id");
            CreateIndex("dbo.WareHouseAssetsExports", "Warehouse_Id");
            CreateIndex("dbo.WareHouseAssetsExports", "User_Id");
            CreateIndex("dbo.FixedAssets", "Warehouse_Id");
            CreateIndex("dbo.FixedAssets", "Manufacturer_Id");
            CreateIndex("dbo.FixedAssets", "FixedAssetStatus_Id");
            CreateIndex("dbo.FixedAssets", "Field_Id");
            AddForeignKey("dbo.WareHouseAssetsTransfers", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.WareHouseAssetsExports", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.FixedAssets", "Warehouse_Id", "dbo.Warehouses", "Id");
            AddForeignKey("dbo.FixedAssets", "Manufacturer_Id", "dbo.Manufacturers", "Id");
            AddForeignKey("dbo.FixedAssets", "FixedAssetStatus_Id", "dbo.FixedAssetStatus", "Id");
            AddForeignKey("dbo.FixedAssets", "Field_Id", "dbo.Fields", "Id");
        }
    }
}
