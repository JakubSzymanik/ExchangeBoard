﻿using Microsoft.EntityFrameworkCore;
using webapi.Context;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Repositories
{
    public class UsersRepository : RepositoryBase, IUsersRepository
    {
        public UsersRepository(AppDbContext context) : base(context) {}

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.Include(v => v.Items).ThenInclude(v => v.Photos).FirstAsync(user => user.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.Include(v => v.Items).ThenInclude(v => v.Photos).ToListAsync();
        }

        //do weryfikacji
        public async Task<int> UpdateUserAsync(User user)
        {
            _context.Update(user);
            return await _context.SaveChangesAsync();
        }
    }
}
