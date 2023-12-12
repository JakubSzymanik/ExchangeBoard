using webapi.Models;

namespace webapi.Interfaces
{
    public interface IMatchesRepository
    {
        public Task<IEnumerable<Item>> GetMatchableItems(int userId, int itemId);
        public Task<int> CreateLike(int itemId, int targetItemId);
        public Task<int> CreateDislike(int itemId, int targetItemId);
        public Task<int> CreateMatch(int itemId, int targetItemId, bool success);

        public Task<bool> IsLiked(int itemId, int targetItemId);
        public Task<bool> IsDisliked(int itemId, int targetItemId);
        public Task<Match> AreMatched(int itemAId, int itemBId);

        public Task<int> DeleteLikes(int itemAId, int itemBId);
        public Task<int> DeleteItem(int itemId);

        public Task<IEnumerable<Match>> GetUserMatches(int userId);
    }
}
