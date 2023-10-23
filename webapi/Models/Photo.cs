using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    [Table("Photos")] //nie robimy seta do zdjęć w kontekście, który nadałby nazwę tabeli w migracji, więc tutaj można to zoverridować
    public class Photo
    {
        public int Id { get; set; }
        public bool IsMain { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }

        public int ItemId { get; set; } //foreign key
        public Item Item { get; set; } //navigation property do itemu, tu raczej nie potrzebny
    }
}
