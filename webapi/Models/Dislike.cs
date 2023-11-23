namespace webapi.Models
{
    public class Dislike
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int TargetItemId { get; set; }
        public Item TargetItem { get; set; }
    }
}
