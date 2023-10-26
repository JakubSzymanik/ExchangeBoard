using System.ComponentModel.DataAnnotations;
using webapi.Models;

namespace webapi.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<ItemDTO>? Items { get; set; }
    }
}
