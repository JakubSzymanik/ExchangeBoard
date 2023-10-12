using System.ComponentModel.DataAnnotations;

namespace webapi.DTOs
{
    public class UserTokenDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
