using Microsoft.AspNetCore.Identity;

using ShopBE.Web.API.Models;

namespace ShopBE.Web.API.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
        
    }
}
