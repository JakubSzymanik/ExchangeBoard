using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<int> UpdateUserAsync(User user); //do weryfikacji
    }
}
