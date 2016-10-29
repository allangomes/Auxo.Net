using Auxo.Data;
using Auxo.Unit;
using Microsoft.EntityFrameworkCore;

namespace Auxo.EFCore.Unit
{
    public class DatabaseContextTest : DataContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DatabaseContextTest() : base(new DbContextOptionsBuilder<DatabaseContextTest>()
            .UseSqlite("Filename=./test.db").Options)
        {
            Database.Migrate();
        }
    }
}