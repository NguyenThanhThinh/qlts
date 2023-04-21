using qlts.Models;
using oclockvn.Repository;
using System.Collections.Generic;
using System.Linq;
using qlts.Datas;
using System;
using System.Data.Entity;

namespace qlts.Stores
{
    public interface IUserStore
    {
        List<User> GetAllUsers();
        User GetUserById(Guid? id);
        User CreateUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(Guid? id);

        List<DropdownModel> GetUserDropdown();

    }

    public class UserStore : IUserStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<User> _userRepo;

        public UserStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _userRepo = unitOfWork.Get<User>();
        }

        public User CreateUser(User user)
        {
            var result = _userRepo.Create(user);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteUser(Guid? id)
        {
            _userRepo.Delete(n => n.Id == id);
            return unitOfWork.SaveChanges() > 0;
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.All.Include(n=>n.Warehouse).ToList();
        }

        public User GetUserById(Guid? id)
        {
            return _userRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetUserDropdown()
        {
            return _userRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.Id,
                    Text = x.Name
                }).ToList();
        }

        public User UpdateUser(User user)
        {
            var result = _userRepo.Update(user);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}