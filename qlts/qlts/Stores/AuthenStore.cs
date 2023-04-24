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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _authenRepo;
        public AuthenStore(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _authenRepo = unitOfWork.Get<User>();
        }

        public async Task<User> CheckLogin(string username, string password)
        {
            return await _authenRepo.All.AsNoTracking().Include(n => n.Warehouse).SingleOrDefaultAsync(n => n.UserName == username && n.Password == password);
        }
    }
}