using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webapi.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Photo>? Photos { get; set; } //navigation property do podłączonych zdjęć

        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }


    }
}
