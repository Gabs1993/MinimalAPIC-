using Cliente.Models;
using Microsoft.EntityFrameworkCore;

namespace Cliente.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) 
            : base(options) => Database.EnsureCreated();

        public DbSet<Clientes> Cliente { get; set; }
    }
}
