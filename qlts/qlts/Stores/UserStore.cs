using qlts.Models;
using oclockvn.Repository;
using System.Collections.Generic;
using System.Linq;
using qlts.Datas;
using System;

namespace qlts.Stores
{
    public interface IUserStore
    {
        List<User> GetAllUsers();
        User GetUserById(Guid? id);
        User CreateUser(User User);
        User UpdateUser(User User);
        bool DeleteUser(Guid? id);

        List<DropdownModel> GetUserDropdown();

    }

    public class UserStore : IUserStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<User> UserRepo;

        public UserStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            UserRepo = unitOfWork.Get<User>();
        }

        public User CreateUser(User User)
        {
            var result = UserRepo.Create(User);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }

        public bool DeleteUser(Guid? id)
        {
            UserRepo.Delete(n => n.Id == id);
            return unitOfWork.SaveChanges() > 0;
        }

        public List<User> GetAllUsers()
        {
            return UserRepo.GetAll(null);
        }

        public User GetUserById(Guid? id)
        {
            return UserRepo.Get(n => n.Id == id);
        }

        public List<DropdownModel> GetUserDropdown()
        {
            return UserRepo.GetAll(null).OrderBy(x => x.Name)
                .Select(x => new DropdownModel
                {
                    Id = x.Id,
                    Text = x.Name
                }).ToList();
        }

        public User UpdateUser(User User)
        {
            var result = UserRepo.Update(User);
            return unitOfWork.SaveChanges() > 0 ? result : null;
        }
    }
}