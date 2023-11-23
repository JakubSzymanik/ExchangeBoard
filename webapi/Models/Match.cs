namespace webapi.Models
{
    public class Match
    {
        public int Id { get; set; }
        public bool IsSuccess { get; set; }

        public int ItemAId { get; set; }
        public Item ItemA { get; set; }

        public int ItemBId { get; set; }
        public Item ItemB { get; set; }
    }
}
