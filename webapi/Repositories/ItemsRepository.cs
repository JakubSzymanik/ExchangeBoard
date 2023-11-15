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

        public async Task<bool> CreateItem(ItemCreateDTO itemCreateDto)
        {
            var item = new Item
            {
                Name = itemCreateDto.Name,
                Description = itemCreateDto.Description,
                UserId = itemCreateDto.UserId
            };
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            //do wyjebania
            var photo = new Photo
            {
                Url = "https://picsum.photos/400",
                ItemId = item.Id
            };
            _context.Photos.Add(photo);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Item>> GetMatchableItems(int userId, int itemId)
        {
            var items = from item in _context.Items
                        where
                            (!_context.Matches.Any(match => match.ItemAID == item.Id || match.ItemBID == item.Id)) &&
                            item.UserId != userId &&
                            item.Id != itemId
                        select item;

            return await items.ToListAsync();
        }
    }
}
