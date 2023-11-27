using webapi.DTOs;
using webapi.Models;

namespace webapi.Interfaces
{
    public interface IItemsRepository
    {
        Task<Item> GetItemByIdAsync(int id);
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<IEnumerable<Item>> GetUserItemsByIdAsync(int userId);
        Task<bool> CreateItem(Item item);
    }
}
