using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using webapi.Context;
using webapi.Interfaces;
using webapi.Services;

namespace webapi.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>()))
            {
                if(context.Users.Any()) { return; }

                var users = new List<User>()
                {
                    new User() { Name = "Mark", Email = "mark@gmail.com", DateOfBirth = new DateTime(1997,01,01) },
                    new User() { Name = "Anne", Email = "anne@gmail.com", DateOfBirth = new DateTime(1997,01,01) },
                    new User() { Name = "James", Email = "james@gmail.com", DateOfBirth = new DateTime(1997,01,01) }
                };
                foreach(var user in users)
                {
                    using var hmac = new HMACSHA512();
                    user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("test"));
                    user.PasswordSalt = hmac.Key;
                }
                context.Users.AddRange(users);
                context.SaveChanges();

                var items = new List<Item>()
                {
                    new Item() { Name = "Screwdriver", Description = "The best screwdriver on the market, for all screws", UserId = 1 },
                    new Item() { Name = "Dress", Description = "The best dress on the market, for all bodies", UserId = 1 },
                    new Item() { Name = "Car", Description = "The best car on the market, for all roads", UserId = 2 },
                    new Item() { Name = "Ball", Description = "The best ball on the market, for all hoops", UserId = 2 },
                    new Item() { Name = "Cat", Description = "The best cat on the market, for all mice", UserId = 2 },
                    new Item() { Name = "Tshirt", Description = "The best tshirt on the market, for all bodies", UserId = 3 },
                    new Item() { Name = "Bag", Description = "The best bag on the market, for all bodies (hehe)", UserId = 3 }
                };
                context.Items.AddRange(items);
                context.SaveChanges();

                var photos = new List<Photo>()
                {
                    new Photo() { IsMain = true, Url = "https://picsum.photos/400", ItemId = 1 },
                    new Photo() { IsMain = false, Url = "https://picsum.photos/400", ItemId = 1 },
                    new Photo() { IsMain = true, Url = "https://picsum.photos/400", ItemId = 2 },
                    new Photo() { IsMain = false, Url = "https://picsum.photos/400", ItemId = 2 },
                    new Photo() { IsMain = false, Url = "https://picsum.photos/400", ItemId = 2 },
                    new Photo() { IsMain = true, Url = "https://picsum.photos/400", ItemId = 3 },
                    new Photo() { IsMain = true, Url = "https://picsum.photos/400", ItemId = 4 },
                    new Photo() { IsMain = true, Url = "https://picsum.photos/400", ItemId = 5 },
                    new Photo() { IsMain = false, Url = "https://picsum.photos/400", ItemId = 5 },
                    new Photo() { IsMain = true, Url = "https://picsum.photos/400", ItemId = 6 },
                    new Photo() { IsMain = false, Url = "https://picsum.photos/400", ItemId = 6 },
                    new Photo() { IsMain = true, Url = "https://picsum.photos/400", ItemId = 7 },
                };
                context.Photos.AddRange(photos);
                context.SaveChanges();
            }
        }
    }
}
