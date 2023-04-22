namespace qlts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init33356 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Warehouse_Id", "dbo.Warehouses");
            DropIndex("dbo.Users", new[] { "Warehouse_Id" });
            DropColumn("dbo.Users", "WarehouseId");
            RenameColumn(table: "dbo.Users", name: "Warehouse_Id", newName: "WarehouseId");
            AlterColumn("dbo.Users", "WarehouseId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "WarehouseId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Users", "WarehouseId");
            AddForeignKey("dbo.Users", "WarehouseId", "dbo.Warehouses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "WarehouseId", "dbo.Warehouses");
            DropIndex("dbo.Users", new[] { "WarehouseId" });
            AlterColumn("dbo.Users", "WarehouseId", c => c.Guid());
            AlterColumn("dbo.Users", "WarehouseId", c => c.String());
            RenameColumn(table: "dbo.Users", name: "WarehouseId", newName: "Warehouse_Id");
            AddColumn("dbo.Users", "WarehouseId", c => c.String());
            CreateIndex("dbo.Users", "Warehouse_Id");
            AddForeignKey("dbo.Users", "Warehouse_Id", "dbo.Warehouses", "Id");
        }
    }
}
