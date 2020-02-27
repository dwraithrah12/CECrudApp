using System.Threading.Tasks;
using CEGameApp.API.Data;
using CEGameApp.API.Dtos;
using CEGameApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CEGameApp.API.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //validate request
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            
            if (await _repo.UserExists(userForRegisterDto.UserName))
                return BadRequest("Username already exists");
            
            var userToCreate = new Users
            {
                Name = userForRegisterDto.UserName
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);  //will change to createdatroute once we have a place to get data from
        }
    }
}