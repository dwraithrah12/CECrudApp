using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using CEGameApp.API.Models;

namespace CEGameApp.API.Data
{
    public interface ILoginService
    {
          string GenerateToken(Users user);
    }
}