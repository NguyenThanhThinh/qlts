using oclockvn.Repository;
using System.Data.Entity;
using System.Threading.Tasks;
using qlts.Models;

namespace qlts.Stores
{
    public interface IAuthenStore
    {
        Task<User> CheckLogin(string username, string password);
    }

    public class AuthenStore : IAuthenStore
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<User> authenRepo;
        public AuthenStore(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            authenRepo = unitOfWork.Get<User>();
        }

        public async Task<User> CheckLogin(string username, string password)
        {
            return await authenRepo.All.Include(n => n.Role).SingleOrDefaultAsync(n => n.UserName == username && n.Password == password);
        }
    }
}