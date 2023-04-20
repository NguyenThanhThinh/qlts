using qlts.Datas;
using qlts.Extensions;
using qlts.Models;
using qlts.Stores;
using qlts.ViewModels.Roles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace qlts.Handlers
{
    public interface IRoleHandler
    {
        Role CreateUpdateRole(RoleCreateUpdateViewModel model);
        RoleCreateUpdateViewModel GetRoleById(int? id);
        List<RoleIndexViewModel> GetAllRoles();
        bool DeleteRole(int? id);

        Task<IEnumerable<RoleIndexViewModel>> GetRoles(string keyword, int page = 1);
    }

    public class RoleHandler : IRoleHandler
    {
        private readonly IRoleStore RoleStore;

        public RoleHandler(IRoleStore RoleStore)
        {
            this.RoleStore = RoleStore;
        }

        public Role CreateUpdateRole(RoleCreateUpdateViewModel model)
        {
            var Role = MapperConfig.Factory.Map<RoleCreateUpdateViewModel, Role>(model);

            try
            {
                if (Role.Id > 0) Role.ModifiedDate = DateTime.Now;
                Role = Role.Id > 0 ? RoleStore.UpdateRole(Role) : RoleStore.CreateRole(Role);
            }
            catch (Exception ex)
            {
                if (ex.IsDuplicateEntity())
                    throw new BusinessException("Tên quyền đã bị trùng");
                else if (ex.IsDuplicateCode())
                    throw new BusinessException("Tên quyền đã bị trùng");

                throw ex;
            }

            return Role;
        }

        public bool DeleteRole(int? id)
        {
            return RoleStore.DeleteRole(id);
        }

        public List<RoleIndexViewModel> GetAllRoles()
        {
            var roles = RoleStore.GetAllRoles();
            return MapperConfig.Factory.Map<List<Role>, List<RoleIndexViewModel>>(roles);
        }

        public RoleCreateUpdateViewModel GetRoleById(int? id)
        {
            if (id == null || id == 0)
                return new RoleCreateUpdateViewModel();

            var role = RoleStore.GetRoleById(id);
            return role == null ? null : MapperConfig.Factory.Map<Role, RoleCreateUpdateViewModel>(role);
        }

        public async Task<IEnumerable<RoleIndexViewModel>> GetRoles(string keyword, int page = 1)
        {
            return await RoleStore.GetRoles(keyword, page);
        }
    }
}