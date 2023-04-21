using AutoMapper;
using qlts.Models;
using qlts.ViewModels.Accounts;
using qlts.ViewModels.Roles;
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

                config.CreateMap<Role, RoleIndexViewModel>();
                config.CreateMap<Role, RoleCreateUpdateViewModel>();
                config.CreateMap<RoleCreateUpdateViewModel, Role>();

                config.CreateMap<User, UserIndexViewModel>();
                config.CreateMap<User, UserCreateUpdateViewModel>();
                config.CreateMap<UserCreateUpdateViewModel, User>();



                config.CreateMap<User, UserIndexViewModel>();
                config.CreateMap<User, UserCreateUpdateViewModel>();
                config.CreateMap<UserCreateUpdateViewModel, User>();


                config.CreateMap<Warehouse, WarehouseIndexViewModel>();
                config.CreateMap<Warehouse, WarehouseCreateUpdateViewModel>();
                config.CreateMap<WarehouseCreateUpdateViewModel, Warehouse>();
            });

            Factory = op.CreateMapper();
        }
    }
}