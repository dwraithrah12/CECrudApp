using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CEGameApp.API.Data
{
    public interface IUserRepository
    {
        Task<bool> RegisterUser(string userName, string password);
    }
}