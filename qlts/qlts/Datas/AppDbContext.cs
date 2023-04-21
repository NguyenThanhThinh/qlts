using qlts.Models;
using System.Data.Entity;

namespace qlts.Datas
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Field> Fields { get; set; }

        public DbSet<FixedAsset> FixedAssets { get; set; }

        public DbSet<FixedAssetStatus> FixedAssetStatus { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<WareHouseAssetsTransfer> WareHouseAssetsTransfers { get; set; }

        public DbSet<WareHouseAssetsExport> WareHouseAssetsExport { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}