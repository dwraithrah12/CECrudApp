using System;
using System.Threading.Tasks;
using CEGameApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CEGameApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Users> Login(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == userName);

            if(user == null)
                return null;
            
            if(!VerifiedPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifiedPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //from IDisposable, will dispose of the resources in curly braces once done with them.
            //passing passwordSalt to generate key
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                //System.Text... turns password into byte array.  Pass it to ComputeHash to generate hash out of password.
                //Since hash had salt passed to it, it hashes the password correctly. 
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
                return true;
            }
        }

        public async Task<Users> Register(Users user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);//updates user in database

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //from IDisposable, will dispose of the resources in curly braces once done with them.
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //generate key to salt the hash
                //System.Text... turns password into byte array.  Pass it to ComputeHash to generate hash out of password.
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); 
            }
        }

        public async Task<bool> UserExists(string userName)
        {
            if (await _context.Users.AnyAsync(x => x.Name == userName))
                return true;
            return false;
        }
    }
}