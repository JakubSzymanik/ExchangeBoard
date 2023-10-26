using System.Text.Json.Serialization;
using webapi.Models;

namespace webapi.DTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<PhotoDTO>? Photos { get; set; } //navigation property do podłączonych zdjęć
    }
}
