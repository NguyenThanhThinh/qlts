using AutoMapper;
using qlts.Extensions;
using qlts.Models;
using qlts.ViewModels.Accounts;
using qlts.ViewModels.FixedAssets;
using qlts.ViewModels.Users;
using qlts.ViewModels.Warehouses;


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


                config.CreateMap<FixedAsset, FixedAssetIndexViewModel>();
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
            });

            Factory = op.CreateMapper();
        }
    }
}