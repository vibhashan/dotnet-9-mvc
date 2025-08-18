using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyAppContext(DbContextOptions<MyAppContext> options) : DbContext(options)
    {
        public DbSet<Item> Items { get; set; }
    }
}

