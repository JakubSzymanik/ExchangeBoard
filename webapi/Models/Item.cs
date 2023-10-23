using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Photo> Photos { get; set; } //navigation property do podłączonych zdjęć
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
