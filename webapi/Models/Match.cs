namespace webapi.Models
{
    public class Match
    {
        public int Id { get; set; }

        public int ItemAID { get; set; }
        public Item ItemA { get; set; }

        public int ItemBID { get; set; }
        public Item ItemB { get; set; }
    }
}
