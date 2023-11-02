using Microsoft.EntityFrameworkCore;
using webapi.Context;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Repositories
{
    public class ItemsRepository : RepositoryBase, IItemsRepository
    {
        public ItemsRepository(AppDbContext context) : base(context) {}

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _context.Items.Include(item => item.Photos).FirstAsync(item => item.Id == id);
        }

        public async Task<IEnumerable<Item>> GetUserItemsByIdAsync(int userId)
        {
            return await _context.Items.Where(item => item.UserId == userId).Include(item => item.Photos).ToListAsync();
        }
    }
}
