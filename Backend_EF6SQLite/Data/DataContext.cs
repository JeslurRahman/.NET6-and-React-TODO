using Backend_EF6SQLite.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_EF6SQLite.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Contact> contacts => Set<Contact>();
    }
}
