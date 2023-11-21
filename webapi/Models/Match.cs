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

        public bool ContainsItems(int itemAID, int itemBID)
        {
            return (this.ItemAId == itemAID && this.ItemBId == itemBID) ||
                (this.ItemAId == itemBID && this.ItemBId == itemAID);
        }
    }
}
