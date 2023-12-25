using Mango.Services.AuthAPI.Data.Repository.IRepository;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Data.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _db;

        public AuthRepository(AppDbContext db)
        {
            _db = db;
        }

        public IdentityUser FindUserByNameAndPassword(string name, string password)
        {
            return new IdentityUser();
        }

        public void SaveUser()
        {
            throw new NotImplementedException();
        }
    }
}
