using webapi.Models;

namespace webapi.Interfaces
{
    public interface IMatchesRepository
    {
        Task<IEnumerable<Item>> GetMatchableItems(int userId, int itemId);
        Task<int> CreateLike(int itemId, int targetItemId);
        Task<int> CreateDislike(int itemId, int targetItemId);
    }
}
