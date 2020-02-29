using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CEGameApp.API.Data;
using CEGameApp.API.Dtos;
using CEGameApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CEGameApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepo;
        private readonly ILoginService _loginService;

        public AuthController(IAuthRepository repo, IConfiguration config, IUserRepository userRepo, ILoginService loginService)
        {
            _repo = repo;
            _config = config;
            _userRepo = userRepo;
            _loginService = loginService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {            
            if (await _repo.UserExists(userForRegisterDto.UserName.ToLower()))
                return BadRequest("Username already exists");
            await _userRepo.RegisterUser(userForRegisterDto.UserName.ToLower(), userForRegisterDto.Password);
            
            return StatusCode(201);  //will change to createdatroute once we have a place to get data from
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.UserName.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var token = _loginService.GenerateToken(userFromRepo);

            return Ok(token);
        }
    }
}