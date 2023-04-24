using AutoMapper;
using qlts.Enums;
using qlts.Extensions;
using qlts.Models;
using qlts.ViewModels.Accounts;
using qlts.ViewModels.Fields;
using qlts.ViewModels.FixedAssets;
using qlts.ViewModels.FixedAssetStatus;
using qlts.ViewModels.Manufacturers;
using qlts.ViewModels.Users;
using qlts.ViewModels.Warehouses;
using System;

namespace qlts
{
    public class MapperConfig
    {
        public static IMapper Factory { get; private set; }

        public static void Register()
        {
            var op = new MapperConfiguration(config =>
            {
                config.CreateMap<AccountLoginViewModel, User>();
                config.CreateMap<AccountCreateUpdateViewModel, User>();

                config.CreateMap<ProfileViewModel, User>();

                config.CreateMap<User, ProfileViewModel>();

                config.CreateMap<User, UserIndexViewModel>()
                 .ForMember(x => x.WarehouseName,
                        map => map.MapFrom(x => x.Warehouse == null ? string.Empty : x.Warehouse.Name))
                  .ForMember(x => x.WarehouseCenter,
                        map => map.MapFrom(x => x.Warehouse == null ? string.Empty : x.Warehouse.Center.GetDisplayName()))
                       .ForMember(x => x.WarehouseUnit,
                        map => map.MapFrom(x => x.Warehouse == null ? string.Empty : x.Warehouse.Unit.GetDisplayName()));
                config.CreateMap<User, UserCreateUpdateViewModel>();
                config.CreateMap<UserCreateUpdateViewModel, User>();



                config.CreateMap<User, UserIndexViewModel>();
                config.CreateMap<User, UserCreateUpdateViewModel>();
                config.CreateMap<UserCreateUpdateViewModel, User>();


                config.CreateMap<Warehouse, WarehouseIndexViewModel>();
                config.CreateMap<Warehouse, WarehouseCreateUpdateViewModel>();
                config.CreateMap<WarehouseCreateUpdateViewModel, Warehouse>();


                config.CreateMap<FixedAsset, FixedAssetIndexViewModel>()
                 .ForMember(x => x.WarehouseName,
                        map => map.MapFrom(x => x.Warehouse == null ? string.Empty : x.Warehouse.Name))
                 .ForMember(x => x.Center,
                     map => map.MapFrom(x => x.Warehouse == null ? 0 : x.Warehouse.Center))
                         .ForMember(x => x.FieldName,
                        map => map.MapFrom(x => x.Field == null ? string.Empty : x.Field.Name))
                         .ForMember(x => x.ManufacturerName,
                        map => map.MapFrom(x => x.Manufacturer == null ? string.Empty : x.Manufacturer.Name))
                         .ForMember(x => x.FixedAssetStatusName,
                        map => map.MapFrom(x => x.FixedAssetStatus == null ? string.Empty : x.FixedAssetStatus.Name))
                         .ForMember(x => x.ManufacturerDate,
                        map => map.MapFrom(x => x.Manufacturer == null ? DateTime.Now : x.Manufacturer.Date))
                        .ForMember(x => x.WarrantyPeriodDate,
                        map => map.MapFrom(x => x.Manufacturer == null ? DateTime.Now : x.Manufacturer.WarrantyPeriodDate));
                config.CreateMap<FixedAsset, FixedAssetCreateUpdateViewModel>()
                 .AfterMap((m, vm) =>
                 {
                     vm.CostFormatted = vm.Price.ToMoneyFormatted();
                 });
                config.CreateMap<FixedAssetCreateUpdateViewModel, FixedAsset>()
                 .BeforeMap((vm, m) =>
                 {
                     vm.Price = vm.CostFormatted.ToMoney();
                 });


                config.CreateMap<Field, FieldIndexViewModel>();
                config.CreateMap<Field, FieldCreateUpdateViewModel>();
                config.CreateMap<FieldCreateUpdateViewModel, Field>();

                config.CreateMap<Manufacturer, ManufacturerIndexViewModel>();
                config.CreateMap<Manufacturer, ManufacturerCreateUpdateViewModel>();
                config.CreateMap<ManufacturerCreateUpdateViewModel, Manufacturer>();

                config.CreateMap<FixedAssetStatus, FixedAssetStatusIndexViewModel>();
                config.CreateMap<FixedAssetStatus, FixedAssetStatusCreateUpdateViewModel>();
                config.CreateMap<FixedAssetStatusCreateUpdateViewModel, FixedAssetStatus>();

            });

            Factory = op.CreateMapper();
        }
    }
}