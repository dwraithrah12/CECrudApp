using System.Threading.Tasks;
using CEGameApp.API.Models;

namespace CEGameApp.API.Data
{
    public interface IAuthRepository
    {
         Task<Users> Register(Users user, string password);

         Task<Users> Login(string userName, string password);

         Task<bool> UserExists(string userName);
    }
}