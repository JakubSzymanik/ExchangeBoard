using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>().
                HasOne(like => like.Item).
                WithMany().
                HasForeignKey(like => like.ItemId).
                IsRequired().
                OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Like>().
                HasOne(like => like.TargetItem).
                WithMany().
                HasForeignKey(like => like.TargetItemId).
                IsRequired().
                OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>().
                HasOne(match => match.ItemA).
                WithMany().
                HasForeignKey(match => match.ItemAID).
                IsRequired().
                OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>().
                HasOne(match => match.ItemB).
                WithMany().
                HasForeignKey(match => match.ItemBID).
                IsRequired().
                OnDelete(DeleteBehavior.NoAction);
        }
    }
}
