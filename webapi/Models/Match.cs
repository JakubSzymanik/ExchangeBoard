namespace webapi.Models
{
    public class Match
    {
        public int Id { get; set; }
        public bool IsSuccess { get; set; }

        public int ItemAID { get; set; }
        public Item ItemA { get; set; }

        public int ItemBID { get; set; }
        public Item ItemB { get; set; }

        public bool ContainsItems(int itemAID, int itemBID)
        {
            return (this.ItemAID == itemAID && this.ItemBID == itemBID) ||
                (this.ItemAID == itemBID && this.ItemBID == itemAID);
        }
    }
}
