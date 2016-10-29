using Auxo.Data;
using Auxo.Unit;
using Microsoft.EntityFrameworkCore;

namespace Auxo.EFCore.Unit
{
    public class DatabaseContextTest : DataContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DatabaseContextTest()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./test.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}