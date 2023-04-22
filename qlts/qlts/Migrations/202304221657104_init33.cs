namespace qlts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init33 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_FixedAssets", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_FixedAssets", "Note");
        }
    }
}
