using qlts.Models;
using qlts.ViewModels.Roles;
using oclockvn.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using qlts.Datas;
using System;

namespace qlts.Stores
{
    public interface IRoleStore
    {
        List<Role> GetAllRoles();
        Role GetRoleById(Guid? id);
        Role CreateRole(Role role);
        Role UpdateRole(Role role);
        bool DeleteRole(Guid? id);

        List<DropdownModel> GetRoleDropdown();

        Task<List<RoleIndexViewModel>> GetRoles(string keyword, int page = 1);
    }

    public class RoleStore : IRoleStore
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Role> _roleRepo;

        public RoleStore(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _roleRepo = unitOfWork.Get<Role>();
        }

        public Role CreateRole(Role Role)
        {
            var result = _roleRepo.Create(Role);
            return _unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteRole(Guid? id)
        {
            _roleRepo.Delete(n => n.Id == id);
            return _unitOfWork.SaveChanges() > 0;
        }

        public List<Role> GetAllRoles()
        {
            return _roleRepo.GetAll(null);
        }

        public Role GetRoleById(Guid? id)
        {
            return _roleRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetRoleDropdown()
        {
            return _roleRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.Id,
                    Text = x.Description
                }).ToList();
        }

        public async Task<List<RoleIndexViewModel>> GetRoles(string keyword, int page = 1)
        {
            const int pageSize = 10;
            var data = await this._roleRepo.All
                .OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(n => n.Name.Contains(keyword) || n.Description.Contains(keyword)).ToList();
            }
            return MapperConfig.Factory.Map<List<Role>, List<RoleIndexViewModel>>(data);
        }

        public Role UpdateRole(Role role)
        {
            var result = _roleRepo.Update(role);
            return _unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}