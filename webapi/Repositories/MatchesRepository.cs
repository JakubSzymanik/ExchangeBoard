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
                    (!_context.Matches.Any(match => (match.ItemAId == item.Id && match.ItemBId == itemId)||(match.ItemAId == itemId && match.ItemBId == item.Id))) &&
                     !_context.Likes.Any(like => like.ItemId == itemId && like.TargetItemId == item.Id) &&
                     !_context.Dislikes.Any(dislike => dislike.ItemId == itemId && dislike.TargetItemId == item.Id) &&
                     item.UserId != userId &&
                     item.Id != itemId).
                 Include(item => item.Photos);

            return await items.ToListAsync();
        }

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
            var dislike = new Dislike
            {
                ItemId = itemId,
                TargetItemId = targetItemId
            };
            _context.Dislikes.Add(dislike);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CreateMatch(int itemId, int targetItemId, bool success)
        {
            var match = new Match
            {
                ItemAId = itemId,
                ItemBId = targetItemId,
                IsSuccess = success
            };
            _context.Matches.Add(match);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> IsLiked(int itemId, int targetItemId)
        {
            return await _context.Likes.AnyAsync(
                like => like.ItemId == itemId && 
                like.TargetItemId == targetItemId);
        }
        public async Task<bool> IsDisliked(int itemId, int targetItemId)
        {
            return await _context.Dislikes.AnyAsync(
                dislike => dislike.ItemId == itemId &&  
                dislike.TargetItemId == targetItemId);
        }

        public async Task<Match> AreMatched(int itemAId, int itemBId)
        {
            return await _context.Matches.FirstOrDefaultAsync(match => (match.ItemAId == itemAId && match.ItemBId == itemBId) || (match.ItemAId == itemBId && match.ItemBId == itemAId));
        }

        public async Task<int> DeleteLikes(int itemAId, int itemBId)
        {
            var likes = _context.Likes.Where(like => (like.ItemId == itemAId && like.TargetItemId == itemBId)||(like.ItemId == itemBId && like.TargetItemId == itemAId));
            _context.Likes.RemoveRange(likes);
            var dislikes = _context.Dislikes.Where(dislike => (dislike.ItemId == itemAId && dislike.TargetItemId == itemBId) || (dislike.ItemId == itemBId && dislike.TargetItemId == itemAId));
            _context.Dislikes.RemoveRange(dislikes);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteItem(int itemId)
        {
            var item = await _context.Items.FindAsync(itemId);
            if (item == null)
                return 0;
            _context.Items.Remove(item);
            
            //deleting manually because of ondelete - no action in item set due to circular delete
            var likes = _context.Likes.Where(like => like.ItemId ==  itemId || like.TargetItemId == itemId);
            _context.Likes.RemoveRange(likes);
            var matches = _context.Matches.Where(match => match.ItemAId == itemId || match.ItemBId == itemId);
            _context.Matches.RemoveRange(matches);

            return await _context.SaveChangesAsync();
        }
    }
}
