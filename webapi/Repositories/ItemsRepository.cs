using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using webapi.Context;
using webapi.DTOs;
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

        public async Task<bool> CreateItem(Item item, Photo photo)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            _context.Photos.Add(photo);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
