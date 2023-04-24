using System.Collections.Generic;
using System.Configuration;
using qlts.Enums;
using qlts.Helpers;
using qlts.Models;

namespace qlts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<qlts.Datas.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(qlts.Datas.AppDbContext context)
        {
           CreateWarehouse ( context );

           CreateFixedAssetStatus ( context );

           CreateManufacturer ( context );

           CreateField ( context );

           //CreateUser ( context );
        }

        private void CreateWarehouse(Datas.AppDbContext context)
        {
            if ( !context.Warehouses.Any() )
            {
                var listWarehouse = new List<Warehouse>()
                                    {
                                        new Warehouse()
                                        {
                                            Id = Guid.Parse( "DA9C8BED-CF21-4FD1-A704-E557AFF46269" ),
                                            Center = CenterUnit.N1,
                                            Unit = WarehouseUnit.KTTC,
                                            Name = "NET1.KTTC.DP",
                                            Address = "Kho dự phòng NET1, tòa nhà VNPT Net1, thành phố Hà Nội.",
                                            Note = "Tài sản mua sắm mới hoặc sau khi được bảo hành sữa chữa, thu hồi tốt được nhập về kho dự phòng",
                                            CreatedDate = DateTime.Now,
                                            WarehouseType = WarehouseType.DP
                                        },
                                        new Warehouse()
                                        { 
                                            Id =  Guid.Parse( "6844B684-E3E2-426D-B4C1-39489CED3871" ),
                                            Center = CenterUnit.N1,
                                            Unit = WarehouseUnit.KTTC,
                                            Name = "NET1.KTTC.TH",
                                            Address = "Kho thu hồi NET1, tòa nhà VNPT Net1, thành phố Hà Nội.",
                                            CreatedDate = DateTime.Now,
                                            WarehouseType = WarehouseType.TH
                                        },
                                        new Warehouse()
                                        {
                                            Id = Guid.Parse("99474F1A-169C-401D-ABBE-A582BD30D245"),
                                            Center = CenterUnit.N1,
                                            Unit = WarehouseUnit.KTTC,
                                            Name = "NET1.KTTC.BH",
                                            Address = "Kho bảo hành NET1, tòa nhà VNPT Net1, thành phố Hà Nội.",
                                            CreatedDate = DateTime.Now,
                                            WarehouseType = WarehouseType.BH
                                        },
                                        new Warehouse()
                                        {
                                            Id = Guid.Parse("8CC5A71F-A3A1-423B-BBAE-78C071AB4C22"),
                                            Center = CenterUnit.N1,
                                            Unit = WarehouseUnit.KTTC,
                                            Name = "NNET1.KTTC.SC",
                                            Address = "Kho sữa chữa NET1, tòa nhà VNPT Net1, thành phố Hà Nội.",
                                            CreatedDate = DateTime.Now,
                                            WarehouseType = WarehouseType.SC
                                        }
                                    };

                foreach ( var item in listWarehouse )
                {
                    item.Id = Guid.NewGuid();
                    context.Warehouses.Add ( item );
                    context.SaveChanges();
                    Thread.Sleep(200);
                }
            }
        }

        private void CreateFixedAssetStatus(Datas.AppDbContext context)
        {
            if (!context.FixedAssetStatus.Any())
            {
                var listFixedAssetStatus = new List<FixedAssetStatus>()
                                           {
                                               new FixedAssetStatus()
                                               {
                                                  
                                                   Name = "Mua mới",
                                                   CreatedDate = DateTime.Now
                                               },
                                               new FixedAssetStatus()
                                               {

                                                   Name = "Sử dụng",
                                                   CreatedDate = DateTime.Now
                                               },
                                               new FixedAssetStatus()
                                               {

                                                   Name = "Thu hồi",
                                                   CreatedDate = DateTime.Now
                                               },
                                               new FixedAssetStatus()
                                               {

                                                   Name = "Bảo hành",
                                                   CreatedDate = DateTime.Now
                                               },
                                               new FixedAssetStatus()
                                               {

                                                   Name = "Sửa chữa",
                                                   CreatedDate = DateTime.Now
                                               },
                                               new FixedAssetStatus()
                                               {

                                                   Name = "Thanh lý",
                                                   CreatedDate = DateTime.Now
                                               }
                                           };

                foreach ( var item in listFixedAssetStatus )
                {
                    item.Id = Guid.NewGuid();
                    context.FixedAssetStatus.Add(item);
                    context.SaveChanges();
                    Thread.Sleep(200);
                }
            }
        }

        private void CreateManufacturer(Datas.AppDbContext context)
        {
            if (!context.Manufacturers.Any())
            {
                var listManufacturer = new List<Manufacturer>()
                                       {
                                           new Manufacturer()
                                           {

                                               Name = "CISCO",
                                               Date = new DateTime ( 2023,1,1 ),
                                               WarrantyPeriodDate = new DateTime ( 2024,1,1 ),
                                               CreatedDate = DateTime.Now
                                           },
                                           new Manufacturer()
                                           {

                                               Name = "IBM",
                                               Date = new DateTime ( 2023,1,1 ),
                                               WarrantyPeriodDate = new DateTime ( 2024,1,1 ),
                                               CreatedDate = DateTime.Now
                                           },
                                           new Manufacturer()
                                           {


                                               Name = "JUNIPER",
                                               Date = new DateTime ( 2023,1,1 ),
                                               WarrantyPeriodDate = new DateTime ( 2024,1,1 ),
                                               CreatedDate = DateTime.Now
                                           },
                                           new Manufacturer()
                                           {


                                               Name = "ALCATEL-LUCENT",
                                               Date = new DateTime ( 2023,1,1 ),
                                               WarrantyPeriodDate = new DateTime ( 2024,1,1 ),
                                               CreatedDate = DateTime.Now
                                           },
                                           
                                       };

                foreach (var item in listManufacturer)
                {
                    item.Id = Guid.NewGuid();
                    context.Manufacturers.Add(item);
                    context.SaveChanges();
                    Thread.Sleep(200);
                }
            }
        }


        private void CreateField(Datas.AppDbContext context)
        {
            if (!context.Fields.Any())
            {
                var listField = new List<Field>()
                                {
                                    new Field()
                                    {

                                        Name = "Chuyển mạch, IP",
                                        Note = "Chuyển mạch, IP",
                                        CreatedDate = DateTime.Now
                                    },
                                    new Field()
                                    {

                                        Name = "Truyền dẫn",
                                        CreatedDate = DateTime.Now
                                    },
                                    new Field()
                                    {

                                        Name = "Vô tuyến",
                                        CreatedDate = DateTime.Now
                                    },
                                    new Field()
                                    {

                                        Name = "Nguồn điện",
                                        CreatedDate = DateTime.Now
                                    },
                                    new Field()
                                    {

                                        Name = "Điều hòa",
                                        CreatedDate = DateTime.Now
                                    },
                                    new Field()
                                    {

                                        Name = "Cáp quang",
                                        CreatedDate = DateTime.Now
                                    }
                                };
                foreach (var item in listField)
                {
                    item.Id = Guid.NewGuid();
                    context.Fields.Add(item);
                    context.SaveChanges();
                    Thread.Sleep(200);
                }
            }
        }

        private void CreateUser( Datas.AppDbContext context )
        {
            if ( !context.Users.Any() )
            {
                var key      = ConfigurationManager.AppSettings["HashPassword"];
                var password = CipherHelper.Encrypt("sa@123", key);
                var listUser = new List<User>()
                                {
                                    new User()
                                    {

                                        Name = "Trần Quốc Dũng",
                                        Email = "dungtq@vnpt.vn",
                                        UserName = "dungtq",
                                        Password = password,
                                        Phone = "0916234683",
                                        Position = PositionType.AccountingManager,
                                        WarehouseId = new Guid ( "DA9C8BED-CF21-4FD1-A704-E557AFF46269" ),
                                        CreatedDate = DateTime.Now
                                    },

                                    new User()
                                    {

                                        Name = "Nguyễn Hữu Dũng",
                                        Email = "dungnh@vnpt.vn",
                                        UserName = "dungnh",
                                        Password = password,
                                        Phone = "0943533164",
                                        Position = PositionType.Warehouseman,
                                        WarehouseId = new Guid ( "DA9C8BED-CF21-4FD1-A704-E557AFF46269" ),
                                        CreatedDate = DateTime.Now
                                    },

                                };
                context.Users.AddRange(listUser);
                context.SaveChanges();
            }
        }
    }
}
