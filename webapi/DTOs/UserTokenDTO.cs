using System.ComponentModel.DataAnnotations;

namespace webapi.DTOs
{
    public class UserTokenDTO
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
