using System.ComponentModel.DataAnnotations;

namespace CEGameApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 4, ErrorMessage="You must enter a password between 4 and 16 characters")]
        public string Password { get; set; }
    }
}