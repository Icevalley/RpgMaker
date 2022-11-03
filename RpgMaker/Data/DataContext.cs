using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RpgMaker.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<User> User { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Weapon> Weapon { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
    }
}
