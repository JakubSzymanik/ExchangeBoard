using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services
{
    public class MatchingAlgorithmService : IMatchingAlgorithmService
    {
        public Item GetNextItem(IEnumerable<Item> items)
        {
            Random rnd = new Random();
            return items.ElementAt(rnd.Next(0, items.Count()));
        }
    }
}
