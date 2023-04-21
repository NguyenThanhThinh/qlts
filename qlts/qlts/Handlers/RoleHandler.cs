using qlts.Datas;
using qlts.Extensions;
using qlts.Models;
using qlts.Stores;
using qlts.ViewModels.Roles;
using System;
using System.Collections.Generic;

namespace qlts.Handlers
{
    public interface IRoleHandler
    {
        Role CreateUpdateRole(RoleCreateUpdateViewModel model);
        RoleCreateUpdateViewModel GetRoleById(Guid? id);
        List<RoleIndexViewModel> GetAllRoles();
        bool DeleteRole(Guid? id);

    }

    public class RoleHandler : IRoleHandler
    {
        private readonly IRoleStore _roleStore;

        public RoleHandler(IRoleStore roleStore)
        {
            this._roleStore = roleStore;
        }

        public Role CreateUpdateRole(RoleCreateUpdateViewModel model)
        {
            var role = MapperConfig.Factory.Map<RoleCreateUpdateViewModel, Role>(model);

            try
            {
                if (role != null && role.Id != null) role.ModifiedDate = DateTime.Now;
                role = role != null && role.Id != null ? _roleStore.UpdateRole(role) : _roleStore.CreateRole(role);
            }
            catch (Exception ex)
            {
                if (ex.IsDuplicateEntity())
                    throw new BusinessException("Tên quyền đã bị trùng");
                else if (ex.IsDuplicateCode())
                    throw new BusinessException("Tên quyền đã bị trùng");

                throw ex;
            }

            return role;
        }

        public bool DeleteRole(Guid? id)
        {
            return _roleStore.DeleteRole(id);
        }

        public List<RoleIndexViewModel> GetAllRoles()
        {
            var roles = _roleStore.GetAllRoles();
            return MapperConfig.Factory.Map<List<Role>, List<RoleIndexViewModel>>(roles);
        }

        public RoleCreateUpdateViewModel GetRoleById(Guid? id)
        {
            if (id == null)
                return new RoleCreateUpdateViewModel();

            var role = _roleStore.GetRoleById(id);
            return role == null ? null : MapperConfig.Factory.Map<Role, RoleCreateUpdateViewModel>(role);
        }

    }
}