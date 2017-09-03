using Microsoft.EntityFrameworkCore;
using TestApp.Data.Abstractions;
using TestApp.Models;

namespace TestApp.Data.Mock
{
    public class StorageContext : DbContext, IStorageContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseInMemoryDatabase("MemoryUsersDb");
            optionsBuilder.UseSqlite("Data Source=users.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Album>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .HasPrincipalKey(t => t.Id)
                .IsRequired();
        }
    }
}
