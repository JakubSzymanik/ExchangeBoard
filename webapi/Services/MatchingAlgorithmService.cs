using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services
{
    public class MatchingAlgorithmService : IMatchingAlgorithmService
    {
        public Item GetNextItem(IEnumerable<Item> items)
        {
            return items.OrderBy(item => item.Name).First();
        }
    }
}
