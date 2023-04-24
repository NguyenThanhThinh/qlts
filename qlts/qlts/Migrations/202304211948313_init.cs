namespace qlts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_Fields",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Note = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBL_FixedAssets",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        Unit = c.Int(nullable: false),
                        PartNumber = c.String(),
                        SerialNumber = c.String(),
                        FieldId = c.String(),
                        ManufacturerId = c.String(),
                        FixedAssetStatusId = c.String(),
                        FixedAssetDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedAssetType = c.Int(nullable: false),
                        WarehouseId = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.DateTime(),
                        Field_Id = c.Guid(),
                        FixedAssetStatus_Id = c.Guid(),
                        Manufacturer_Id = c.Guid(),
                        Warehouse_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBL_Fields", t => t.Field_Id)
                .ForeignKey("dbo.TBL_FixedAssetStatus", t => t.FixedAssetStatus_Id)
                .ForeignKey("dbo.TBL_Manufacturers", t => t.Manufacturer_Id)
                .ForeignKey("dbo.TBL_Warehouses", t => t.Warehouse_Id)
                .Index(t => t.Field_Id)
                .Index(t => t.FixedAssetStatus_Id)
                .Index(t => t.Manufacturer_Id)
                .Index(t => t.Warehouse_Id);
            
            CreateTable(
                "dbo.TBL_FixedAssetStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Note = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBL_Manufacturers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Date = c.DateTime(nullable: false),
                        Note = c.String(),
                        WarrantyPeriodDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBL_Warehouses",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(nullable: false, maxLength: 200),
                        Center = c.Int(nullable: false),
                        Unit = c.Int(nullable: false),
                        Address = c.String(maxLength: 200),
                        Note = c.String(),
                        WarehouseType = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBL_Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 12),
                        WarehouseId = c.String(),
                        Note = c.String(maxLength: 500),
                        Position = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.DateTime(),
                        Warehouse_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBL_Warehouses", t => t.Warehouse_Id)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.Warehouse_Id);
            
            CreateTable(
                "dbo.TBL_WareHouseAssetsExports",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FixedAssetId = c.String(),
                        UserId = c.String(),
                        Note = c.String(),
                        Date = c.DateTime(nullable: false),
                        WarehouseId = c.String(),
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
            
            CreateTable(
                "dbo.TBL_WareHouseAssetsTransfers",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FixedAssetId = c.String(),
                        UserId = c.String(),
                        Note = c.String(),
                        Date = c.DateTime(nullable: false),
                        WarehouseId = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBL_WareHouseAssetsTransfers", "Warehouse_Id", "dbo.TBL_Warehouses");
            DropForeignKey("dbo.TBL_WareHouseAssetsTransfers", "User_Id", "dbo.TBL_Users");
            DropForeignKey("dbo.TBL_WareHouseAssetsTransfers", "FixedAsset_Id", "dbo.TBL_FixedAssets");
            DropForeignKey("dbo.TBL_WareHouseAssetsExports", "Warehouse_Id", "dbo.TBL_Warehouses");
            DropForeignKey("dbo.TBL_WareHouseAssetsExports", "User_Id", "dbo.TBL_Users");
            DropForeignKey("dbo.TBL_WareHouseAssetsExports", "FixedAsset_Id", "dbo.TBL_FixedAssets");
            DropForeignKey("dbo.TBL_Users", "Warehouse_Id", "dbo.TBL_Warehouses");
            DropForeignKey("dbo.TBL_FixedAssets", "Warehouse_Id", "dbo.TBL_Warehouses");
            DropForeignKey("dbo.TBL_FixedAssets", "Manufacturer_Id", "dbo.TBL_Manufacturers");
            DropForeignKey("dbo.TBL_FixedAssets", "FixedAssetStatus_Id", "dbo.TBL_FixedAssetStatus");
            DropForeignKey("dbo.TBL_FixedAssets", "Field_Id", "dbo.TBL_Fields");
            DropIndex("dbo.TBL_WareHouseAssetsTransfers", new[] { "Warehouse_Id" });
            DropIndex("dbo.TBL_WareHouseAssetsTransfers", new[] { "User_Id" });
            DropIndex("dbo.TBL_WareHouseAssetsTransfers", new[] { "FixedAsset_Id" });
            DropIndex("dbo.TBL_WareHouseAssetsExports", new[] { "Warehouse_Id" });
            DropIndex("dbo.TBL_WareHouseAssetsExports", new[] { "User_Id" });
            DropIndex("dbo.TBL_WareHouseAssetsExports", new[] { "FixedAsset_Id" });
            DropIndex("dbo.TBL_Users", new[] { "Warehouse_Id" });
            DropIndex("dbo.TBL_Users", new[] { "UserName" });
            DropIndex("dbo.TBL_FixedAssets", new[] { "Warehouse_Id" });
            DropIndex("dbo.TBL_FixedAssets", new[] { "Manufacturer_Id" });
            DropIndex("dbo.TBL_FixedAssets", new[] { "FixedAssetStatus_Id" });
            DropIndex("dbo.TBL_FixedAssets", new[] { "Field_Id" });
            DropTable("dbo.TBL_WareHouseAssetsTransfers");
            DropTable("dbo.TBL_WareHouseAssetsExports");
            DropTable("dbo.TBL_Users");
            DropTable("dbo.TBL_Warehouses");
            DropTable("dbo.TBL_Manufacturers");
            DropTable("dbo.TBL_FixedAssetStatus");
            DropTable("dbo.TBL_FixedAssets");
            DropTable("dbo.TBL_Fields");
        }
    }
}
