using System.Threading.Tasks;
using CEGameApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CEGameApp.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IAuthRepository _repo;

        public UserRepository(IAuthRepository repo)
        {
            _repo = repo;
        }
        
        public async Task<bool> RegisterUser(string userName, string password)
        {
            var userToCreate = new Users
            {
                Name = userName
            };

            await _repo.Register(userToCreate, password);

            return true;
        }
    }
}