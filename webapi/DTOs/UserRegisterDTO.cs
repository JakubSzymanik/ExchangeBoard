using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTOs
{
    public class UserRegisterDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        [PasswordPropertyText]
        [MinLength(5)]
        [MaxLength(20)]
        public string Password { get; set; }
        public string Name {  get; set; }
    }
}
