using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Data.Repository.IRepository
{
    public interface IAuthRepository
    {
        public void SaveUser();
        public IdentityUser FindUserByNameAndPassword(string name, string password);
    }
}
