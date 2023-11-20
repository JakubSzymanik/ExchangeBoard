using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using webapi.Context;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Repositories
{
    public class MatchesRepository : RepositoryBase, IMatchesRepository
    {
        public MatchesRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Item>> GetMatchableItems(int userId, int itemId)
        {
            var items = _context.Items
                .Where(item =>
                    (!_context.Matches.Any(match => match.ItemAID == item.Id || match.ItemBID == item.Id)) &&
                     !_context.Likes.Any(like => like.ItemId == itemId) &&
                     item.UserId != userId &&
                     item.Id != itemId).
                 Include(item => item.Photos);

            return await items.ToListAsync();
        }

        //Match AreMatched

        //bool IsLiked

        public async Task<int> CreateLike(int itemId, int targetItemId)
        {
            var like = new Like
            {
                ItemId = itemId,
                TargetItemId = targetItemId
            };
            _context.Likes.Add(like);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CreateDislike(int itemId, int targetItemId)
        {
            var match = new Match
            {
                ItemAID = itemId,
                ItemBID = targetItemId,
                IsSuccess = false
            };
            _context.Matches.Add(match);
            return await _context.SaveChangesAsync();
        }
    }
}
