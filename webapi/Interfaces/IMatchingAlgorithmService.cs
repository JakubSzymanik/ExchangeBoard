using webapi.Models;

namespace webapi.Interfaces
{
    public interface IMatchingAlgorithmService
    {
        public Item GetNextItem(IEnumerable<Item> items);
    }
}
