using System.ComponentModel.DataAnnotations;

namespace SimpleUser.Models
{
    public class User
    {
        [Key] 
        public int Id { get; set; }

       [Required] 
       [MaxLength(250)]
        public string Username { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get;set; }
    }
}