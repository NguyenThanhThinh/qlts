using qlts.Models;
using qlts.Stores;
using qlts.ViewModels.Accounts;
using System.Threading.Tasks;
using toys.Helpers;

namespace qlts.Handlers
{
    public interface IAuthenHandler
    {
        Task<User> CheckLogin(AccountLoginViewModel model);
    }

    public class AuthenHandler : IAuthenHandler
    {
        private readonly IAuthenStore authenStore;
        public AuthenHandler(IAuthenStore authenStore)
        {
            this.authenStore = authenStore;
        }
        public async Task<User> CheckLogin(AccountLoginViewModel model)
        {
            var staff = MapperConfig.Factory.Map<AccountLoginViewModel, User>(model);
            var passwordHashing = "ABCDRETEWEXDDVVCFGE1996";
            var password = CipherHelper.Encrypt(model.Password, passwordHashing);
            return await authenStore.CheckLogin(staff.UserName, password);
        }
    }
}