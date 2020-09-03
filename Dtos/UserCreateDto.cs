using System.ComponentModel.DataAnnotations;

namespace SimpleUser.Dtos
{
    public class UserCreateDto
    {
        [Required] 
        [MaxLength(250)]
        public string Username { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get;set; }
    }
}