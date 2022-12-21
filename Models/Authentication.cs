using Microsoft.Build.Framework;

namespace APIService.Models
{
    public class Authentication 
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
        
        [Required]
        public string? Role { get; set; }
    }
}
