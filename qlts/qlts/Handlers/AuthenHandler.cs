using qlts.Models;
using qlts.Stores;
using qlts.ViewModels.Accounts;
using System.Configuration;
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
            var staff    = MapperConfig.Factory.Map<AccountLoginViewModel, User>(model);
            var password = CipherHelper.Encrypt(model.Password, ConfigurationManager.AppSettings["HashPassword"]);
            return await authenStore.CheckLogin(staff.UserName, password);
        }
    }
}