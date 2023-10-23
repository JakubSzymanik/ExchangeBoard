using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Item> Items { get; set; }

        //dodać extension do przybliżonego wieku
        //dodać seed data
        //dodać interfejs i repository
        //dodać metody w kontrolerze userów, na początek proste do stestowania czy wszystko działa przez repository
    }
}
