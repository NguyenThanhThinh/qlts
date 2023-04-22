using qlts.Datas;
using qlts.Extensions;
using qlts.Models;
using qlts.ViewModels.Accounts;
using qlts.ViewModels.Users;
using System;
using System.Collections.Generic;
using qlts.Helpers;
using qlts.Stores;
using System.Configuration;

namespace qlts.Handlers
{
    public interface IUserHandler
    {
        User CreateUpdateUser(UserCreateUpdateViewModel model);

        UserCreateUpdateViewModel GetUserById(Guid? id);

        ProfileViewModel GetUserByProfile(Guid? id);
        List<UserIndexViewModel> GetAllUsers();
        bool DeleteUser(Guid? id);

        UserCreateUpdateViewModel UserWithDropdown(UserCreateUpdateViewModel model);

    }

    public class UserHandler : IUserHandler
    {
        private readonly IUserStore _UserStore;
        private readonly IWarehouseStore _warehouseStore;

        public UserHandler(IUserStore userStore, IWarehouseStore _warehouseStore)
        {
            this._UserStore = userStore;
            this._warehouseStore = _warehouseStore;
        }

        public User CreateUpdateUser(UserCreateUpdateViewModel model)
        {
            var user = MapperConfig.Factory.Map<UserCreateUpdateViewModel, User>(model);
            var key = ConfigurationManager.AppSettings["HashPassword"];
            var password = CipherHelper.Encrypt(model.Password, key);
            user.Password = password;
            try
            {
                if (user != null && user.Id != Guid.Empty)
                {
                    user.ModifiedDate = DateTime.Now;
                }

                user = user != null && user.Id != Guid.Empty ? _UserStore.UpdateUser(user) : _UserStore.CreateUser(user);
            }
            catch (Exception ex)
            {
                if (ex.IsDuplicateEntity())
                    throw new BusinessException("Tài khoản đã bị trùng");
                else if (ex.IsDuplicateCode())
                    throw new BusinessException("Tài khoản đã bị trùng");

                throw ex;
            }

            return user;
        }



        public bool DeleteUser(Guid? id)
        {
            return _UserStore.DeleteUser(id);
        }

        public List<UserIndexViewModel> GetAllUsers()
        {
            var users = _UserStore.GetAllUsers();
            return MapperConfig.Factory.Map<List<User>, List<UserIndexViewModel>>(users);
        }

        public UserCreateUpdateViewModel GetUserById(Guid? id)
        {
            if (id == null)
                return UserWithDropdown(new UserCreateUpdateViewModel());

            var user = _UserStore.GetUserById(id);

            if (user == null) return null;

            var model = MapperConfig.Factory.Map<User, UserCreateUpdateViewModel>(user);

            var password = CipherHelper.Decrypt(model.Password, ConfigurationManager.AppSettings["HashPassword"]);
            model.Password = password;
            model.ConfirmPassword = password;
            return UserWithDropdown(model);
        }

        public ProfileViewModel GetUserByProfile(Guid? id)
        {
            if (id == null)
                return new ProfileViewModel();

            var user = _UserStore.GetUserById(id);

            if (user == null) return null;

            var model = MapperConfig.Factory.Map<User, ProfileViewModel>(user);

            var password = CipherHelper.Decrypt(model.Password, ConfigurationManager.AppSettings["HashPassword"]);
            model.Password = password;
            model.ConfirmPassword = password;
            return model;
        }

        public UserCreateUpdateViewModel UserWithDropdown(UserCreateUpdateViewModel model)
        {
            if (model == null)
                throw new BusinessException("Không có dữ liệu");

            model.Warehouses = _warehouseStore.GetWarehouseDropdown();
            return model;
        }
    }
}