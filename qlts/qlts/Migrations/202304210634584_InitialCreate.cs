namespace qlts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_Fields",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        Unit = c.String(),
                        PartNumber = c.String(),
                        SerialNumber = c.String(),
                        FieldId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        FixedAssetStatusId = c.Int(nullable: false),
                        FixedAssetDate = c.DateTime(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedAssetType = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.DateTime(),
                        Field_Id = c.Guid(),
                        FixedAssetStatus_Id = c.Guid(),
                        Manufacturer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBL_Fields", t => t.Field_Id)
                .ForeignKey("dbo.TBL_FixedAssetStatus", t => t.FixedAssetStatus_Id)
                .ForeignKey("dbo.TBL_Manufacturers", t => t.Manufacturer_Id)
                .Index(t => t.Field_Id)
                .Index(t => t.FixedAssetStatus_Id)
                .Index(t => t.Manufacturer_Id);
            
            CreateTable(
                "dbo.TBL_FixedAssetStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Date = c.DateTime(),
                        Note = c.String(),
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
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 12),
                        WarehouseId = c.Int(nullable: false),
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
                "dbo.TBL_Warehouses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        Center = c.Int(nullable: false),
                        Unit = c.String(maxLength: 100),
                        Address = c.String(maxLength: 200),
                        Note = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WareHouseAssetsTransfers",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WareHouseAssetsTransfers", "Warehouse_Id", "dbo.TBL_Warehouses");
            DropForeignKey("dbo.WareHouseAssetsTransfers", "User_Id", "dbo.TBL_Users");
            DropForeignKey("dbo.WareHouseAssetsTransfers", "FixedAsset_Id", "dbo.TBL_FixedAssets");
            DropForeignKey("dbo.TBL_Users", "Warehouse_Id", "dbo.TBL_Warehouses");
            DropForeignKey("dbo.TBL_FixedAssets", "Manufacturer_Id", "dbo.TBL_Manufacturers");
            DropForeignKey("dbo.TBL_FixedAssets", "FixedAssetStatus_Id", "dbo.TBL_FixedAssetStatus");
            DropForeignKey("dbo.TBL_FixedAssets", "Field_Id", "dbo.TBL_Fields");
            DropIndex("dbo.WareHouseAssetsTransfers", new[] { "Warehouse_Id" });
            DropIndex("dbo.WareHouseAssetsTransfers", new[] { "User_Id" });
            DropIndex("dbo.WareHouseAssetsTransfers", new[] { "FixedAsset_Id" });
            DropIndex("dbo.TBL_Users", new[] { "Warehouse_Id" });
            DropIndex("dbo.TBL_Users", new[] { "UserName" });
            DropIndex("dbo.TBL_FixedAssets", new[] { "Manufacturer_Id" });
            DropIndex("dbo.TBL_FixedAssets", new[] { "FixedAssetStatus_Id" });
            DropIndex("dbo.TBL_FixedAssets", new[] { "Field_Id" });
            DropTable("dbo.WareHouseAssetsTransfers");
            DropTable("dbo.TBL_Warehouses");
            DropTable("dbo.TBL_Users");
            DropTable("dbo.TBL_Manufacturers");
            DropTable("dbo.TBL_FixedAssetStatus");
            DropTable("dbo.TBL_FixedAssets");
            DropTable("dbo.TBL_Fields");
        }
    }
}
