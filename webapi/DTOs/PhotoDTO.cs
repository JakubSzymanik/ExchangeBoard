using System.Text.Json.Serialization;
using webapi.Models;

namespace webapi.DTOs
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public bool IsMain { get; set; }
        public string Url { get; set; }
    }
}
