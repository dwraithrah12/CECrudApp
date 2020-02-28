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

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
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


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.UserName.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized();

            //***************  All of this to create a token to send to users logging in *******************
            
            //2 claims being sent back as part of token containing user Id and username
            var claims = new[]
            {
                new Claim( ClaimTypes.NameIdentifier, userFromRepo.Id.ToString() ),
                new Claim( ClaimTypes.Name, userFromRepo.Name)
            };

            //creating security key
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            //attaching key as part of signing credentials that's encrypted
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //creating first part of token with claims, expiration date and security credentials.
            var tokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new{
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}